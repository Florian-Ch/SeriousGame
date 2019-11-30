using System.Collections.Generic;

public static class Combat {
	private static int numberOfPlayerMonsters, monsterExperienceReward, goldReward, gemReward;
	private static List<Monster> _ennemies = new List<Monster>();
	private static List<Monster> _playerMonsters = new List<Monster>();
    private static List<Monster> _monstersToXp = new List<Monster>();
    private static Dictionary<Food, int> foodReward = new Dictionary<Food, int>() { { Chili.Instance, 0 }, { Sushi.Instance, 0 }, { YaourtFraise.Instance, 0 }, { Fraise.Instance, 0 }, { HaricotRouge.Instance, 0 }, { Lait.Instance, 0 }, { Oignon.Instance, 0 }, { Poivron.Instance, 0 }, { Riz.Instance, 0 }, { Steak.Instance, 0 }, { Thon.Instance, 0 } };

    public static void setNumberOfPlayerMonsters(int n) { numberOfPlayerMonsters = n; }

	public static int getNumberOfPlayerMonsters() { return numberOfPlayerMonsters; }

	public static void setEnnemies(List<Monster> _monstersList) { _ennemies = _monstersList; }

	public static List<Monster> getEnnemies() { return _ennemies; }

	public static void setPlayerMonsters(List<Monster> _monsters) { _playerMonsters = _monsters; }

	public static List<Monster> getPlayerMonsters() { return _playerMonsters; }

    public static int MonsterExperienceReward { get => monsterExperienceReward; set => monsterExperienceReward = value; }

    public static int GoldReward { get => goldReward; set => goldReward = value; }

    public static int GemReward { get => gemReward; set => gemReward = value; }

    public static List<Monster> MonstersToXp { get => _monstersToXp; set => _monstersToXp = value; }

    public static Dictionary<Food, int> FoodReward { get => foodReward; }

    public static void AddFoodReward(Food f, int quantity)
    {
        if (foodReward.ContainsKey(f))
        {
            foodReward[f] += quantity;
        }
    }

    public static void ClearFoodReward()
    {
        foodReward = new Dictionary<Food, int>() { { Chili.Instance, 0 }, { Sushi.Instance, 0 }, { YaourtFraise.Instance, 0 }, { Fraise.Instance, 0 }, { HaricotRouge.Instance, 0 }, { Lait.Instance, 0 }, { Oignon.Instance, 0 }, { Poivron.Instance, 0 }, { Riz.Instance, 0 }, { Steak.Instance, 0 }, { Thon.Instance, 0 } };
    }
}
