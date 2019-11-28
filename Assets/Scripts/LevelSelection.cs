using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelection : MonoBehaviour {
	public GameObject selecR1;

	// Start is called before the first frame update
	void Start()
	{
		selecR1.SetActive(false);
	}

	public void DisplayR1()
	{
		selecR1.SetActive(true);
	}

	public void CloseR1()
	{
		selecR1.SetActive(false);
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

		_ennemies.Add(ListMonsters.get("Hauntree").clone());
        _ennemies[0].setHp(100);
		Combat.setEnnemies(_ennemies);

        // Setup rewards
        Combat.MonsterExperienceReward = 500;
        Combat.GoldReward = 100;
        Combat.GemReward = 0;

        SceneManager.LoadScene("CombatMonsterSelection");
	}

	public void stage_1_2()
	{
		Combat.setNumberOfPlayerMonsters(2);

		// Setup ennemies
		List<Monster> _ennemies = new List<Monster>();
		_ennemies.Add(ListMonsters.get("Hauntree").clone());
		_ennemies.Add(ListMonsters.get("Asterios").clone());
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
}
