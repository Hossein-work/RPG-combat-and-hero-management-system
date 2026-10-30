class Warrior : Heroes
{
    public Warrior()
    {
        Name = "Warrior";
        MaxHeath = 500;
        NowHeath = MaxHeath;

        superAttackCheck = true;
        superAttackDamage = 250;
        superAttackSpeed = 5000;
        amountOfEnergyConsumed = 50;

        maxEnergy = 100;
        nowEnergy = maxEnergy;

        attackCount = 5;
        AttackDamage = 100;
        AttackSpeed = 5000;
    }
}
