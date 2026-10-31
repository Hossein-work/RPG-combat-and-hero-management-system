class Heroes : BaseClass
{
    private bool usePotion;
    private const float percentageOfPowerIncrease = 1.5f;
    protected bool HealthPotion()
    {
        if (Tools.PotionNumber[(byte)Tools.Potions.Health] > 0 && !usePotion)
        {
            Tools.UsePotion(Tools.Potions.Health);
            NowHeath = MaxHeath;
            return true;
        }    
        else return false;
    }
    protected bool ManaPotion()
    {
        if (Tools.PotionNumber[(byte)Tools.Potions.Mana] > 0 && !usePotion)
        {
            Tools.UsePotion(Tools.Potions.Mana);
            nowEnergy = maxEnergy;
            return true;
        }
        else return false;
    }
    protected bool WeaponPotion()
    {
        if (Tools.PotionNumber[(byte)Tools.Potions.Health] > 0 && !usePotion)
        {
            Tools.UsePotion(Tools.Potions.Health);
            AttackDamage *= percentageOfPowerIncrease;
            return true;
        }
        else return false;
    }
}
