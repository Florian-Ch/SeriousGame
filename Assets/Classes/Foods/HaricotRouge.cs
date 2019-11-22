using System.Collections;
using System.Collections.Generic;

public class HaricotRouge : Food
{
    private static HaricotRouge instance = null;
    private HaricotRouge()
    {
        name = "Haricot Rouge";
        description = "Les haricots rouges sont, comme tous les légumes secs, parmi les aliments d'origine végétale les plus riches en protéines, tout en étant dépourvu de graisses. C'est un atout important pour la santé, contribuant à un régime alimentaire équilibré.";
        production = "Chine (73.4%)";
        season = "Toute l'année";
        contains = new List<string>(){"Vitamine B9", "Potassium", "Fer", "Phosphore", "Fibres"};
        bonus = new Dictionary<string, int>() { { "hp", 0 }, { "attack", 0 }, { "defense", 0 }, { "speed", 0 }, { "critRate", 0 }, { "critDamage", 0 } };
    }

    public static HaricotRouge Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new HaricotRouge();
            }
            return instance;
        }
    }
}