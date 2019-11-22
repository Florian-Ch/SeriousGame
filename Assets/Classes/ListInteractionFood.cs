using System.Collections;
using System.Collections.Generic;

public static class ListInteractionFood
{
    private static List<InteractionFood> _interactions = new List<InteractionFood>();

    public static void AddInteraction(List<Food> _food, int multiplier)
    {
        _interactions.Add(new InteractionFood(_food, multiplier));
    }

    public static int GetMultiplier(List<Food> _food)
    {
        foreach(InteractionFood ifood in _interactions)
        {
            if (ifood.MatchFoods(_food))
                return ifood.Multiplier;
        }

        return 1;
    }
}
