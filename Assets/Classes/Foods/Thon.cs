using System.Collections;
using System.Collections.Generic;

public class Thon : Food
{
    private static Thon instance = null;
    private Thon()
    {
        name = "Thon";
        description = "";
        production = "Espagne (16.1%), Malte (14.1%)";
        season = "Toute l'année";
        contains = new List<string>(){"Protéines", "Phosphore", "Sélénium", "Vitamine A", "Vitamine D"};
    }

    public static Thon Instance
    {
        get
        {
            if (instance != null)
            {
                instance = new Thon();
            }
            return instance;
        }
    }
}