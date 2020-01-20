using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonsterBox : MonoBehaviour
{
	public GameObject monsterButtonPrefab, monstersListContainer, data, foodDisplay, skillsDisplay, foodListContainer, monsterFoodContainer, monsterFoodFull;
    public GameObject imSkill1, imSkill2, imSkill3, imSkill4;
    public Text skillDescription, skillCd;

    private List<Monster> _monsters;
    private Monster selectedMonster;

	private GameObject nameDisplay;
	private GameObject nameDisplayFood, nameDisplaySkill;
	private GameObject roleDisplay;    
    private GameObject alimDisplay;
    private GameObject levelDisplay;
    private GameObject hpDisplay;
	private GameObject attackDisplay;
	private GameObject defDisplay;
	private GameObject speedDisplay;
	private GameObject critRateDisplay;
	private GameObject critDmgDisplay;

    // Start is called before the first frame update
    void Start()
    {
        nameDisplayFood = GameObject.Find("MonsterNameFoodDisplay");
        nameDisplaySkill = GameObject.Find("MonsterNameSkillDisplay");
        monsterFoodFull.SetActive(false);
		foodDisplay.SetActive(false);
        skillsDisplay.SetActive(false);

		// Get all gameobjects
		nameDisplay = GameObject.Find("MonsterName");
		
		roleDisplay = GameObject.Find("Role");
        alimDisplay = GameObject.Find("Alim");
        levelDisplay = GameObject.Find("Level");
        hpDisplay = GameObject.Find("Hp");
		attackDisplay = GameObject.Find("Attack");
		defDisplay = GameObject.Find("Def");
		speedDisplay = GameObject.Find("Speed");
		critRateDisplay = GameObject.Find("CritRate");
		critDmgDisplay = GameObject.Find("CritDmg");

        InitializeMonsters();

        DisplayFoodList();       
    }

    private void InitializeMonsters()
    {
        _monsters = Player.getMonsters();
        foreach (Transform child in monstersListContainer.transform) { GameObject.Destroy(child.gameObject); }
        // create monsters list
        foreach (Monster m in _monsters)
        {
            Sprite sprite = Resources.Load<Sprite>("MonstersThumbnails/" + m.getName());    // load texture
            GameObject thumbnail = Instantiate(monsterButtonPrefab) as GameObject;          // create button
            thumbnail.GetComponent<Image>().sprite = sprite;                                // apply texture
            thumbnail.transform.SetParent(monstersListContainer.transform);                 // place button at the right place
            thumbnail.transform.localScale = new Vector3(1, 1, 1);                          // resize button (sooo huge by default)
            thumbnail.GetComponent<Button>().onClick.AddListener(() => DisplayMonsterData(m));
        }

        if (_monsters.Count > 0)
        {
            DisplayMonsterData(_monsters[0]);   // display data of the first monster
            DisplayMonsterFood(_monsters[0]);   // display food of the first monster
            selectedMonster = _monsters[0];
            if (selectedMonster == Player.getMainMonster())
                GameObject.Find("FavoriteMonsterButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("Decor/YellowStar");
            else
                GameObject.Find("FavoriteMonsterButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("Decor/Star");
        }
    }

	public void Return()
	{
		SceneManager.LoadScene("MainMenu");
	}

    private void DisplayMonsterData(Monster m)
    {
        selectedMonster = m;
        if(selectedMonster == Player.getMainMonster())
            GameObject.Find("FavoriteMonsterButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("Decor/YellowStar");
        else
            GameObject.Find("FavoriteMonsterButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("Decor/Star");
        DisplayMonsterFood(m);
        DisplayMonsterSkills(m);
        // image part
        Sprite monsterSprite = Resources.Load<Sprite>("MonstersSprites/" + m.getName());
        GameObject spriteContainer = GameObject.Find("MonsterSprite");
        spriteContainer.GetComponent<Image>().sprite = monsterSprite;
        // data part
        nameDisplay.GetComponent<Text>().text = m.getName();
	    nameDisplayFood.GetComponent<Text>().text = m.getName();
        nameDisplaySkill.GetComponent<Text>().text = m.getName();
        roleDisplay.GetComponent<Text>().text = m.getRole();
        alimDisplay.GetComponent<Text>().text = m.getDiet();
        levelDisplay.GetComponent<Text>().text = m.getLevel().ToString();
        hpDisplay.GetComponent<Text>().text = m.getMaxHp().ToString();
        attackDisplay.GetComponent<Text>().text = m.getAttack().ToString();
        defDisplay.GetComponent<Text>().text = m.getDef().ToString();
        speedDisplay.GetComponent<Text>().text = m.getSpeed().ToString();
        critRateDisplay.GetComponent<Text>().text = m.getCritRate().ToString();
        critDmgDisplay.GetComponent<Text>().text = m.getCritDmg().ToString();
    }

    public void DisplayFood()
	{
		data.SetActive(false);
        skillsDisplay.SetActive(false);
		foodDisplay.SetActive(true);
	}

    public void DisplaySkills()
    {
        data.SetActive(false);
        foodDisplay.SetActive(false);
        DisplayMonsterSkills(selectedMonster);
        skillsDisplay.SetActive(true);
    }

    public void DisplayData()
	{
		foodDisplay.SetActive(false);
        skillsDisplay.SetActive(false);
        DisplayMonsterData(selectedMonster);
		data.SetActive(true);
	}

    public void DisplayMonsterSkills(Monster m)
    {
        imSkill1.GetComponent<Image>().sprite = Resources.Load<Sprite>("SkillsIcons/" + m.Skills[0].getIcon());
        imSkill1.GetComponent<Button>().onClick.AddListener(() => ChangeSkillInfo(m.Skills[0]));
        if (m.Skills.Count > 1)
        {
            imSkill2.GetComponent<Image>().sprite = Resources.Load<Sprite>("SkillsIcons/" + m.Skills[1].getIcon());
            imSkill2.GetComponent<Button>().onClick.AddListener(() => ChangeSkillInfo(m.Skills[1]));
        }
        else
        {
            imSkill2.GetComponent<Image>().sprite = Resources.Load<Sprite>("SkillsIcons/NoSkillIcon");
        }
        if (m.Skills.Count > 2)
        {
            imSkill3.GetComponent<Image>().sprite = Resources.Load<Sprite>("SkillsIcons/" + m.Skills[2].getIcon());
            imSkill3.GetComponent<Button>().onClick.AddListener(() => ChangeSkillInfo(m.Skills[2]));
        }
        else
        {
            imSkill3.GetComponent<Image>().sprite = Resources.Load<Sprite>("SkillsIcons/NoSkillIcon");
        }
        if (m.Skills.Count > 3)
        {
            imSkill4.GetComponent<Image>().sprite = Resources.Load<Sprite>("SkillsIcons/" + m.Skills[3].getIcon());
            imSkill4.GetComponent<Button>().onClick.AddListener(() => ChangeSkillInfo(m.Skills[3]));
        }
        else
        {
            imSkill4.GetComponent<Image>().sprite = Resources.Load<Sprite>("SkillsIcons/NoSkillIcon");
        }
        skillDescription.text = m.Skills[0].getDescription();
        skillCd.text = "Temps de pause : " + m.Skills[0].getInitialCooldown();
    }

    private void ChangeSkillInfo(Skill s)
    {
        skillDescription.text = s.getDescription();
        skillCd.text = "Temps de pause : " + s.getInitialCooldown();
    }

    public void DisplayFoodList()
    {
        foreach (Transform child in foodListContainer.transform) { GameObject.Destroy(child.gameObject); }
        if(Player.getFoodDico().Count > 0)
        {
            foreach (Food f in Player.getFoodDico().Keys)
            {
                if (Player.getFoodDico()[f] > 0)
                {
                    Sprite sprite = Resources.Load<Sprite>("FoodSprites/" + f.getName().Replace(' ', '_'));    // load texture
                    GameObject thumbnail = Instantiate(monsterButtonPrefab) as GameObject;          // create button
                    thumbnail.GetComponent<Image>().sprite = sprite;                                // apply texture
                    thumbnail.transform.SetParent(foodListContainer.transform);                 // place button at the right place
                    thumbnail.transform.localScale = new Vector3(1, 1, 1);                          // resize button (sooo huge by default)
                    thumbnail.GetComponent<Button>().onClick.AddListener(() => AddFoodToMonster(f));
                }
            }
        }
    }

    public void AddFoodToMonster(Food f)
    {
        bool added = selectedMonster.addFood(f);
        if (added)
        {
            int mult = ListInteractionFood.GetMultiplier(new List<Food>(selectedMonster.getFood()));
            selectedMonster.FoodBonusMultiplier = mult;
            AddStats(f, selectedMonster);
            DisplayMonsterFood(selectedMonster);
            Player.removeFood(f, 1);
            DisplayFoodList();
        }
        else
        {
            // max food reach display
            monsterFoodFull.SetActive(true);
        }

        DataSaver.SaveData("player");
    }

    public void CloseMonsterFoodFull()
    {
        monsterFoodFull.SetActive(false);
    }

    public void RemoveFoodFromMonster(Food f)
    {
        selectedMonster.removeFood(f);
        Player.addFood(f, 1);
        DisplayMonsterFood(selectedMonster);
        DisplayFoodList();

        int mult = ListInteractionFood.GetMultiplier(new List<Food>(selectedMonster.getFood()));
        selectedMonster.FoodBonusMultiplier = mult;
        RemoveStats(f, selectedMonster);

        DataSaver.SaveData("player");
    }

    public void DisplayMonsterFood(Monster m)
    {
        foreach (Transform child in monsterFoodContainer.transform) { GameObject.Destroy(child.gameObject); }
        Food[] _food = m.getFood();
        for (int i = 0; i < 3; i++)
        {
            Sprite sprite;
            if (_food[i] != null)
            {
                sprite = Resources.Load<Sprite>("FoodSprites/" + _food[i].getName().Replace(' ', '_'));
            }
            else
            {
                sprite = Resources.Load<Sprite>("FoodSprites/meal");
            }
            GameObject thumbnail = Instantiate(monsterButtonPrefab) as GameObject;
            thumbnail.GetComponent<Image>().sprite = sprite;
            thumbnail.transform.SetParent(monsterFoodContainer.transform);
            thumbnail.transform.localScale = new Vector3(1, 1, 1);
            if (_food[i] != null)
            {
                Food param = _food[i];  // do NOT pass _food[i] as parameter, doesn't work
                thumbnail.GetComponent<Button>().onClick.AddListener(() => RemoveFoodFromMonster(param));
            }
        }
    }

    public void AddStats(Food f, Monster m)
    {
        m.addStats(-m.BonusStats["hp"], -m.BonusStats["attack"], -m.BonusStats["defense"], -m.BonusStats["speed"], -m.BonusStats["critRate"], -m.BonusStats["critDamage"]);

        Dictionary<string, int> statsToAdd = f.getBonus();
        foreach (KeyValuePair<string, int> kvp in f.getBonus())
        {
            m.BonusStats[kvp.Key] += statsToAdd[kvp.Key];
        }

        foreach (KeyValuePair<string, int> kvp in f.getBonus())
        {
            m.BonusStats[kvp.Key] *= m.FoodBonusMultiplier;
        }
        
        m.addStats(m.BonusStats["hp"], m.BonusStats["attack"], m.BonusStats["defense"], m.BonusStats["speed"], m.BonusStats["critRate"], m.BonusStats["critDamage"]);
    }

    public void RemoveStats(Food f, Monster m)
    {
        m.addStats(-m.BonusStats["hp"], -m.BonusStats["attack"], -m.BonusStats["defense"], -m.BonusStats["speed"], -m.BonusStats["critRate"], -m.BonusStats["critDamage"]);

        foreach(string s in f.getBonus().Keys)  // resets bonus stats
        {
            m.BonusStats[s] = 0;
        }

        foreach(Food food in new List<Food>(m.getFood()))
        {
            if(food != null)
            {
                foreach (KeyValuePair<string, int> kvp in food.getBonus())
                {
                    m.BonusStats[kvp.Key] += food.getBonus()[kvp.Key];
                }
            }
        }

        foreach (KeyValuePair<string, int> kvp in f.getBonus())
        {
            m.BonusStats[kvp.Key] *= m.FoodBonusMultiplier;
        }

        m.addStats(m.BonusStats["hp"], m.BonusStats["attack"], m.BonusStats["defense"], m.BonusStats["speed"], m.BonusStats["critRate"], m.BonusStats["critDamage"]);
    }

    public void ChangeMainMonster()
    {
        Player.defineMainMonster(selectedMonster);
        GameObject.Find("FavoriteMonsterButton").GetComponent<Image>().sprite = Resources.Load<Sprite>("Decor/YellowStar");

        DataSaver.SaveData("player");
    }

    public void DeleteMonster()
    {
        if(Player.removeMonster(selectedMonster))
        {
            InitializeMonsters();
        }

        DataSaver.SaveData("player");
    }
}
