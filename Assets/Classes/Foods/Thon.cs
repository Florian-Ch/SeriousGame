using System.Collections;
using System.Collections.Generic;

public class Thon : Food
{
    private static Thon instance = null;
    private Thon()
    {
        name = "Thon";
        description = "Il existe plusieurs espèces de thons, qui peuvent nager jusqu'à 80km/h et atteindre un poids de 500kg. Ce poisson migrateur se déplaçant en banc est très largement disponible pour l'Homme mais le risque de surpêche est grand. Il peut se manger cru ou cuisiné, mais pour des raisons de conservation, le thon est principalement commercialisé en conserve.";
        production = "Espagne (16.1%), Malte (14.1%)";
        season = "Toute l'année";
        contains = new List<string>(){"Protéines", "Phosphore", "Sélénium", "Vitamine A", "Vitamine D"};
    }

    public static Thon Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Thon();
            }
            return instance;
        }
    }
}