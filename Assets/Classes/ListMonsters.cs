using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class ListMonsters
{
	static List<Monster> monsters = new List<Monster>();
	static List<Monster> oneStarMonsters = new List<Monster>();
	static List<Monster> twoStarsMonsters = new List<Monster>();
	static List<Monster> threeStarsMonsters = new List<Monster>();

	public static List<Monster> OneStarMonsters { get => oneStarMonsters; }

	public static List<Monster> TwoStarsMonsters { get => twoStarsMonsters; }

	public static List<Monster> ThreeStarsMonsters { get => threeStarsMonsters; }

	public static void Init()
	{
		List<Skill> skills = new List<Skill>();

		#region Creating Monster Ecufeu
		// Create skills
		skills.Add(new Skill("Coud'queue", "CoudQueue", "Le lanceur attaque avec sa queue et baisse l'attaque de l'ennemi", 1, 1.25, 1, nb_turn_boost: 2, malus: new List<string>() { "attack" }));
		skills.Add(new Skill("Coud'tête", "CoudTete", "Inflige d'énormes dégâts mais augmente l'attaque de l'adversaire ciblé", 2, 3, boosts: new List<string>() { "attack" }, nb_turn_boost: 1));
		skills.Add(new Skill("Biscotto", "Biscotto", "Augmente l'attaque de tous les alliés", 4, 0, 99, false, new List<string>() { "attack", "defense" }, 2));

		Monster m = new Monster("Ecufeu", "Attaque", "Phyllophages", 250, 750, 250, 100, Deepcopy(skills));
		monsters.Add(m);
		OneStarMonsters.Add(m);
		skills.Clear();
		#endregion

		#region Creating Monster Chashire
		// Create skills
		skills.Add(new Skill("Coud'queue", "CoudQueue", "Le lanceur attaque avec sa queue et baisse l'attaque de l'ennemi", 1, 1.25, 1, nb_turn_boost: 2, malus: new List<string>() { "attack" }));
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Biscotto", "Biscotto", "Augmente l'attaque de tous les alliés", 4, 0, 99, false, new List<string>() { "attack", "defense" }, 2));

		m = new Monster("Chashire", "Support", "Népenthès", 550, 600, 800, 60, Deepcopy(skills));
		monsters.Add(m);
		OneStarMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Coolicorn
		// Create skills
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Coud'tête", "CoudTete", "Inflige d'énormes dégâts mais augmente l'attaque de l'adversaire ciblé", 2, 3, boosts: new List<string>() { "attack" }, nb_turn_boost: 1));
		skills.Add(new Skill("Goûter", "Gouter", "Régénère la santé de tous les alliés de 50%", 4, 0.5, 99, false));

		m = new Monster("Coolicorn", "Tank", "Phyllophages", 800, 450, 700, 50, Deepcopy(skills));
		monsters.Add(m);
		OneStarMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Flobear
		// Create skills
		skills.Add(new Skill("Coud'queue", "CoudQueue", "Le lanceur attaque avec sa queue et baisse l'attaque de l'ennemi", 1, 1.25, 1, nb_turn_boost: 2, malus: new List<string>() { "attack" }));
		skills.Add(new Skill("Phytofouet", "Phytofouet", "Attaque tous les ennemis et réduit leur vitesse pendant 2 tours", 3, 1, 99, nb_turn_boost: 2, malus: new List<string>() { "speed" }));
		skills.Add(new Skill("Biscotto", "Biscotto", "Augmente l'attaque de tous les alliés", 4, 0, 99, false, new List<string>() { "attack", "defense" }, 2));

		m = new Monster("Flobear", "Tank", "Phyllophages", 950, 350, 550, 35, Deepcopy(skills), 3);
		monsters.Add(m);
		ThreeStarsMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Demonorose
		// Create skills
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Coud'tête", "CoudTete", "Inflige d'énormes dégâts mais augmente l'attaque de l'adversaire ciblé", 2, 3, boosts: new List<string>() { "attack" }, nb_turn_boost: 1));
		skills.Add(new Skill("Phytofouet", "Phytofouet", "Attaque tous les ennemis et réduit leur vitesse pendant 2 tours", 3, 1, 99, nb_turn_boost: 2, malus: new List<string>() { "speed" }));

		m = new Monster("Demonorose", "Support", "Heliamphora", 650, 650, 850, 50, Deepcopy(skills));
		monsters.Add(m);
		OneStarMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Fower
		// Create skills
		skills.Add(new Skill("Coud'queue", "CoudQueue", "Le lanceur attaque avec sa queue et baisse l'attaque de l'ennemi", 1, 1.25, 1, nb_turn_boost: 2, malus: new List<string>() { "attack" }));
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Phytofouet", "Phytofouet", "Attaque tous les ennemis et réduit leur vitesse pendant 2 tours", 3, 1, 99, nb_turn_boost: 2, malus: new List<string>() { "speed" }));

		m = new Monster("Fower", "Attaque", "Phyllophages", 350, 800, 300, 85, Deepcopy(skills));
		monsters.Add(m);
		TwoStarsMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster GeekOs
		// Create skills
		skills.Add(new Skill("Coud'queue", "CoudQueue", "Le lanceur attaque avec sa queue et baisse l'attaque de l'ennemi", 1, 1.25, 1, nb_turn_boost: 2, malus: new List<string>() { "attack" }));
		skills.Add(new Skill("Coud'tête", "CoudTete", "Inflige d'énormes dégâts mais augmente l'attaque de l'adversaire ciblé", 2, 3, boosts: new List<string>() { "attack" }, nb_turn_boost: 1));
		skills.Add(new Skill("Biscotto", "Biscotto", "Augmente l'attaque de tous les alliés", 4, 0, 99, false, new List<string>() { "attack", "defense" }, 2));

		m = new Monster("GeekOs", "Support", "Népenthès", 600, 600, 750, 55, Deepcopy(skills), 2);
		monsters.Add(m);
		TwoStarsMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Ghostomac
		// Create skills
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Poing Sombre", "PoingSombre", "Attaque un ennemi et diminue sa défense pendant 1 tour", 2, 1.5, 1, nb_turn_boost: 1, malus: new List<string>() { "defense" }));
		skills.Add(new Skill("Phytofouet", "Phytofouet", "Attaque tous les ennemis et réduit leur vitesse pendant 2 tours", 3, 1, 99, nb_turn_boost: 2, malus: new List<string>() { "speed" }));

		m = new Monster("Ghostomac", "Support", "Heliamphora", 500, 750, 850, 70, Deepcopy(skills));
		monsters.Add(m);
		OneStarMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Kahu
		// Create skills
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Coud'queue", "CoudQueue", "Le lanceur attaque avec sa queue et baisse l'attaque de l'ennemi", 1, 1.25, 1, nb_turn_boost: 2, malus: new List<string>() { "attack" }));
		skills.Add(new Skill("Coud'tête", "CoudTete", "Inflige d'énormes dégâts mais augmente l'attaque de l'adversaire ciblé", 2, 3, boosts: new List<string>() { "attack" }, nb_turn_boost: 1));

		m = new Monster("Kahu", "Tank", "Phyllophages", 850, 500, 700, 50, Deepcopy(skills));
		monsters.Add(m);
		OneStarMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Tournsol
		// Create skills
		skills.Add(new Skill("Coud'queue", "CoudQueue", "Le lanceur attaque avec sa queue et baisse l'attaque de l'ennemi", 1, 1.25, 1, nb_turn_boost: 2, malus: new List<string>() { "attack" }));
		skills.Add(new Skill("Phytofouet", "Phytofouet", "Attaque tous les ennemis et réduit leur vitesse pendant 2 tours", 3, 1, 99, nb_turn_boost: 2, malus: new List<string>() { "speed" }));
		skills.Add(new Skill("Biscotto", "Biscotto", "Augmente l'attaque de tous les alliés", 4, 0, 99, false, new List<string>() { "attack", "defense" }, 2));

		m = new Monster("Tournsol", "Support", "Heliamphora", 750, 550, 800, 65, Deepcopy(skills));
		monsters.Add(m);
		OneStarMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Pizzaltère
		// Create skills
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Coud'tête", "CoudTete", "Inflige d'énormes dégâts mais augmente l'attaque de l'adversaire ciblé", 2, 3, boosts: new List<string>() { "attack" }, nb_turn_boost: 1));
		skills.Add(new Skill("Biscotto", "Biscotto", "Augmente l'attaque de tous les alliés", 4, 0, 99, false, new List<string>() { "attack", "defense" }, 2));

		m = new Monster("Pizzaltere", "Attaque", "Népenthès", 300, 850, 450, 80, Deepcopy(skills));
		monsters.Add(m);
		OneStarMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Cookocat
		// Create skills
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Biscotto", "Biscotto", "Augmente l'attaque de tous les alliés", 4, 0, 99, false, new List<string>() { "attack", "defense" }, 2));
		skills.Add(new Skill("Goûter", "Gouter", "Régénère la santé de tous les alliés de 50%", 4, 0.5, 99, false));

		m = new Monster("Cookocat", "Tank", "Népenthès", 850, 300, 650, 45, Deepcopy(skills), 2);
		monsters.Add(m);
		TwoStarsMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster T-Vert
		// Create skills
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Coud'tête", "CoudTete", "Inflige d'énormes dégâts mais augmente l'attaque de l'adversaire ciblé", 2, 3, boosts: new List<string>() { "attack" }, nb_turn_boost: 1));
		skills.Add(new Skill("Phytofouet", "Phytofouet", "Attaque tous les ennemis et réduit leur vitesse pendant 2 tours", 3, 1, 99, nb_turn_boost: 2, malus: new List<string>() { "speed" }));

		m = new Monster("T-Vert", "Attaque", "Heliamphora", 500, 1000, 350, 75, Deepcopy(skills), 3);
		monsters.Add(m);
		ThreeStarsMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Narvaleine
		// Create skills
		skills.Add(new Skill("Coud'queue", "CoudQueue", "Le lanceur attaque avec sa queue et baisse l'attaque de l'ennemi", 1, 1.25, 1, nb_turn_boost: 2, malus: new List<string>() { "attack" }));
		skills.Add(new Skill("Coud'tête", "CoudTete", "Inflige d'énormes dégâts mais augmente l'attaque de l'adversaire ciblé", 2, 3, boosts: new List<string>() { "attack" }, nb_turn_boost: 1));
		skills.Add(new Skill("Goûter", "Gouter", "Régénère la santé de tous les alliés de 50%", 4, 0.5, 99, false));

		m = new Monster("Narvaleine", "Tank", "Népenthès", 950, 450, 650, 35, Deepcopy(skills), 3);
		monsters.Add(m);
		ThreeStarsMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Killibunny
		// Create skills
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Coud'tête", "CoudTete", "Inflige d'énormes dégâts mais augmente l'attaque de l'adversaire ciblé", 2, 3, boosts: new List<string>() { "attack" }, nb_turn_boost: 1));
		skills.Add(new Skill("Goûter", "Gouter", "Régénère la santé de tous les alliés de 50%", 4, 0.5, 99, false));

		m = new Monster("Killibunny", "Attaque", "Népenthès", 300, 800, 300, 90, Deepcopy(skills));
		monsters.Add(m);
		OneStarMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Musculace
		// Create skills
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Coud'tête", "CoudTete", "Inflige d'énormes dégâts mais augmente l'attaque de l'adversaire ciblé", 2, 3, boosts: new List<string>() { "attack" }, nb_turn_boost: 1));
		skills.Add(new Skill("Poing Sombre", "PoingSombre", "Attaque un ennemi et diminue sa défense pendant 1 tour", 2, 1.5, 1, nb_turn_boost: 1, malus: new List<string>() { "defense" }));

		m = new Monster("Musculace", "Attaque", "Phyllophages", 450, 850, 400, 80, Deepcopy(skills));
		monsters.Add(m);
		OneStarMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Ninchat
		// Create skills
		skills.Add(new Skill("Coud'queue", "CoudQueue", "Le lanceur attaque avec sa queue et baisse l'attaque de l'ennemi", 1, 1.25, 1, nb_turn_boost: 2, malus: new List<string>() { "attack" }));
		skills.Add(new Skill("Coud'tête", "CoudTete", "Inflige d'énormes dégâts mais augmente l'attaque de l'adversaire ciblé", 2, 3, boosts: new List<string>() { "attack" }, nb_turn_boost: 1));
		skills.Add(new Skill("Biscotto", "Biscotto", "Augmente l'attaque de tous les alliés", 4, 0, 99, false, new List<string>() { "attack", "defense" }, 2));

		m = new Monster("Ninchat", "Support", "Népenthès", 650, 700, 1000, 75, Deepcopy(skills));
		monsters.Add(m);
		OneStarMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Panbone
		// Create skills
		skills.Add(new Skill("Coud'queue", "CoudQueue", "Le lanceur attaque avec sa queue et baisse l'attaque de l'ennemi", 1, 1.25, 1, nb_turn_boost: 2, malus: new List<string>() { "attack" }));
		skills.Add(new Skill("Poing Sombre", "PoingSombre", "Attaque un ennemi et diminue sa défense pendant 1 tour", 2, 1.5, 1, nb_turn_boost: 1, malus: new List<string>() { "defense" }));
		skills.Add(new Skill("Biscotto", "Biscotto", "Augmente l'attaque de tous les alliés", 4, 0, 99, false, new List<string>() { "attack", "defense" }, 2));

		m = new Monster("Panbone", "Support", "Heliamphora", 700, 750, 600, 50, Deepcopy(skills));
		monsters.Add(m);
		OneStarMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Phylofox
		// Create skills
		skills.Add(new Skill("Coud'queue", "CoudQueue", "Le lanceur attaque avec sa queue et baisse l'attaque de l'ennemi", 1, 1.25, 1, nb_turn_boost: 2, malus: new List<string>() { "attack" }));
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Phytofouet", "Phytofouet", "Attaque tous les ennemis et réduit leur vitesse pendant 2 tours", 3, 1, 99, nb_turn_boost: 2, malus: new List<string>() { "speed" }));

		m = new Monster("Phylofox", "Tank", "Heliamphora", 800, 300, 750, 45, Deepcopy(skills), 2);
		monsters.Add(m);
		TwoStarsMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Tronsopalin
		// Create skills
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Coud'tête", "CoudTete", "Inflige d'énormes dégâts mais augmente l'attaque de l'adversaire ciblé", 2, 3, boosts: new List<string>() { "attack" }, nb_turn_boost: 1));
		skills.Add(new Skill("Biscotto", "Biscotto", "Augmente l'attaque de tous les alliés", 4, 0, 99, false, new List<string>() { "attack", "defense" }, 2));

		m = new Monster("Tronsopalin", "Attaque", "Phyllophages", 350, 950, 250, 85, Deepcopy(skills), 2);
		monsters.Add(m);
		TwoStarsMonsters.Add(m);

		skills.Clear();
		#endregion

		#region Creating Monster Troon
		// Create skills
		skills.Add(new Skill("Croc-mal", "CrocMal", "Mord l'ennmi pour lui infliger des dégâts", 1, 1.3));
		skills.Add(new Skill("Poing Sombre", "PoingSombre", "Attaque un ennemi et diminue sa défense pendant 1 tour", 2, 1.5, 1, nb_turn_boost: 1, malus: new List<string>() { "defense" }));
		skills.Add(new Skill("Phytofouet", "Phytofouet", "Attaque tous les ennemis et réduit leur vitesse pendant 2 tours", 3, 1, 99, nb_turn_boost: 2, malus: new List<string>() { "speed" }));

		m = new Monster("Troon", "Tank", "Heliamphora", 1000, 500, 750, 30, Deepcopy(skills), 2);
		monsters.Add(m);
		TwoStarsMonsters.Add(m);

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
			copy.Add(new Skill(skill.getName(), skill.getIcon(), skill.getDescription(), skill.getInitialCooldown(), skill.getMultiplier(), skill.NbTouched, skill.DoDamage, skill.Boosts, skill.NbTurnBoost, skill.Malus));
		}
		return copy;
	}
}