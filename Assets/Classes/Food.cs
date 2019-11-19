using System.Collections;
using System.Collections.Generic;

public abstract class Food
{
    protected string name, description, production, season;
    protected List<string> contains;
    protected Dictionary<string, int> bonus;
}