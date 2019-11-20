using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public GameObject selecR1;

    // Start is called before the first frame update
    void Start()
    {
        selecR1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void MonsterSelect1_1()
    {
        Combat.setNumberOfPlayerMonsters(1);

        // Setup ennemies
        List<Monster> _ennemies = new List<Monster>();
        List<Skill> m1Skills = new List<Skill>();
        Skill m1s1 = new Skill("Petrification", "Skill", 1, 1);
        Skill m1s2 = new Skill("Peur", "Skill", 3, 1.5);
        m1Skills.Add(m1s1);
        m1Skills.Add(m1s2);
        Monster m = new Monster("Hauntree", "Tank", "Heliamphora", 100, 1000, 10, 60, m1Skills);
        _ennemies.Add(m);
        Combat.setEnnemies(_ennemies);

        SceneManager.LoadScene("CombatMonsterSelection");
    }

    public void stage1_1() {
        Combat.setNumberOfPlayerMonsters(1);

        // Setup ennemies
        List<Monster> _ennemies = new List<Monster>();

        _ennemies.Add(ListMonsters.get("Hauntree"));
        Combat.setEnnemies(_ennemies);
        Console.WriteLine(_ennemies[0].getSkills()[0]);

        SceneManager.LoadScene("CombatMonsterSelection");


    }
}
