using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public string PlayerUsername;
    public Text username, coinNumber, gemsNumber;

    // Start is called before the first frame update
    void Start()
    {
        // create fake data for test
        if(Player.getUsername() != PlayerUsername)  // only create data one the first load
        {
            // Initialize list of monster
            ListMonsters.Init();

            Player.setUsername(PlayerUsername);

            Player.addFood(Chili.Instance, 0);
            Player.addFood(Sushi.Instance, 0);
            Player.addFood(YaourtFraise.Instance, 0);

            Player.addFood(Fraise.Instance, 1);
            Player.addFood(HaricotRouge.Instance, 1);
            Player.addFood(Lait.Instance, 1);
            Player.addFood(Oignon.Instance, 1);
            Player.addFood(Poivron.Instance, 1);
            Player.addFood(Riz.Instance, 1);
            Player.addFood(Steak.Instance, 1);
            Player.addFood(Thon.Instance, 0);

            // Set monster player
			Player.addMonster(ListMonsters.get("Asterios"));
			Player.addMonster(ListMonsters.get("Hauntree"));

			// Why we define a main monster ?
			Player.defineMainMonster(ListMonsters.get("Hauntree"));

            // List of food interactions, not fake MUST be created at start

            ListInteractionFood.AddInteraction(new List<Food>() { Chili.Instance, Riz.Instance }, 2);
            ListInteractionFood.AddInteraction(new List<Food>() { Chili.Instance, Riz.Instance, YaourtFraise.Instance }, 3);

            // End of food interactions
        }
        //END fake data
        username.text = Player.getUsername();
        coinNumber.text = Player.Gold.ToString();
        gemsNumber.text = Player.Gems.ToString();
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

    public void GoToInvocation()
    {
        SceneManager.LoadScene("InvocationPortal");
    }

    public void GoToMealCreation()
    {
        SceneManager.LoadScene("MealCreation");
    }
}
