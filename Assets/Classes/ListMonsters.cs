using System.Collections.Generic;
using UnityEngine;

public static class ListMonsters {
	static List<Monster> monsters = new List<Monster>();


	public static void Init()
	{
		List<Skill> skills = new List<Skill>();
		#region Creating Monster Hauntree
		// Create skills
		skills.Add(new Skill("Petrification", "Skill", 1, 1));
		skills.Add(new Skill("Peur", "Skill", 3, 1.5));

		monsters.Add(new Monster("Hauntree", "Tank", "Heliamphora", 1000, 100, 30, 60, Deepcopy(skills)));

		skills.Clear();
		#endregion

		#region Creating Monster Asterios
		// Create skills
		skills.Add(new Skill("Coup de boule", "Skill", 1, 1));
		skills.Add(new Skill("Enervement", "Skill", 2, 1.2));
		skills.Add(new Skill("Commander", "Skill", 5, 3));

		monsters.Add(new Monster("Asterios", "Support", "Nepenthes", 1000, 90, 50, 70, Deepcopy(skills)));

		skills.Clear();
		#endregion
	}

	public static Monster get(string name)
	{
		foreach (Monster m in monsters)
		{
			if (m.getName() == name) return m.clone();
		}
		return null;
	}

	public static List<Skill> Deepcopy(List<Skill> skills)
	{
		List<Skill> copy = new List<Skill>();
		foreach (Skill skill in skills)
		{
			//copy.Add(skill);
            copy.Add(new Skill(skill.getName(), skill.getIcon(), skill.getInitialCooldown(), skill.getMultiplier()));
        }
		return copy;
	}
}