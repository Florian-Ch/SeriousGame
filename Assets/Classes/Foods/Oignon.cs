using System.Collections;
using System.Collections.Generic;

public class Oignon : Food
{
    private static Oignon instance = null;
    private Oignon()
    {
        name = "Oignon";
        description = "L'oignon est un aromate universel dans les cuisines du monde entier. En effet, il exhale un parfum unique et relève les saveurs de nombreuses préparations. C'est un aliment tonifiant qui possde une action antiseptique et anti-infectieuse.\nIl contient de nombreux polyphénols, en particulier l'oignon jaune qui est riche en quercétine. Ce composé est très étudié dans la prévention du cancer et la réduction du cholestérol.";
        production = "Chine (25.6%), Inde (20.8%)";
        season = "Septembre à Avril";
        contains = new List<string>(){"Vitamine C", "Potassium", "Vitamine B9", "Fibres"};
        bonus = new Dictionary<string, int>() { { "hp", 0 }, { "attack", 0 }, { "defense", 0 }, { "speed", 0 }, { "critRate", 0 }, { "critDamage", 0 } };
        type = "aliment";
    }

    public static Oignon Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Oignon();
            }
            return instance;
        }
    }
}