using System.Collections.Generic;
using UnityEngine;

public class Monster {
	private string name, role, diet;
	private int level, experience, maxHp, hp, attack, defense, speed, critRate, critDamage, attackBar;
	private List<Skill> _skills;
	private GameObject healthBar;

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
		healthBar = null;
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

	public GameObject HealthBar { get => healthBar; set => healthBar = value; }

	override
	public string ToString()
	{
		return "Monstre : " + name;
	}
}
