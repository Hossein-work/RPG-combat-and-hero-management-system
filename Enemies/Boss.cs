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
        amountOfManaConsumed = 50;

        maxMana = 150;
        nowMana = maxMana;

        attackCount = 6;
        AttackDamage = 150;
        AttackSpeed = 4500;
    }
}
