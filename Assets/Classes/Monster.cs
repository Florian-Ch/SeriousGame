﻿using System.Collections;
using System.Collections.Generic;

public class Monster
{
    private string name, role, diet;
    private int level, experience, maxHp, hp, attack, defense, speed, critRate, critDamage, attackBar;
    private List<Skill> _skills;
    private Food[] _foods;

    public Monster(string nom, string rol, string alim, int pv, int atk, int def, int spd, List<Skill> skills)
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
        attackBar = 0;
        _skills = skills;
        _foods = new Food[3];
    }

    public string getName() { return name; }

    public string getRole() { return role; }

    public string getDiet() { return diet; }

    public int getMaxHp() { return maxHp; }

    public int getHp() { return hp; }

    public void setHp(int pv) { hp = pv; }

    public int getAttack() { return attack; }

    public int getDef() { return defense; }

    public int getSpeed() { return speed; }

    public int getCritRate() { return critRate; }

    public int getCritDmg() { return critDamage; }

    public int getAttackBar() { return attackBar; }

    public void setAttackBar(int atb) { attackBar = atb; }

    public List<Skill> getSkills() { return _skills; }

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

    override
    public string ToString()
    {
        return "Monstre : " + name;
    }
}
