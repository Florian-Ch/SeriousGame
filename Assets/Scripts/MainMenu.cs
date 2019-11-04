using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string PlayerUsername;
    public Text username;

    // Start is called before the first frame update
    void Start()
    {
        // create fake data for test
        if(Player.getUsername() != PlayerUsername)  // only create data one the first load
        {
            Player.setUsername(PlayerUsername);
            Monster m1 = new Monster("Asterios", "Support", "Nepenthes", 1000, 70, 40, 70);
            Player.addMonster(m1);
            Monster m2 = new Monster("Hauntree", "Tank", "Heliamphora", 1200, 50, 100, 50);
            Player.addMonster(m2);
            Player.defineMainMonster(m1);
        }
        //END fake data
        username.text = Player.getUsername();
    }

    // Update is called once per frame
    void Update()
    {
        
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
