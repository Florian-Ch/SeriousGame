public class Skill
{
    private static int idCounter = 0;
	private string name, icon;
	private int initialCooldown, cooldown, nbTouchedEnnemies, id;
	private double multiplier;

    public int Id { get => id; }

    public Skill(string _name, string _icon, int cd, double dmg, int nbTouchedennemies = 1)
	{
        idCounter++;
        id = idCounter;
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
