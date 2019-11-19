using System.Collections;
using System.Collections.Generic;

public class Steak : Food
{
    private static Steak instance = null;
    private Steak()
    {
        name = "Steak";
        description = "Steak de boeuf.";
        production = "USA (17.4%), Brésil (14.1%)";
        season = "Toute l'année";
        contains = new List<string>(){"Protéines"};
    }

    public static Steak Instance
    {
        get
        {
            if (instance != null)
            {
                instance = new Steak();
            }
            return instance;
        }
    }
}