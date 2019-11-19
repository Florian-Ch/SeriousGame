using System.Collections;
using System.Collections.Generic;

public class Lait : Food
{
    private static Lait instance = null;
    private Lait()
    {
        name = "Lait";
        description = "Lait de vache.";
        production = "USA (14.6%), Inde (11.7%)";
        season = "Toute l'année";
        contains = new List<string>(){""};
    }

    public static Lait Instance
    {
        get
        {
            if (instance != null)
            {
                instance = new Lait();
            }
            return instance;
        }
    }
}