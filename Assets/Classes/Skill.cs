using System.Collections.Generic;

public class Skill
{
    private static int idCounter = 0;
	private string name, icon;
	private int initialCooldown, cooldown, nbTouched, id, nbTurnBoost;
	private double multiplier;
	private bool doDamage;
	private List<string> boosts, malus;

    public int Id { get => id; }
	public int NbTouched { get => nbTouched; set => nbTouched = value; }
	public bool DoDamage { get => doDamage; set => doDamage = value; }
	public List<string> Boosts { get => boosts; set => boosts = value; }
	public List<string> Malus { get => malus; set => malus = value; }
	public int NbTurnBoost { get => nbTurnBoost; set => nbTurnBoost = value; }

	public Skill(string _name, string _icon, int cd, double dmg, int nb_touched = 1, bool do_damage = true, List<string> boosts = null, int nb_turn_boost = 0, List<string> malus = null)
	{
        idCounter++;
        id = idCounter;
		name = _name;
		icon = _icon;
		initialCooldown = cd;
		multiplier = dmg;
		nbTouched = nb_touched;
		cooldown = 1;
		doDamage = do_damage;
		this.boosts = boosts != null ? boosts : new List<string>();
		NbTurnBoost = nb_turn_boost;
		this.malus = malus != null ? malus: new List<string>();
	}

	public string getName() { return name; }

	public string getIcon() { return icon; }

	public int getInitialCooldown() { return initialCooldown; }

	public int getCooldown() { return cooldown; }

	public void setCooldown(int cd) { cooldown = cd; }

	public double getMultiplier() { return multiplier; }

}
