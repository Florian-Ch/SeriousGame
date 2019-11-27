using System.Collections;
using System.Collections.Generic;

public abstract class Food
{
    protected string name, description, production, season, type;
    protected List<string> contains;
    protected Dictionary<string, int> bonus;

    public string getName() { return name; }

    public int getBonusValue(string key)
    {
        if (bonus.ContainsKey(key))
            return bonus[key];
        else
            return 0;
    }

    public Dictionary<string, int> getBonus()
    {
        Dictionary<string, int> res = new Dictionary<string, int>();
        foreach(KeyValuePair<string, int> kvp in bonus)
        {
            res.Add(kvp.Key, kvp.Value);
        }
        return res;
    }

    public string getDescription() { return description; }

    public string getProduction() { return production; }

    public string getSeason() { return season; }

    public List<string> getContains() { return contains; }

    public string getType() { return type; }
}