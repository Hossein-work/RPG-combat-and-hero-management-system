class BaseClass
{
    private int maxHeath;
    private int nowHeath;
    private int attackDamage;
    private bool isEleminated;
    private int attackSpeed;
    public readonly string Name;

    public int NowHeath { get => nowHeath; }
    public int AttackDamage { get => attackDamage;
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

    public BaseClass(string name, int damage, int maxHeath, int attackSpeed)
    {
        MaxHeath = maxHeath;
        nowHeath = maxHeath;
        Name = name;
        AttackDamage = damage;
        isEleminated = false;
        AttackSpeed = attackSpeed;
    }
    internal async Task Attack(BaseClass Character)
    {
        while (true)
        {
            await Task.Delay(AttackSpeed);
            Character.ReceiveDamage(AttackDamage);
            Console.WriteLine("attack");
        }
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
    private readonly int maxEnergy;
    private int nowEnergy;
    public Heroes(string name, int damage, int maxHeath, int maxEnergy, int attackSpeed) : base(name, damage, maxHeath, attackSpeed)
    {
        this.maxEnergy = maxEnergy;
        nowEnergy = maxEnergy;
    }
}
class Enemies : BaseClass
{
    public Enemies(string name, int damage, int maxHeath, int attackSpeed) : base(name, damage, maxHeath, attackSpeed)
    {
    }
}
