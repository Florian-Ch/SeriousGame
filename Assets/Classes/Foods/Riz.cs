using System.Collections;
using System.Collections.Generic;

public class Riz : Food
{
    private static Riz instance = null;
    private Riz()
    {
        name = "Riz";
        description = "Le riz est une céréale riche en amidon, cultivée principalement dans des champs plus ou moins inondés. Principal élément de l'alimentation de nombreuses populations du monde, comme par exemple l'Amérique du Sud, l'Afrique ou l'Asie, le riz est la première céréale mondiale dans l'alimentation humaine et la deuxième (après le maïs) en terme de quantité récoltée";
        production = "Chine (28.3 %), Inde (21.4%), Indonésie (10.4%)";
        season = "Toute l'année";
        contains = new List<string>(){"Glucides", "Fibres"};
    }

    public static Riz Instance
    {
        get
        {
            if (instance != null)
            {
                instance = new Riz();
            }
            return instance;
        }
    }
}