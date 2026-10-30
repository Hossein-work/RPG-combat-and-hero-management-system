class Mage : Heroes
{
    public Mage()
    {
        Name = "Mage";
        MaxHeath = 150;
        NowHeath = MaxHeath;

        superAttackCheck = true;
        superAttackDamage = 300;
        superAttackSpeed = 5000;
        amountOfEnergyConsumed = 50;

        maxEnergy = 100;
        nowEnergy = maxEnergy;

        attackCount = 6;
        AttackDamage = 80;
        AttackSpeed = 1500;
    }
}
