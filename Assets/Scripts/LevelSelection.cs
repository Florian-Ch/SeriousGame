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

        // setup ennemies
        List<Monster> _ennemies = new List<Monster>();
        Monster m = new Monster("Hauntree", "Tank", "Heliamphora", 100, 10, 10, 10);
        _ennemies.Add(m);
        Combat.setEnnemies(_ennemies);

        SceneManager.LoadScene("CombatMonsterSelection");
    }
}
