public class Skill {
	private string name, icon;
	private int initialCooldown, cooldown, nbTouchedEnnemies;
	private double multiplier;

	public Skill(string _name, string _icon, int cd, double dmg, int nbTouchedennemies = 1)
	{
		name = _name;
		icon = _icon;
		initialCooldown = cd;
		multiplier = dmg;
		nbTouchedEnnemies = nbTouchedennemies;
		cooldown = 1;
	}

	public string getName() { return name; }

	public string getIcon() { return icon; }

	public int getInitialCooldown() { return initialCooldown; }

	public int getCooldown() { return cooldown; }

	public void setCooldown(int cd) { cooldown = cd; }

	public double getMultiplier() { return multiplier; }

}
