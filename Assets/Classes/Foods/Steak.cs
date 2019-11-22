using System.Collections;
using System.Collections.Generic;

public class Steak : Food
{
    private static Steak instance = null;
    private Steak()
    {
        name = "Steak";
        description = "Le steak désigne tout tranche de viande bovine destinée à la consommation humaine. De nombreux morceaux peuvent être utilisés pour la découpe de steak. La proportion de graisse est différente selon les morceaux choisis mais, parmi ces graisses, le taux de cholestérol est plutôt élevé (même si les abats en comportent encore plus).";
        production = "USA (17.4%), Brésil (14.1%)";
        season = "Toute l'année";
        contains = new List<string>(){"Protéines", "Lipides", "Fer", "Zinc", "Sélénium", "Vitamine B3", "Vitamine B12"};
        bonus = new Dictionary<string, int>() { { "hp", 0 }, { "attack", 0 }, { "defense", 0 }, { "speed", 0 }, { "critRate", 0 }, { "critDamage", 0 } };
    }

    public static Steak Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Steak();
            }
            return instance;
        }
    }
}