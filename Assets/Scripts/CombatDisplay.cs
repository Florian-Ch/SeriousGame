using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CombatDisplay : MonoBehaviour {
	public GameObject playerMonstersContainer, ennemiesContainer, skillsContainer, monsterButtonPrefab, endContainer, cdContainer, healthBar, attackBar, skillInfo, monsterEndFightContainer, monsterEndFightDisplay, pauseMenu, foodListContainer, counterDisplay, backgound;
	public Text endText, cdText, goldNumber, gemsNumber;

	private List<Monster> _playerMonsters, _combatPlayerMonsters, _combatEnnemies, _monstersToXp;
	private List<Monster> _ennemies;
	private Monster monsterPlaying;
	private bool isPlayerTurn;
	private bool playing;
	private Skill selectedSkill;

	// Start is called before the first frame update
	void Start()
	{
        // Memorize initial combat setup
        _combatPlayerMonsters = new List<Monster>();
        foreach(Monster m in Combat.getPlayerMonsters()) { _combatPlayerMonsters.Add(m.clone()); }
        _combatEnnemies = new List<Monster>();
        foreach (Monster m in Combat.getEnnemies()) { _combatEnnemies.Add(m.clone()); }
        _monstersToXp = Combat.MonstersToXp;

        // Init interface
        pauseMenu.SetActive(false);
		skillInfo.SetActive(false);
		endContainer.SetActive(false);
		cdContainer.SetActive(false);
        backgound.GetComponent<Image>().sprite = Resources.Load<Sprite>("Decor/" + Combat.Background);
		_playerMonsters = Combat.getPlayerMonsters();
		_ennemies = Combat.getEnnemies();
		monsterPlaying = null;
		playing = false;
		DisplayMonsters(_playerMonsters, playerMonstersContainer);  // Display player's monsters
		DisplayMonsters(_ennemies, ennemiesContainer);  // Display ennemy's monsters

		// setEventClickOnEnnemiesMonster(); // Set the click event on ennemies monsters

		initPlayersMonsters();
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
					SelectSkill(monsterPlaying.Skills[0]);
					playing = true;
				}
				else                // Ennemy turn, AI
				{
					ennemiesTurn();
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
			foreach (Skill skill in monsterPlaying.Skills)
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
            if(m.getName().StartsWith("BOSS"))
            {
                monster.transform.localScale = new Vector3(3, 3, 1);        // resize button (sooo huge by default)
            }
            else
            {
                monster.transform.localScale = new Vector3(0.9f, 0.9f, 1);        // resize button (sooo huge by default)
            }
            monster.name = m.getName();

			// Get healthBar
			GameObject hpBar = Instantiate(healthBar) as GameObject;
			hpBar.transform.SetParent(monster.transform);
			hpBar.transform.localScale = new Vector3(1, 1, 1);
            if (m.getName().StartsWith("BOSS"))
            {
                hpBar.transform.position = new Vector3(0, 3f, 0); // 1 = 62 ?! so 0.75 should be around 46
            }
            else
            {
                hpBar.transform.position = new Vector3(0, 0.75f, 0); // 1 = 62 ?! so 0.75 should be around 46
            }
            
			// Set HPbar to monster
			m.HealthBar = hpBar;

			// Get attackBar
			GameObject atb = Instantiate(attackBar) as GameObject;
			atb.transform.SetParent(monster.transform);
			atb.transform.localScale = new Vector3(1, 1, 1);
            if (m.getName().StartsWith("BOSS"))
            {
                atb.transform.position = new Vector3(0, 2.8f, 0); // 1 = 62 ?! so 0.75 should be around 46
            }
            else
            {
                atb.transform.position = new Vector3(0, 0.70f, 0); // 1 = 62 ?! so 0.75 should be around 46
            }

            // ! Depreciate (bug, we can kil our own monster)
            monster.GetComponent<Button>().onClick.AddListener(() => AttackMonster(m, m.HealthBar));
		}
	}

	private void AttackMonster(Monster m, GameObject hpBar)
	{
        // Debug.Log("monstre utilise skill id " + selectedSkill.Id);
        int critDmg = 100;
		if (Random.Range(0, 100) <= monsterPlaying.getCritRate())
			critDmg = monsterPlaying.getCritDmg();
		double rawDmg = (selectedSkill.getMultiplier() * monsterPlaying.getAttack()) * (critDmg / 100);

		int reducedDmg = (int)(rawDmg * ( 1000 / ( 1140+3.5* m.getDef() ) ) );  // apply damage reduction formula based on ennemy def here

		int currentHp = m.getHp();
		m.setHp(currentHp - reducedDmg);
        // Debug.Log("raw : " + rawDmg + " reduced : " + reducedDmg + " previous hp : " + currentHp + " hp : " + m.getHp());
		// check if monster dies
		if (m.getHp() <= 0)
		{
			if (isPlayerTurn)
			{
				_ennemies.Remove(m);
				DisplayMonsters(_ennemies, ennemiesContainer);
                // setEventClickOnEnnemiesMonster();
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
		foreach (Skill s in monsterPlaying.Skills)
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
		if (_playerMonsters.Count == 0)     //Player lost
        {
            endText.text = "Défaite !";
        }
        else    // Player won
        {
            foreach (Monster m in _monstersToXp)
            {
                m.Experience += Combat.MonsterExperienceReward;
                // Debug.Log("xp = " + m.Experience);
                GameObject display = Instantiate(monsterEndFightDisplay) as GameObject;
                display.transform.SetParent(monsterEndFightContainer.transform);
                display.transform.localScale = new Vector3(1, 1);
                Text monsterName = display.transform.Find("MonsterName").gameObject.GetComponent<Text>();
                monsterName.text = m.getName();
                Text xpGained = display.transform.Find("XpGained").gameObject.GetComponent<Text>();
                xpGained.text = "+ " + Combat.MonsterExperienceReward + " xp";
                if (m.HasLevelUp == false)
                    display.transform.Find("LevelUpImage").gameObject.SetActive(false);
                else
                    m.HasLevelUp = false;                           
            }

            goldNumber.text = Combat.GoldReward.ToString();
            gemsNumber.text = Combat.GemReward.ToString();

            Player.Gold += Combat.GoldReward;
            Player.Gems += Combat.GemReward;

            foreach (Transform child in foodListContainer.transform) { GameObject.Destroy(child.gameObject); }
            foreach (Food f in Combat.FoodReward.Keys)
            {
                if(Combat.FoodReward[f] > 0)
                {
                    Player.addFood(f, Combat.FoodReward[f]);
                    Sprite sprite = Resources.Load<Sprite>("FoodSprites/" + f.getName().Replace(' ', '_'));    // load texture
                    GameObject thumbnail = Instantiate(monsterButtonPrefab) as GameObject;          // create button
                    thumbnail.GetComponent<Image>().sprite = sprite;                                // apply texture
                    thumbnail.transform.SetParent(foodListContainer.transform);                 // place button at the right place
                    thumbnail.transform.localScale = new Vector3(1, 1, 1);                          // resize button (sooo huge by default)
                    GameObject foodNumber = Instantiate(counterDisplay) as GameObject;
                    foodNumber.transform.SetParent(thumbnail.transform);
                    foodNumber.transform.localScale = new Vector3(1, 1, 1);
                    foodNumber.transform.position = new Vector3(0.43f, -0.43f, 0);
                    foodNumber.GetComponentInChildren<Text>().text = Combat.FoodReward[f].ToString();
                }
            }

            DataSaver.SaveData("player");
        }
	}

	public void ReturnToLevelSelection()
	{
        Combat.ClearFoodReward();
        SceneManager.LoadScene("LevelSelection");
	}

	public void CloseCdAlert()
	{
        cdContainer.SetActive(false);
	}

	/*private void setEventClickOnEnnemiesMonster()
	{
		GameObject ennemiesContainer = GameObject.Find("EnnemiesContainer");

		foreach (Monster monster in _ennemies)
		{
			// Get gameobject of monster
			GameObject monster_gameobject = ennemiesContainer.transform.Find(monster.getName()).gameObject;

			monster_gameobject.GetComponent<Button>().onClick.AddListener(() => AttackMonster(monster, monster.HealthBar));
		}
	}*/
	
	private void ennemiesTurn()
	{
		List<Skill> skills = monsterPlaying.Skills; // Get skills of current monster
		
		// OLD Selection of monster to attack
		//int rnd = Random.Range(0, _playerMonsters.Count - 1);
		//Monster monsterToAttack = _playerMonsters[rnd];
		//GameObject hpBar = GameObject.Find("PlayerMonstersContainer").transform.GetChild(rnd).Find("HealthBar(Clone)").gameObject;

		Monster monsterToAttack = getPlayerMonsterLowestHP();

		// Choose skill to use
		skills.Reverse(); // Reverse to have the most powerful skills in first

		foreach(Skill skill in skills)
		{
			if(skill.getCooldown() == 1)
			{
				selectedSkill = skill;
				break;
			}
		}
        skills.Reverse();

		AttackMonster(monsterToAttack, monsterToAttack.HealthBar);
	}

	private Monster getPlayerMonsterLowestHP()
	{
		Monster lowestHP = _playerMonsters[0]; // Get the first monster
		foreach(Monster monster in _playerMonsters)
		{
			if (monster.getHp() <= lowestHP.getHp()) lowestHP = monster; 
		}
		return lowestHP;
	}

	private void initPlayersMonsters()
	{
		foreach(Monster monster in _playerMonsters)
		{
			// Reset HP
			monster.setHp(monster.getMaxHp());
			// Reset Cooldown 
			foreach(Skill skill in monster.Skills)
			{
				skill.setCooldown(1);
			}
		}
	}

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Combat.setEnnemies(_combatEnnemies);
        Combat.setPlayerMonsters(_combatPlayerMonsters);
        SceneManager.LoadScene("CombatDisplay");
    }
}
