using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class InvocationPortal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Summon()
    {
        int rng = Random.Range(0, 100);
        Monster monster = null;
        if(rng < 89)    // summon 1 star monster
        {
            monster = ListMonsters.OneStarMonsters[Random.Range(0, ListMonsters.OneStarMonsters.Count)];
        }
        else if (rng < 99)    // summon 2 star monster
        {
            monster = ListMonsters.TwoStarsMonsters[Random.Range(0, ListMonsters.TwoStarsMonsters.Count)];
        }
        else if (rng == 99)    // summon 3 star monster
        {
            monster = ListMonsters.ThreeStarsMonsters[Random.Range(0, ListMonsters.ThreeStarsMonsters.Count)];
        }
        Player.addMonster(monster);
        DataSaver.SaveData("player");
    }
}
