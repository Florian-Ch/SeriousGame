using System.Collections.Generic;

public static class Player
{
    private static string username;
    private static List<Monster> _monsters = new List<Monster>();
    private static int numberMonstersMax = 100, gems = 0, gold = 0;
    private static Monster mainMonster;
    private static Dictionary<Food, int> _foods = new Dictionary<Food, int>();

   
    public static void setUsername(string name)
    {
        username = name;
    }

	public static string getUsername()
	{
		return username;
	}

	public static void addMonster(Monster m)
	{
		_monsters.Add(m);
	}

    public static bool removeMonster(Monster m)
    {
        if(_monsters.Contains(m) && _monsters.Count > 1)
        {
            _monsters.Remove(m);
            return true;
        }
        return false;
    }

	public static List<Monster> getMonsters()
	{
		return _monsters;
	}

    public static void setMonsters(List<Monster> m) { _monsters = m; }

    public static void clearMonsters() { _monsters.Clear(); }

    public static void defineMainMonster(Monster m)
    {
        mainMonster = m;
    }

    public static Monster getMainMonster() { return mainMonster; }

    public static void addFood(Food f, int quantity)
    {
        if (_foods.ContainsKey(f))
        {
            _foods[f] += quantity;
        }
        else
        {
            _foods.Add(f, quantity);
        }
    }

    public static bool removeFood(Food f, int quantity)
    {
        bool res = true;
        if (_foods.ContainsKey(f) && _foods[f] >= quantity)
        {
            _foods[f] -= quantity;
        }
        else
        {
            res = false;
        }
        return res;
    }


    public static Dictionary<Food, int> getFoodDico()
    {
        return _foods;
    }

    public static void setFoodDico(Dictionary<Food, int> fd) { _foods = fd; }

    public static int Gems { get => gems; set => gems = value; }

    public static int Gold { get => gold; set => gold = value; }

    public static int NumberMonstersMax { get => numberMonstersMax; set => numberMonstersMax = value; }
}
