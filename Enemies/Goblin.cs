class Goblin : Enemies
{
    public Goblin()
    {
        Name = "Gobline";
        MaxHeath = 80;
        NowHeath = MaxHeath;

        superAttackCheck = false;

        AttackDamage = 20;
        AttackSpeed = 500;
    }
}
