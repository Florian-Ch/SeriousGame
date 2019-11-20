using System.Collections;
using System.Collections.Generic;

public class InteractionFood
{
    private List<Food> _foods;
    private int multiplier;

    public InteractionFood(List<Food> foods, int coeff)
    {
        _foods = foods;
        multiplier = coeff;
    }

}