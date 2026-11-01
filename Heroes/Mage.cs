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
        amountOfManaConsumed = 50;

        maxMana = 100;
        nowMana = maxMana;

        attackCount = 6;
        AttackDamage = 80;
        AttackSpeed = 1500;
    }
}
