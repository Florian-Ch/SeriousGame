using System.Collections;
using System.Collections.Generic;

public class Monster
{
    private string name, role, diet;
    private int level, experience, maxHp, hp, attack, defense, speed, critRate, critDamage;

    public Monster(string nom, string rol, string alim, int pv, int atk, int def, int spd)
    {
        name = nom;
        role = rol;
        diet = alim;
        level = 1;
        experience = 0;
        maxHp = pv;
        hp = pv;
        attack = atk;
        defense = def;
        speed = spd;
        critRate = 15;
        critDamage = 150;
    }

    public string getName() { return name; }

    public string getRole() { return role; }

    public string getDiet() { return diet; }

    public int getMaxHp() { return maxHp; }

    public int getAttack() { return attack; }

    public int getDef() { return defense; }

    public int getSpeed() { return speed; }

    public int getCritRate() { return critRate; }

    public int getCritDmg() { return critDamage; }

    override
    public string ToString()
    {
        return "Monstre : " + name;
    }
}
