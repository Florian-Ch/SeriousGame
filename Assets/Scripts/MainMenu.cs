using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public string PlayerUsername;
	public Text username;

	void Start()
	{
		#region Fake DATA
		// Create fake data for test
		if (Player.getUsername() != PlayerUsername)  // only create data one the first load
		{
			// Initialize list of monster
			ListMonsters.Init();

			Player.setUsername(PlayerUsername);

			// Set monster player
			Player.addMonster(ListMonsters.get("Asterios"));
			Player.addMonster(ListMonsters.get("Hauntree"));

			// Why we define a main monster ?
			Player.defineMainMonster(ListMonsters.get("Hauntree"));

		}
		#endregion

		// Set text of the game object "username"
		username.text = Player.getUsername();
	}

	public void GoToLevelSelection()
	{
		SceneManager.LoadScene("LevelSelection");
	}

	public void GoToMonsterBox()
	{
		SceneManager.LoadScene("MonsterBox");
	}
}
