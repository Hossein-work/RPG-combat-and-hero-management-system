class Archer : Heroes
{
    public Archer()
    {
        Name = "Archer";
        MaxHeath = 100;
        NowHeath = MaxHeath;

        superAttackCheck = true;
        superAttackDamage = 50;
        superAttackSpeed = 5000;
        amountOfManaConsumed = 20;

        maxMana = 100;
        nowMana = maxMana;

        attackCount = 4;
        AttackDamage = 50;
        AttackSpeed = 1000;
    }
    private protected override void SuperAttack(List<BaseClass> Character)
    {
        Tools.PrintColor(Name + "superrr", "\u001b[32m");
        foreach (BaseClass c in Character)
        {
            c.SendDamage(AttackDamage);
        }

        nowMana -= amountOfManaConsumed;
    }
}
