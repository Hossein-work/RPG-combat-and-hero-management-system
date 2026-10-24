BaseClass a = new Warrior();
BaseClass b = new Warrior();
await a.Attack(b);
class BaseClass
{
    private protected int maxEnergy;
    private protected int nowEnergy;
    private protected bool superAttackCheck;
    private int maxHeath;
    private protected int nowHeath;
    private int attackDamage;
    private protected int superAttackDamage;
    private bool isEleminated;
    private int attackSpeed;
    private protected int superAttackSpeed;
    private protected int attackCount;
    private protected int amountOfEnergyConsumed;
    public readonly string Name;

    public int AttackDamage
    {
        get => attackDamage;
        set
        {
            attackDamage = CheckInput(value);
        }
    }

    public int MaxHeath
    {
        get
        {
            return maxHeath;
        }
        set
        {
            maxHeath = CheckInput(value);
        }
    }

    public int AttackSpeed
    {
        get => attackSpeed;
        set
        {
            attackSpeed = CheckInput(value);
        }
    }

    int CheckInput(int value)
    {
        if (value > 0)
            return value;
        else throw new ApplicationException("Cannot be Less than 0");
    }

    public BaseClass()
    {
        isEleminated = false;
    }
    internal async Task Attack(params BaseClass[] Characters)
    {
        while (true)
        {
            for (int i = 0; i < attackCount; i++)
            {
                await Task.Delay(AttackSpeed);

                Characters[0].ReceiveDamage(AttackDamage);

                Console.WriteLine("attack");
            }
            if (superAttackCheck && nowEnergy >= amountOfEnergyConsumed)
                await SuperAttack(Characters);
        }
    }
    private protected virtual async Task SuperAttack(BaseClass[] Character)
    {
        await Task.Delay(superAttackSpeed);
        foreach (var item in Character)
        {
            item.ReceiveDamage(AttackDamage);
        }
        nowEnergy -= amountOfEnergyConsumed;
    }


    internal void ReceiveDamage(int damageValue)
    {
        if (nowHeath <= 0)
            isEleminated = true;
        else
            nowHeath -= damageValue;
    }

}

class Heroes : BaseClass
{

}
class Enemies : BaseClass
{

}
class Warrior : Heroes
{
    private protected override async Task SuperAttack(BaseClass[] Character)
    {
        await Task.Delay(superAttackSpeed);

        Character[0].ReceiveDamage(AttackDamage);
        Console.WriteLine("Super");
        nowEnergy -= amountOfEnergyConsumed;
    }
    public Warrior()
    {
        MaxHeath = 500;
        nowHeath = MaxHeath;

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
class Mage : Heroes
{
    public Mage()
    {

    }
}
class Archer : Heroes
{
    public Archer()
    {
        maxEnergy = 80;
        nowEnergy = maxEnergy;
    }
}
