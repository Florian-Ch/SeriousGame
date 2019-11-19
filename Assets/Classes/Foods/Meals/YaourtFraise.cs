using System.Collections;
using System.Collections.Generic;

public class YaourtFraise : Meal
{
    private static YaourtFraise instance = null;
    private YaourtFraise()
    {
        name = "Yaourt aux fraises";
        description = "Yaourt aux fraises";
        production = "";
        season = "Toute l'année";
        contains = new List<string>(){""};
        _foods = new List<Food>(){new Lait(), new Fraise()};
    }

    public static YaourtFraise Instance
    {
        get
        {
            if (instance != null)
            {
                instance = new YaourtFraise();
            }
            return instance;
        }
    }
}