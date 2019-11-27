using System.Collections;
using System.Collections.Generic;

public abstract class Meal : Food
{
    protected List<Food> _foods;

    public List<Food> getFoodList() { return _foods; }
}