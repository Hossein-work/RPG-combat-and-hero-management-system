using System.ComponentModel.Design;

class Heroes : BaseClass
{
    private bool usePotion;
    private const float percentageOfPowerIncrease = 50;
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
            AttackDamage += AttackDamage * (percentageOfPowerIncrease / 100);
            return true;
        }
        else return false;
    }

    protected override void ReceiveDamage()
    {
        if (HealthPotion())
        {
            Tools.PrintColor("Heals " + Name, "\u001b[33m");
        }
        else
        {
            isEleminated = true;
            cancellationTokenSource.Cancel();
            NowHeath = 0;
            Tools.EndGameController();
        }
    }
}
