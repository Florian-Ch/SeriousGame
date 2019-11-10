using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CombatDisplay   : MonoBehaviour
{
    public GameObject playerMonstersContainer, ennemiesContainer, skillsContainer, monsterButtonPrefab, endContainer, cdContainer, healthBar;
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
        endContainer.SetActive(false);
        cdContainer.SetActive(false);
        _playerMonsters = Combat.getPlayerMonsters();
        _ennemies = Combat.getEnnemies();
        monsterPlaying = null;
        playing = false;
        Debug.Log(_playerMonsters.ToString());
        Debug.Log(_ennemies.ToString());
        DisplayMonsters(_playerMonsters, playerMonstersContainer);  // Display player's monsters
        DisplayMonsters(_ennemies, ennemiesContainer);  // Display ennemy's monsters
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
                    Debug.Log(monsterPlaying.ToString() + " joue !");
                    List<Skill> skills = monsterPlaying.getSkills();
                    Monster monsterToAttack = _playerMonsters[Random.Range(0, _playerMonsters.Count - 1)];
                    if(skills[skills.Count-1].getCooldown() == 1)
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
                    AttackMonster(monsterToAttack);
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
            }
        }  
    }

    private void DisplayMonsters(List<Monster> _monstersList, GameObject parent)
    {
        foreach (Monster m in _monstersList)
        {
            Sprite sprite = Resources.Load<Sprite>("MonstersSprites/" + m.getName());       // load texture
            GameObject thumbnail = Instantiate(monsterButtonPrefab) as GameObject;          // create button
            thumbnail.GetComponent<Image>().sprite = sprite;                                // apply texture
            thumbnail.transform.SetParent(parent.transform);                                // place button at the right place
            thumbnail.transform.localScale = new Vector3((float)0.9, (float)0.9, 1);        // resize button (sooo huge by default)
            thumbnail.GetComponent<Button>().onClick.AddListener(() => AttackMonster(m));
            GameObject hpBar = Instantiate(healthBar) as GameObject;
            hpBar.transform.SetParent(thumbnail.transform);
            hpBar.transform.localScale = new Vector3(1, 1, 1);
            hpBar.transform.position = new Vector3(0, 0.75f, 0); // 1 = 62 ?! so 0.75 should be around 46
        }
    }

    private void AttackMonster(Monster m)
    {
        int critDmg = 100;
        if (Random.Range(0, 100) <= monsterPlaying.getCritRate())
            critDmg = monsterPlaying.getCritDmg();
        double rawDmg = (selectedSkill.getMultiplier() * monsterPlaying.getAttack()) * (critDmg / 100);

        int reducedDmg = (int)(rawDmg / (m.getDef() / 5));  // apply damage reduction formula based on ennemy def here

        int currentHp = m.getHp();
        m.setHp(currentHp - reducedDmg);

        // check if monster survive the attack
        if(m.getHp() <= 0)
        {
            if (isPlayerTurn)
                _ennemies.Remove(m);
            else
                _playerMonsters.Remove(m);

            if(_ennemies.Count == 0 || _playerMonsters.Count == 0)
            {
                EndFight();
            }
        }

        // end turn
        monsterPlaying.setAttackBar(0);
        foreach(Skill s in monsterPlaying.getSkills())
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
        foreach(Monster m in _playerMonsters)
        {
            m.setAttackBar(m.getAttackBar() + m.getSpeed());
        }
        foreach (Monster m in _ennemies)
        {
            m.setAttackBar(m.getAttackBar() + m.getSpeed());
        }
    }

    private bool CheckPlayerPlaying()
    {
        bool res = false;
        foreach (Monster m in _playerMonsters)
        {
            int monsterAtb = m.getAttackBar();
            Debug.Log("player atb : " + monsterAtb);
            if(monsterAtb >= 1000)
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
            Debug.Log("ennemy atb : " + monsterAtb);
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
}
