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
        while (isEleminated == false)
        {
            if (superAttackCheck)
            {
                for (int i = 0; i < attackCount; i++)
                {
                    await Task.Delay(AttackSpeed);

                    Characters[0].ReceiveDamage(AttackDamage);

                    Console.WriteLine(Name);
                }
                if (nowEnergy >= amountOfEnergyConsumed)
                    await SuperAttack(Characters);
            }
            else
            {
                await Task.Delay(AttackSpeed);

                Characters[0].ReceiveDamage(AttackDamage);

                Console.WriteLine(Name);
            }
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
        {
            isEleminated = true;
            nowHeath = 0;
        }
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
class Gobline : Enemies
{
    public Gobline()
    {
        MaxHeath = 80;
        nowHeath = MaxHeath;

        superAttackCheck = false;

        AttackDamage = 40;
        AttackSpeed = 500;
    }
}
class Boss : Enemies
{
    public Boss()
    {
        MaxHeath = 600;
        nowHeath = MaxHeath;

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
        MaxHeath = 150;
        nowHeath = MaxHeath;

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
class Archer : Heroes
{
    public Archer()
    {
        MaxHeath = 100;
        nowHeath = MaxHeath;

        superAttackCheck = true;
        superAttackDamage = 50;
        superAttackSpeed = 5000;
        amountOfEnergyConsumed = 20;

        maxEnergy = 100;
        nowEnergy = maxEnergy;

        attackCount = 4;
        AttackDamage = 50;
        AttackSpeed = 1000;
    }
}
