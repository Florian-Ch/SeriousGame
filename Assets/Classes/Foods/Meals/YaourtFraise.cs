using System.Collections;
using System.Collections.Generic;

public class YaourtFraise : Meal
{
    private static YaourtFraise instance = null;
    private YaourtFraise()
    {
        name = "Yaourt aux fraises";
        description = "Le yaourt aux fraises est un lait fermenté par le développement de bactéries lactiques dans lequel on ajoute des morceaux de fraises pour des raisons gustatives.";
        production = "Espagne et France";    // lieu d'apparition
        season = "1937";    // date d'apparition
        contains = new List<string>(){"Glucides"};
        _foods = new List<Food>(){Lait.Instance, Fraise.Instance};
    }

    public static YaourtFraise Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new YaourtFraise();
            }
            return instance;
        }
    }
}