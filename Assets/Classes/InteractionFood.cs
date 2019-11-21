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

    public List<Food> Foods { get { return _foods; } }

    public int Multiplier { get { return multiplier; } }

    public bool MatchFoods(List<Food> foodList)
    {
        bool res = false;
        if(_foods.Count == foodList.Count)
        {
            int counter = 0;
            foreach(Food f in _foods)
            {
                if (foodList.Contains(f))
                {
                    counter++;
                }
            }
            if(counter == _foods.Count)
            {
                res = true;
            }
        }
        return res;
    }
}