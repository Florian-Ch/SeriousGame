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

		_ennemies.Add(ListMonsters.get("Hauntree"));
		Combat.setEnnemies(_ennemies);

		SceneManager.LoadScene("CombatMonsterSelection");
	}

	public void stage_1_2()
	{
		Combat.setNumberOfPlayerMonsters(2);

		// Setup ennemies
		List<Monster> _ennemies = new List<Monster>();
		_ennemies.Add(ListMonsters.get("Hauntree"));
		_ennemies.Add(ListMonsters.get("Asterios"));
		Combat.setEnnemies(_ennemies);

		SceneManager.LoadScene("CombatMonsterSelection");
	}
}
