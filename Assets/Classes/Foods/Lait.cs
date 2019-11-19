using System.Collections;
using System.Collections.Generic;

public class Lait : Food
{
    private static Lait instance = null;
    private Lait()
    {
        name = "Lait";
        description = "Le lait de vache est le lait produit par la vache dès la naissance de son veau pour le nourrir. Il est très utilisé en alimentation humaine transformé ou non.";
        production = "USA (14.6%), Inde (11.7%)";
        season = "Toute l'année";
        contains = new List<string>(){"Glucides", "Lipides", "Protéines", "Calcium", "Phosphore"};
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