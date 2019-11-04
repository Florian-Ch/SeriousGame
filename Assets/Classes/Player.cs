using System.Collections;
using System.Collections.Generic;

public static class Player
{
    private static string username;
    private static List<Monster> _monsters = new List<Monster>();
    private static int numberMonstersMax;
    private static Monster mainMonster;

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

    public static List<Monster> getMonsters()
    {
        return _monsters;
    }

    public static void defineMainMonster(Monster m)
    {
        mainMonster = m;
    }
}
