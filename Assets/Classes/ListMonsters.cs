using System.Collections;
using System.Collections.Generic;

public static class ListMonsters {
    static List<Monster> monsters = new List<Monster>();


    public static void Init() {
        List<Skill> skills = new List<Skill>();
        #region Creating Monster Hauntree
        // Create skills
        skills.Add(new Skill("Petrification", "Skill", 1, 1));
        skills.Add(new Skill("Peur", "Skill", 3, 1.5));

        monsters.Add(new Monster("Hauntree", "Tank", "Heliamphora", 100, 1000, 10, 60 , deepcopy(skills)));

		skills.Clear();
        #endregion
    }

    public static Monster get(string name) {
        foreach(Monster m in monsters) {
            if(m.getName() == name) return m;
        }
        return null;
    }

    public static List<Skill> deepcopy(List<Skill> skills) {
        List<Skill> copy = new List<Skill>();
		foreach(Skill skill in skills) {
			copy.Add(skill);
		}
	    return copy;
    }
}