static class Potions 
{
    private static bool usePotion;
    private const float percentageOfPowerIncrease = 50;
    internal static bool HealthPotion(in string name)
    {
        if (Tools.PotionNumber[(byte)Tools.Potions.Health] > 0)
        {
            usePotion = true;
            Tools.PrintColor("Heals " + name, "\u001b[33m");
            Tools.UsePotion(Tools.Potions.Health);

            return true;
        }
        else return false;
    }
    internal static bool ManaPotion(in string name)
    {
        if (Tools.PotionNumber[(byte)Tools.Potions.Mana] > 0 && !usePotion)
        {
            usePotion = true;
            Tools.PrintColor("Mana " + name, "\u001b[33m");
            Tools.UsePotion(Tools.Potions.Mana);
            return true;
        }
        else return false;
    }
    internal static bool WeaponPotion(ref float attackDamage)
    {
        if (Tools.PotionNumber[(byte)Tools.Potions.Health] > 0 && !usePotion)
        {
            usePotion = true;
            Tools.UsePotion(Tools.Potions.Health);
            attackDamage += attackDamage * (percentageOfPowerIncrease / 100);
            return true;
        }
        else return false;
    }
}


