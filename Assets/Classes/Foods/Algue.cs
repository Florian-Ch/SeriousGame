using System.Collections;
using System.Collections.Generic;

public class Algue : Food
{
    private static Algue instance = null;
    private Algue()
    {
        name = "Algue";
        description = "Algue marine.";
        production = "";
        season = "Toute l'année";
        contains = new List<string>(){""};
    }

    public static Algue Instance
    {
        get
        {
            if (instance != null)
            {
                instance = new Algue();
            }
            return instance;
        }
    }
}