using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MealCreation : MonoBehaviour
{
    public GameObject monsterButtonPrefab, foodListContainer, counterDisplay, craftableMealsListContainer, mealFoodListContainer;
    public Text mealName;

    private GameObject foodName, foodDescription, foodProduction, foodSeason, foodContains;
    private List<Meal> craftableMeals = new List<Meal>();
    private Meal selectedMeal = null;

    // Start is called before the first frame update
    void Start()
    {
        foodName = GameObject.Find("FoodName");
        foodDescription = GameObject.Find("FoodDescription");
        foodProduction = GameObject.Find("FoodProduction");
        foodSeason = GameObject.Find("FoodSeason");
        foodContains = GameObject.Find("FoodContains");

        DisplayFoodList();

        if (Player.getFoodDico().Count > 0)
        {
            foreach (Food f in Player.getFoodDico().Keys)
            {
                if (Player.getFoodDico()[f] > 0)
                {
                    DisplayFoodData(f);
                    break;
                }
            }
        }

        GetCraftableMeals();
        if(craftableMeals.Count > 0)
        {
            DisplayCraftableMeals();
            selectedMeal = craftableMeals[0];
            DisplayCraft(selectedMeal);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void DisplayFoodList()
    {
        foreach (Transform child in foodListContainer.transform) { GameObject.Destroy(child.gameObject); }
        if (Player.getFoodDico().Count > 0)
        {
            foreach (Food f in Player.getFoodDico().Keys)
            {
                if (Player.getFoodDico()[f] > 0)
                {
                    Sprite sprite = Resources.Load<Sprite>("FoodSprites/" + f.getName().Replace(' ', '_'));    // load texture
                    GameObject thumbnail = Instantiate(monsterButtonPrefab) as GameObject;          // create button
                    thumbnail.GetComponent<Image>().sprite = sprite;                                // apply texture
                    thumbnail.transform.SetParent(foodListContainer.transform);                 // place button at the right place
                    thumbnail.transform.localScale = new Vector3(1, 1, 1);                          // resize button (sooo huge by default)
                    thumbnail.GetComponent<Button>().onClick.AddListener(() => DisplayFoodData(f));
                    GameObject foodNumber = Instantiate(counterDisplay) as GameObject;
                    foodNumber.transform.SetParent(thumbnail.transform);
                    foodNumber.transform.localScale = new Vector3(1, 1, 1);
                    foodNumber.transform.position = new Vector3(0.43f, -0.43f, 0);
                    foodNumber.GetComponentInChildren<Text>().text = Player.getFoodDico()[f].ToString();
                }
            }
        }
    }

    private void DisplayFoodData(Food f)
    {
        foodName.GetComponent<Text>().text = f.getName();
        foodDescription.GetComponent<Text>().text = f.getDescription();
        if(f.getType() == "aliment")
        {
            foodProduction.GetComponent<Text>().text = "Production : ";
            foodSeason.GetComponent<Text>().text = "Saison : ";
        }
        else if(f.getType() == "repas")
        {
            foodProduction.GetComponent<Text>().text = "Lieu d'apparition : ";
            foodSeason.GetComponent<Text>().text = "Première apparition : ";
        }
        foodProduction.GetComponent<Text>().text += f.getProduction();
        foodSeason.GetComponent<Text>().text += f.getSeason();
        foodContains.GetComponent<Text>().text = "Contient :";
        foreach (string s in f.getContains())
        {
            foodContains.GetComponent<Text>().text += " " + s;
        }
    }

    private void GetCraftableMeals()
    {
        if (Player.getFoodDico().Count > 0)
        {
            foreach (Food f in Player.getFoodDico().Keys)
            {
                if (f.getType() == "repas")
                {
                    int count = 0;
                    foreach(Food aliment in ((Meal)f).getFoodList())
                    {
                        if (Player.getFoodDico()[aliment] > 0)
                        {
                            count++;
                        }
                    }
                    if(count == ((Meal)f).getFoodList().Count)
                    {
                        craftableMeals.Add((Meal)f);
                    }
                }
            }
        }
    }

    private void DisplayCraftableMeals()
    {
        foreach (Transform child in craftableMealsListContainer.transform) { GameObject.Destroy(child.gameObject); }
        if (craftableMeals.Count > 0)
        {
            foreach (Meal m in craftableMeals)
            {
                Sprite sprite = Resources.Load<Sprite>("FoodSprites/" + m.getName().Replace(' ', '_'));    // load texture
                GameObject thumbnail = Instantiate(monsterButtonPrefab) as GameObject;          // create button
                thumbnail.GetComponent<Image>().sprite = sprite;                                // apply texture
                thumbnail.transform.SetParent(craftableMealsListContainer.transform);                 // place button at the right place
                thumbnail.transform.localScale = new Vector3(1, 1, 1);                          // resize button (sooo huge by default)
                thumbnail.GetComponent<Button>().onClick.AddListener(() => DisplayCraft(m));
            }
        }
    }

    private void DisplayCraft(Meal m)
    {
        selectedMeal = m;
        foreach (Transform child in mealFoodListContainer.transform) { GameObject.Destroy(child.gameObject); }
        if (craftableMeals.Count > 0)
        {
            mealName.text = m.getName();
            foreach (Food f in m.getFoodList())
            {
                Sprite sprite = Resources.Load<Sprite>("FoodSprites/" + f.getName().Replace(' ', '_'));    // load texture
                GameObject thumbnail = Instantiate(monsterButtonPrefab) as GameObject;          // create button
                thumbnail.GetComponent<Image>().sprite = sprite;                                // apply texture
                thumbnail.transform.SetParent(mealFoodListContainer.transform);                 // place button at the right place
                thumbnail.transform.localScale = new Vector3(1, 1, 1);                          // resize button (sooo huge by default)
            }
        }
        else
        {
            mealName.text = "Pas de repas craftable actuellement";
        }
    }

    public void CraftMeal()
    {
        Player.addFood(selectedMeal, 1);
        foreach(Food f in selectedMeal.getFoodList())
        {
            Player.removeFood(f, 1);
        }

        craftableMeals.Clear();
        GetCraftableMeals();
        if (craftableMeals.Count > 0)
        {
            DisplayCraftableMeals();
            selectedMeal = craftableMeals[0];
            DisplayCraft(selectedMeal);
        }
        else
        {
            foreach (Transform child in mealFoodListContainer.transform) { GameObject.Destroy(child.gameObject); }
            foreach (Transform child in craftableMealsListContainer.transform) { GameObject.Destroy(child.gameObject); }
            mealName.text = "Pas de repas craftable actuellement";
        }
        DisplayFoodList();
        foreach (Food f in Player.getFoodDico().Keys)
        {
            if (Player.getFoodDico()[f] > 0)
            {
                DisplayFoodData(f);
                break;
            }
        }

        DataSaver.SaveData("player");
    }
}
