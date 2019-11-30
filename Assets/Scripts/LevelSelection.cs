using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelection : MonoBehaviour {
    public GameObject selecR1, selecDungeons, cowStages, fieldStages;

	// Start is called before the first frame update
	void Start()
	{
		selecR1.SetActive(false);
        selecDungeons.SetActive(false);
	}

	public void DisplayR1()
	{
		selecR1.SetActive(true);
	}

	public void CloseR1()
	{
		selecR1.SetActive(false);
	}

    public void DisplayDungeons()
    {
        selecDungeons.SetActive(true);
        cowStages.SetActive(true);
        fieldStages.SetActive(false);
    }

    public void DisplayCowStages()
    {
        cowStages.SetActive(true);
        fieldStages.SetActive(false);
    }

    public void DisplayFieldStages()
    {
        cowStages.SetActive(false);
        fieldStages.SetActive(true);
    }

    public void CloseDungeons()
    {
        selecDungeons.SetActive(false);
    }

    public void Return()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void stage1_1()
	{
		Combat.setNumberOfPlayerMonsters(1);

		// Setup ennemies
		List<Monster> _ennemies = new List<Monster>();

		_ennemies.Add(ListMonsters.get("Hauntree"));
        _ennemies[0].setHp(100);
        _ennemies[0].setMaxHp(100);
        Combat.setEnnemies(_ennemies);

        // Setup rewards
        Combat.MonsterExperienceReward = 500;
        Combat.GoldReward = 100;
        Combat.GemReward = 1;

        SceneManager.LoadScene("CombatMonsterSelection");
	}

	public void stage_1_2()
	{
		Combat.setNumberOfPlayerMonsters(2);

		// Setup ennemies
		List<Monster> _ennemies = new List<Monster>();
		_ennemies.Add(ListMonsters.get("Hauntree"));
		_ennemies.Add(ListMonsters.get("Asterios"));
        _ennemies[0].setHp(150);
        _ennemies[0].setMaxHp(150);
        _ennemies[1].setHp(150);
        _ennemies[1].setMaxHp(150);
        Combat.setEnnemies(_ennemies);

        // Setup rewards
        Combat.MonsterExperienceReward = 900;
        Combat.GoldReward = 200;
        Combat.GemReward = 1;

        SceneManager.LoadScene("CombatMonsterSelection");
	}

    // Cow Dungeon Stages

    public void CowStage1()
    {
        Combat.setNumberOfPlayerMonsters(4);

        // Setup ennemies
        List<Monster> _ennemies = new List<Monster>();

        Monster boss = new Monster("BOSSVache", "boss", "boss", 10, 10 , 10, 100, new List<Skill>() { new Skill("Brise-Bouche", "Skill", 1, 2) });

        _ennemies.Add(boss);

        Combat.setEnnemies(_ennemies);

        // Setup rewards
        Combat.MonsterExperienceReward = 500;
        Combat.GoldReward = 1000;
        Combat.GemReward = 0;
        Combat.ClearFoodReward();
        Combat.AddFoodReward(Lait.Instance, Random.Range(0, 2));
        Combat.AddFoodReward(Steak.Instance, Random.Range(0, 2));

        SceneManager.LoadScene("CombatMonsterSelection");
    }

    // Field Dungeon Stages

    public void FieldStage1()
    {
        Combat.setNumberOfPlayerMonsters(4);

        // Setup ennemies
        List<Monster> _ennemies = new List<Monster>();

        Monster boss = new Monster("BOSSChamp", "boss", "boss", 10, 10, 10, 100, new List<Skill>() { new Skill("Brise-Bouche", "Skill", 1, 2) });

        _ennemies.Add(boss);

        Combat.setEnnemies(_ennemies);

        // Setup rewards
        Combat.MonsterExperienceReward = 500;
        Combat.GoldReward = 1000;
        Combat.GemReward = 0;
        Combat.ClearFoodReward();
        Combat.AddFoodReward(Fraise.Instance, Random.Range(0, 2));
        Combat.AddFoodReward(HaricotRouge.Instance, Random.Range(0, 2));
        Combat.AddFoodReward(Oignon.Instance, Random.Range(0, 2));
        Combat.AddFoodReward(Poivron.Instance, Random.Range(0, 2));
        Combat.AddFoodReward(Riz.Instance, Random.Range(0, 2));

        SceneManager.LoadScene("CombatMonsterSelection");
    }
}
