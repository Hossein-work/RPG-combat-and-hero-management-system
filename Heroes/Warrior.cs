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
        amountOfManaConsumed = 50;

        maxMana = 100;
        nowMana = maxMana;

        attackCount = 5;
        AttackDamage = 100;
        AttackSpeed = 5000;
    }
}
