using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public string PlayerUsername;
    public Text username, coinNumber, gemsNumber, usernameInputPlaceholder, usernameInputText;
    public Image mainMonsterSprite;
    public GameObject ParametersMenu, ChangeUsernameMenu;

    // Start is called before the first frame update
    void Start()
    {
        ParametersMenu.SetActive(false);
        ChangeUsernameMenu.SetActive(false);

        ListMonsters.Init();

        Player.addFood(Chili.Instance, 0);
        Player.addFood(Sushi.Instance, 0);
        Player.addFood(YaourtFraise.Instance, 0);

        Player.addFood(Fraise.Instance, 0);
        Player.addFood(HaricotRouge.Instance, 0);
        Player.addFood(Lait.Instance, 0);
        Player.addFood(Oignon.Instance, 0);
        Player.addFood(Poivron.Instance, 0);
        Player.addFood(Riz.Instance, 0);
        Player.addFood(Steak.Instance, 0);
        Player.addFood(Thon.Instance, 0);

        // List of food interactions, not fake MUST be created at start

        ListInteractionFood.AddInteraction(new List<Food>() { Chili.Instance, Riz.Instance }, 2);
        ListInteractionFood.AddInteraction(new List<Food>() { Chili.Instance, Riz.Instance, YaourtFraise.Instance }, 3);

        // End of food interactions
        /*        Player.Gems = SavedData.Instance.gems;
                Player.Gold = SavedData.Instance.gold;
                Player.defineMainMonster(SavedData.Instance.mainMonster);
                Player.NumberMonstersMax = SavedData.Instance.numberMonstersMax;
                Player.setUsername(SavedData.Instance.username);
                Player.setFoodDico(SavedData.Instance._foods);
                Player.setMonsters(SavedData.Instance._monsters);*/

        // create fake data for test
        if (Player.getUsername() != PlayerUsername)  // only create data one the first load
        {
            if(DataSaver.LoadData("player"))
            {

            }
            else
            {
                // Initialize list of monster
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
                Player.addMonster(ListMonsters.get("Flobear"));
                Player.addMonster(ListMonsters.get("Chashire"));

                Player.defineMainMonster(Player.getMonsters()[0]);

                OpenChangeUsername();
            }
        }
        //END fake data
        username.text = Player.getUsername();
        coinNumber.text = Player.Gold.ToString();
        gemsNumber.text = Player.Gems.ToString();
        mainMonsterSprite.sprite = Resources.Load<Sprite>("MonstersThumbnails/" + Player.getMainMonster().getName());

        DataSaver.SaveData("player");
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

    public void OpenParameters()
    {
        ParametersMenu.SetActive(true);
    }

    public void CloseParameters()
    {
        ParametersMenu.SetActive(false);
    }

    public void OpenChangeUsername()
    {
        ChangeUsernameMenu.SetActive(true);
        usernameInputPlaceholder.text = Player.getUsername(); 
    }

    public void CloseChangeUsername()
    {
        ChangeUsernameMenu.SetActive(false);
    }

    public void ChangeUsername()
    {
        Player.setUsername(usernameInputText.text);
        DataSaver.SaveData("player");
        username.text = Player.getUsername();
        CloseChangeUsername();
    }
}
