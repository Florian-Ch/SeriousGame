using System.Collections;
using System.Collections.Generic;

public class Chili : Meal
{
    private static Chili instance = null;
    private Chili()
    {
        name = "Chili";
        description = "Chili";
        production = "Texas (USA)";    // lieu d'apparition
        season = "Fin XIXème";   // date d'apparition
        contains = new List<string>(){""};
        _foods = new List<Food>(){new HaricotRouge(), new Oignon(), new Poivron(), new Steak()};
    }

    public static Chili Instance
    {
        get
        {
            if (instance != null)
            {
                instance = new Chili();
            }
            return instance;
        }
    }
}