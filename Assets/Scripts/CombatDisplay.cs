using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CombatDisplay : MonoBehaviour {
	public GameObject playerMonstersContainer, ennemiesContainer, skillsContainer, monsterButtonPrefab, endContainer, cdContainer, healthBar, attackBar, skillInfo;
	public Text endText, cdText;

	private List<Monster> _playerMonsters;
	private List<Monster> _ennemies;
	private Monster monsterPlaying;
	private bool isPlayerTurn;
	private bool playing;
	private Skill selectedSkill;

	// Start is called before the first frame update
	void Start()
	{
		skillInfo.SetActive(false);
		endContainer.SetActive(false);
		cdContainer.SetActive(false);
		_playerMonsters = Combat.getPlayerMonsters();
		_ennemies = Combat.getEnnemies();
		monsterPlaying = null;
		playing = false;
		DisplayMonsters(_playerMonsters, playerMonstersContainer);  // Display player's monsters
		DisplayMonsters(_ennemies, ennemiesContainer);  // Display ennemy's monsters

		setEventClickOnEnnemiesMonster(); // Set the click event on ennemies monsters
	}

	// Update is called once per frame
	void Update()
	{
		if (!playing)    // excute loop only once
		{
			isPlayerTurn = CheckPlayerPlaying();
			if (monsterPlaying == null)
			{
				UpdateAttackBars();
			}
			else
			{
				if (isPlayerTurn)   // Player turn
				{
					SelectSkill(monsterPlaying.getSkills()[0]);
					playing = true;
				}
				else                // Ennemy turn, AI
				{
					List<Skill> skills = monsterPlaying.getSkills();
					int rnd = Random.Range(0, _playerMonsters.Count - 1);
					Monster monsterToAttack = _playerMonsters[rnd];
					GameObject hpBar = GameObject.Find("PlayerMonstersContainer").transform.GetChild(rnd).Find("HealthBar(Clone)").gameObject;
					if (skills[skills.Count - 1].getCooldown() == 1)
					{
						selectedSkill = skills[skills.Count - 1];
					}
					else if (skills[skills.Count - 2].getCooldown() == 1)
					{
						selectedSkill = skills[skills.Count - 1];
					}
					else if (skills[skills.Count - 3].getCooldown() == 1)
					{
						selectedSkill = skills[skills.Count - 1];
					}
					AttackMonster(monsterToAttack, hpBar);
				}
			}
		}
	}

	public void SelectSkill(Skill s)
	{
		int cd = s.getCooldown();
		if (cd > 1)     // cd = 1 means skill is available
		{
			cdContainer.SetActive(true);
			cdText.text = "La compétence n'est pas prête ! Patiente encore " + (cd - 1) + " tour(s)";
		}
		else
		{
			selectedSkill = s;
			foreach (Transform child in skillsContainer.transform) { GameObject.Destroy(child.gameObject); }
			foreach (Skill skill in monsterPlaying.getSkills())
			{
				Sprite sprite;
				if (skill.Equals(s))
					sprite = Resources.Load<Sprite>("SkillsIcons/" + skill.getIcon() + "Selected");
				else
					sprite = Resources.Load<Sprite>("SkillsIcons/" + skill.getIcon());
				GameObject skillIcon = Instantiate(monsterButtonPrefab) as GameObject;
				skillIcon.GetComponent<Image>().sprite = sprite;
				skillIcon.transform.SetParent(skillsContainer.transform);
				skillIcon.transform.localScale = new Vector3(1, 1, 1);
				skillIcon.GetComponent<Button>().onClick.AddListener(() => SelectSkill(skill));

				EventTrigger triggerDown = skillIcon.AddComponent<EventTrigger>();
				var pointerDown = new EventTrigger.Entry();
				pointerDown.eventID = EventTriggerType.PointerDown;
				pointerDown.callback.AddListener((e) => DisplaySkillInfo(skill, skillIcon));
				triggerDown.triggers.Add(pointerDown);

				EventTrigger triggerUp = skillIcon.AddComponent<EventTrigger>();
				var pointerUp = new EventTrigger.Entry();
				pointerUp.eventID = EventTriggerType.PointerUp;
				pointerUp.callback.AddListener((e) => RemoveSkillInfo());
				triggerUp.triggers.Add(pointerUp);

				EventTrigger triggerExit = skillIcon.AddComponent<EventTrigger>();
				var pointerExit = new EventTrigger.Entry();
				pointerExit.eventID = EventTriggerType.PointerExit;
				pointerExit.callback.AddListener((e) => RemoveSkillInfo());
				triggerExit.triggers.Add(pointerExit);
			}
		}
	}

	private void RemoveSkillInfo()
	{
		skillInfo.SetActive(false);
	}

	private void DisplaySkillInfo(Skill skill, GameObject icon)
	{
		Text title = skillInfo.transform.Find("Title").GetComponent<Text>();
		title.text = skill.getName();
		Text multiplier = skillInfo.transform.Find("Multiplier").GetComponent<Text>();
		multiplier.text = "Multiplier = " + skill.getMultiplier();
		Text cd = skillInfo.transform.Find("Cd").GetComponent<Text>();
		cd.text = "Cooldown = " + (skill.getCooldown() - 1);
		skillInfo.transform.position = new Vector3(icon.transform.position.x, skillInfo.transform.position.y);
		skillInfo.SetActive(true);
	}

	private void DisplayMonsters(List<Monster> _monstersList, GameObject parent)
	{
		foreach (Transform child in parent.transform) { GameObject.Destroy(child.gameObject); }

		foreach (Monster m in _monstersList)
		{
			Sprite sprite = Resources.Load<Sprite>("MonstersSprites/" + m.getName());     // load texture
			GameObject monster = Instantiate(monsterButtonPrefab) as GameObject;          // create button
			monster.GetComponent<Image>().sprite = sprite;                                // apply texture
			monster.transform.SetParent(parent.transform);                                // place button at the right place
			monster.transform.localScale = new Vector3((float)0.9, (float)0.9, 1);        // resize button (sooo huge by default)
			monster.name = m.getName();

			// Get healthBar
			GameObject hpBar = Instantiate(healthBar) as GameObject;
			hpBar.transform.SetParent(monster.transform);
			hpBar.transform.localScale = new Vector3(1, 1, 1);
			hpBar.transform.position = new Vector3(0, 0.75f, 0); // 1 = 62 ?! so 0.75 should be around 46

			// Get attackBar
			GameObject atb = Instantiate(attackBar) as GameObject;
			atb.transform.SetParent(monster.transform);
			atb.transform.localScale = new Vector3(1, 1, 1);
			atb.transform.position = new Vector3(0, 0.70f, 0); // 1 = 62 ?! so 0.75 should be around 46

			// ! Depreciate (bug, we can kil our own monster)
			// monster.GetComponent<Button>().onClick.AddListener(() => AttackMonster(m, hpBar));
		}
	}

	private void AttackMonster(Monster m, GameObject hpBar)
	{
		int critDmg = 100;
		if (Random.Range(0, 100) <= monsterPlaying.getCritRate())
			critDmg = monsterPlaying.getCritDmg();
		double rawDmg = (selectedSkill.getMultiplier() * monsterPlaying.getAttack()) * (critDmg / 100);

		int reducedDmg = (int)(rawDmg / (m.getDef() / 5));  // apply damage reduction formula based on ennemy def here

		int currentHp = m.getHp();
		m.setHp(currentHp - reducedDmg);

		// check if monster dies
		if (m.getHp() <= 0)
		{
			if (isPlayerTurn)
			{
				_ennemies.Remove(m);
				DisplayMonsters(_ennemies, ennemiesContainer);
			}
			else
			{
				_playerMonsters.Remove(m);
				DisplayMonsters(_playerMonsters, playerMonstersContainer);
			}

			if (_ennemies.Count == 0 || _playerMonsters.Count == 0)
			{
				EndFight();
			}
		}
		else    // update hp bar
		{
			Transform bar = hpBar.transform.Find("Bar");
			float hpRatio = (float)m.getHp() / (float)m.getMaxHp();
			bar.localScale = new Vector3(hpRatio, 1f);
		}

		// end turn
		monsterPlaying.setAttackBar(0);
		GameObject atb;
		if (isPlayerTurn)
			atb = GameObject.Find("PlayerMonstersContainer").transform.GetChild(_playerMonsters.IndexOf(monsterPlaying)).Find("AttackBar(Clone)").gameObject;
		else
			atb = GameObject.Find("EnnemiesContainer").transform.GetChild(_ennemies.IndexOf(monsterPlaying)).Find("AttackBar(Clone)").gameObject;
		Transform b = atb.transform.Find("Bar");
		float atbRatio = (float)m.getAttackBar() / 1000;
		b.localScale = new Vector3(atbRatio, 1f);
		foreach (Skill s in monsterPlaying.getSkills())
		{
			int cd = s.getCooldown();
			if (cd > 1)
				s.setCooldown(cd - 1);
		}
		selectedSkill.setCooldown(selectedSkill.getInitialCooldown());
		foreach (Transform child in skillsContainer.transform) { GameObject.Destroy(child.gameObject); }
		playing = false;
		monsterPlaying = null;
	}

	private void UpdateAttackBars()
	{
		foreach (Monster m in _playerMonsters)
		{
			m.setAttackBar(m.getAttackBar() + m.getSpeed());
			GameObject atb = GameObject.Find("PlayerMonstersContainer").transform.GetChild(_playerMonsters.IndexOf(m)).Find("AttackBar(Clone)").gameObject;
			Transform bar = atb.transform.Find("Bar");
			float atbRatio = (float)m.getAttackBar() / 1000;
			if (atbRatio >= 1)
				atbRatio = 1f;
			bar.localScale = new Vector3(atbRatio, 1f);
		}
		foreach (Monster m in _ennemies)
		{
			m.setAttackBar(m.getAttackBar() + m.getSpeed());
			GameObject atb = GameObject.Find("EnnemiesContainer").transform.GetChild(_ennemies.IndexOf(m)).Find("AttackBar(Clone)").gameObject;
			Transform bar = atb.transform.Find("Bar");
			float atbRatio = (float)m.getAttackBar() / 1000;
			if (atbRatio >= 1)
				atbRatio = 1f;
			bar.localScale = new Vector3(atbRatio, 1f);
		}
	}

	private bool CheckPlayerPlaying()
	{
		bool res = false;
		foreach (Monster m in _playerMonsters)
		{
			int monsterAtb = m.getAttackBar();
			if (monsterAtb >= 1000)
			{
				if (monsterPlaying == null)
				{
					monsterPlaying = m;
					res = true;
				}
				else
				{
					if (monsterAtb > monsterPlaying.getAttackBar())
					{
						monsterPlaying = m;
						res = true;
					}
				}
			}
		}

		foreach (Monster m in _ennemies)
		{
			int monsterAtb = m.getAttackBar();
			if (monsterAtb >= 1000)
			{
				if (monsterPlaying == null)
				{
					monsterPlaying = m;
					res = false;
				}
				else
				{
					if (monsterAtb > monsterPlaying.getAttackBar())
					{
						monsterPlaying = m;
						res = false;
					}
				}
			}
		}

		return res;
	}

	private void EndFight()
	{
		endContainer.SetActive(true);
		if (_playerMonsters.Count == 0)
			endText.text = "Défaite !";
	}

	public void ReturnToLevelSelection()
	{
		SceneManager.LoadScene("LevelSelection");
	}

	public void CloseCdAlert()
	{
		cdContainer.SetActive(false);
	}

	private void setEventClickOnEnnemiesMonster()
	{
		GameObject ennemiesContainer = GameObject.Find("EnnemiesContainer");

		foreach (Monster monster in _ennemies)
		{
			// Get gameobject of monster
			GameObject monster_gameobject = ennemiesContainer.transform.Find(monster.getName()).gameObject;
			// Get HP bar
			GameObject healthBar = monster_gameobject.transform.Find("HealthBar(Clone)").gameObject;

			monster_gameobject.GetComponent<Button>().onClick.AddListener(() => AttackMonster(monster, healthBar));
		}
	}
}
