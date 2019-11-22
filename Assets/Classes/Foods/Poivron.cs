using System.Collections;
using System.Collections.Generic;

public class Poivron : Food
{
    private static Poivron instance = null;
    private Poivron()
    {
        name = "Poivron";
        description = "Légume très peu calorique et polyvalent, le poivron permet de nombreuses préparations : cru, mariné, rôti, farci, braisé... Sa couleur passe du vert au rouge en même temps que sa maturité augmente.";
        production = "Chine, Mexique";
        season = "Juin à Septembre";
        contains = new List<string>(){"Vitamine C", "Vitamine B6", "Bêta-carotène", "Potassium", "Antioxydants"};
        bonus = new Dictionary<string, int>() { { "hp", 0 }, { "attack", 0 }, { "defense", 0 }, { "speed", 0 }, { "critRate", 0 }, { "critDamage", 0 } };
    }

    public static Poivron Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Poivron();
            }
            return instance;
        }
    }
}