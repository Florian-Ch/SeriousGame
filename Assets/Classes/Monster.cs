using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    private string name, role, diet;
    private int level, maxLevel, experience, maxHp, hp, attack, defense, speed, critRate, critDamage, attackBar, foodBonusMultiplier;
    private List<Skill> _skills;
    private Food[] _foods;
    Dictionary<string, int> bonusStats;
    private GameObject healthBar;
    private bool hasLevelUp = false;

    public Monster(string nom, string rol, string alim, int pv, int atk, int def, int spd, List<Skill> skills)
    {
        name = nom;
        role = rol;
        diet = alim;
        level = 1;
        maxLevel = 50;
        experience = 0;
        maxHp = pv;
        hp = pv;
        attack = atk;
        defense = def;
        speed = spd;
        critRate = 15;
        critDamage = 150;
        attackBar = 0;
        _skills = skills;
        _foods = new Food[3];
        foodBonusMultiplier = 1;
        bonusStats = new Dictionary<string, int>() { { "hp", 0 }, { "attack", 0 }, { "defense", 0 }, { "speed", 0 }, { "critRate", 0 }, { "critDamage", 0 } };
        healthBar = null;
    }

    public string getName() { return name; }

    public string getRole() { return role; }

    public string getDiet() { return diet; }

    public int getLevel() { return level; }

    public int getMaxHp() { return maxHp; }

    public void setMaxHp(int pv) { maxHp = pv; }

    public int getHp() { return hp; }

    public void setHp(int pv) { hp = pv; }

    public int getAttack() { return attack; }

    public int getDef() { return defense; }

    public int getSpeed() { return speed; }

    public int getCritRate() { return critRate; }

    public int getCritDmg() { return critDamage; }

    public int getAttackBar() { return attackBar; }

    public void setAttackBar(int atb) { attackBar = atb; }

    public List<Skill> Skills { get => _skills; set => _skills = value; }

    public bool addFood(Food f)
    {
        bool res = true;
        if (_foods[0] == null)
        {
            _foods[0] = f;
        }
        else if (_foods[1] == null)
        {
            _foods[1] = f;
        }
        else if (_foods[2] == null)
        {
            _foods[2] = f;
        }
        else
        {
            res = false;
        }
        return res;
    }

    public int Experience{ get => experience; 
        set 
        { 
            experience = value;
            if (experience >= 1000)
            {
                if (LevelUp())
                {
                    Experience -= 1000;
                }
            }
        } 
    }

    private bool LevelUp()
    {
        if(level == maxLevel)
        {
            return false;
        }
        else
        {
            hasLevelUp = true;
            level++;
            return true;
        }
    }

    public bool HasLevelUp { get => hasLevelUp; set => hasLevelUp = value; }

    public void removeFood(Food f)
    {
        if (_foods[0] == f)
        {
            _foods[0] = _foods[1];
            _foods[1] = _foods[2];
            _foods[2] = null;
        }
        else if (_foods[1] == f)
        {
            _foods[1] = _foods[2];
            _foods[2] = null;
        }
        else if (_foods[2] == f)
        {
            _foods[2] = null;
        }
    }

    public Food[] getFood()
    {
        return _foods;
    }

    public void addStats(int pv, int atk, int def, int spd, int cr, int cd)
    {
        maxHp += pv;
        hp += pv;
        attack += atk;
        defense += def;
        speed += spd;
        critRate += cr;
        critDamage += cd;
    }

    override
    public string ToString()
    {
        return "Monstre : " + name;
    }

    public int FoodBonusMultiplier { get => foodBonusMultiplier; set => foodBonusMultiplier = value; }
    public Dictionary<string, int> BonusStats { get => bonusStats; set => bonusStats = value; }
	public GameObject HealthBar { get => healthBar; set => healthBar = value; }

	public Monster clone()
	{
		return new Monster(name, role, diet, hp, attack, defense, speed, _skills);
	}
}
