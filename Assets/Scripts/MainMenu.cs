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
            // Initialize list of monster
            ListMonsters.Init();

            Player.setUsername(PlayerUsername);
            List<Skill> m1Skills = new List<Skill>();
            Skill m1s1 = new Skill("Coup de boule", "Skill", 1, 1);
            Skill m1s2 = new Skill("Enervement", "Skill", 2, 1.2);
            Skill m1s3 = new Skill("Commander", "Skill", 5, 3);
            m1Skills.Add(m1s1);
            m1Skills.Add(m1s2);
            m1Skills.Add(m1s3);
            Monster m1 = new Monster("Asterios", "Support", "Nepenthes", 1000, 70, 40, 70, m1Skills);
            Player.addMonster(m1);

            List<Skill> m2Skills = new List<Skill>();
            Skill m2s1 = new Skill("Petrification", "Skill", 1, 1);
            Skill m2s2 = new Skill("Peur", "Skill", 3, 1.5);
            m2Skills.Add(m2s1);
            m2Skills.Add(m2s2);
            Monster m2 = new Monster("Hauntree", "Tank", "Heliamphora", 1200, 50, 100, 50, m2Skills);
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
