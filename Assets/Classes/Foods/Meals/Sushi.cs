using System.Collections;
using System.Collections.Generic;

public class Sushi : Meal
{
    private static Sushi instance = null;
    private Sushi()
    {
        name = "Sushi";
        description = "Sushi";
        production = "";
        season = "Toute l'année";
        contains = new List<string>(){""};
        _foods = new List<Food>(){new Thon(), new Algue(), new Riz()};
    }

    public static Sushi Instance
    {
        get
        {
            if (instance != null)
            {
                instance = new Sushi();
            }
            return instance;
        }
    }
}