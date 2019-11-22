using System.Collections;
using System.Collections.Generic;

public class Sushi : Meal
{
    private static Sushi instance = null;
    private Sushi()
    {
        name = "Sushi";
        description = "Bien que les sushis que nous connaissons de nos jours soient apparus plus tard, les premières traces de sushis remontent au Vème siècle avant J.C., mais le riz servait uniquement à conserver le poisson et n'était pas consommé. Ce plat traditionnel japonnais, composé de riz vinaigré et de poisson cru, est désormais un des emblèmes de cette cuisine dans le monde, bien que sa consommation dans son pays d'origine n'est qu'occasionnelle.";
        production = "Japon";    // lieu d'apparition
        season = "VIIIème siècle";   // date d'apparition
        contains = new List<string>(){"Protéines", "Glucides", "Fibres", "Omega3"};
        _foods = new List<Food>(){Thon.Instance, Riz.Instance};
        bonus = new Dictionary<string, int>() { { "hp", 0 }, { "attack", 0 }, { "defense", 0 }, { "speed", 0 }, { "critRate", 0 }, { "critDamage", 0 } };
    }

    public static Sushi Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Sushi();
            }
            return instance;
        }
    }
}