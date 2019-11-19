using System.Collections;
using System.Collections.Generic;

public class Chili : Meal
{
    private static Chili instance = null;
    private Chili()
    {
        name = "Chili";
        description = "Le chili con carne, plus couramment appelé chili, est une sorte de ragoût de viande épicé originaire du Sud des États-Unis. Il en existe de nombreuses variantes dont les seuls ingrédients communs sont la viande et le chili, un mélange d'épices souvent utilisé dans la cuisine tex-mex. Riche en protéines, les apports énergétiques de ce plat dépendront cependant grandement des ingrédients utilisés (présence ou non de haricots) ainsi que de leur qualité (viande plus ou moins grasse notamment).";
        production = "Texas (USA)";    // lieu d'apparition
        season = "Fin du XIXème siècle";   // date d'apparition
        contains = new List<string>(){"Protéines", "Glucides"};
        _foods = new List<Food>(){HaricotRouge.Instance, Oignon.Instance, Poivron.Instance, Steak.Instance};
    }

    public static Chili Instance
    {
        get
        {
            if (instance != null)
            {
                instance = new Chili();
            }
            return instance;
        }
    }
}