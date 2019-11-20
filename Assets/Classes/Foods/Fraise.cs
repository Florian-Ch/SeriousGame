using System.Collections;
using System.Collections.Generic;

public class Fraise : Food
{
    private static Fraise instance = null;
    private Fraise()
    {
        name = "Fraise";
        description = "De couleur rouge ou orangée selon les variétés, la fraise peut avoir une chair sucrée ou acidulée pour un poids d'environ 10 grammes. Elle se consomme principalement crue mais peut être cuisinée sans aucun soucis, aussi bien dans des plats sucrés que salés.";
        production = "Chine (41.6%), USA (15.6%)";
        season = "Avril - Mai - Juin";
        contains = new List<string>(){"Vitamine C", "Antioxydants"};
    }

    public static Fraise Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Fraise();
            }
            return instance;
        }
    }
}