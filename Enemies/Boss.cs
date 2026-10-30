class Boss : Enemies
{
    public Boss()
    {
        Name = "Boss";
        MaxHeath = 600;
        NowHeath = MaxHeath;

        superAttackCheck = true;
        superAttackDamage = 300;
        superAttackSpeed = 6000;
        amountOfEnergyConsumed = 50;

        maxEnergy = 150;
        nowEnergy = maxEnergy;

        attackCount = 6;
        AttackDamage = 150;
        AttackSpeed = 4500;
    }
}
