using System.Collections.Generic;

public static class Combat {
	private static int numberOfPlayerMonsters;
	private static List<Monster> _ennemies = new List<Monster>();
	private static List<Monster> _playerMonsters = new List<Monster>();

	public static void setNumberOfPlayerMonsters(int n) { numberOfPlayerMonsters = n; }

	public static int getNumberOfPlayerMonsters() { return numberOfPlayerMonsters; }

	public static void setEnnemies(List<Monster> _monstersList) { _ennemies = _monstersList; }

	public static List<Monster> getEnnemies() { return _ennemies; }

	public static void setPlayerMonsters(List<Monster> _monsters) { _playerMonsters = _monsters; }

	public static List<Monster> getPlayerMonsters() { return _playerMonsters; }
}
