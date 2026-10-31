class BaseClass
{
    private protected int maxEnergy;
    private protected int nowEnergy;
    private protected bool superAttackCheck;
    private int maxHeath;
    private int nowHeath;
    private int attackDamage;
    private protected int superAttackDamage;
    private bool isEleminated;
    private int attackSpeed;
    private protected int superAttackSpeed;
    private protected int attackCount;
    private protected int amountOfEnergyConsumed;
    private string name;
    internal string Name { get => name; set => name = value; }
    internal CancellationTokenSource cancellationTokenSource;

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
            int n = CheckInput(value);
            Random r = new Random();

            attackSpeed = r.Next(n - 100, n + 100);
        }
    }

    internal int NowHeath { get => nowHeath; set => nowHeath = value; }

    int CheckInput(int value)
    {
        if (value > 0)
            return value;
        else throw new ApplicationException("Cannot be Less than 0");
    }

    public BaseClass()
    {
        cancellationTokenSource = new CancellationTokenSource();
        isEleminated = false;
    }
    int n = 0;
    internal async Task Attack(List<BaseClass> Characters)
    {
        while (!Tools.IsEndGame)
        {
            if (superAttackCheck)
            {
                for (int i = 0; i < attackCount; i++)
                {
                    await AttackController(Characters);
                }
                if (nowEnergy >= amountOfEnergyConsumed)
                {
                    if (isEleminated == false)
                    {
                        try
                        {
                            await Task.Delay(superAttackSpeed, cancellationTokenSource.Token);
                            if (Characters[n].isEleminated == false)
                            {

                                SuperAttack(Characters);

                            }
                            else
                            {
                                n++;
                                if (n >= Characters.Count)
                                {
                                    cancellationTokenSource.Cancel();
                                    return;
                                }
                            }
                        }
                        catch
                        {
                            return;
                        }
                    }
                    else return;
                }
            }
            else
            {
                await AttackController(Characters);

            }
        }

    }
    private async Task AttackController(List<BaseClass> Characters)
    {
        void Attack()
        {
            if (Characters[n].isEleminated == false)
            {
                PrintColor(Name+ (n+1), "\u001b[32m");
                Characters[n].ReceiveDamage(AttackDamage);
            }
            else
            {
                n++;
                if (n >= Characters.Count)
                {
                    cancellationTokenSource.Cancel();
                    return;
                }
                Attack();
            }
        }
        if (isEleminated == false)
        {
            try
            {
                await Task.Delay(AttackSpeed, cancellationTokenSource.Token);
                Attack();
            }
            catch
            {
                return;
            }
        }
        else
            return;
    }
    protected static void PrintColor(string text, string color)
    {
        Console.WriteLine($"{color}{text}\u001b[0m");
    }
    private protected virtual void SuperAttack(List<BaseClass> Character)
    {
        PrintColor(Name + "superrr", "\u001b[32m");
        Character[0].ReceiveDamage(AttackDamage);
        nowEnergy -= amountOfEnergyConsumed;

    }

    internal void ReceiveDamage(int damageValue)
    {
        if (isEleminated == false)
        {
            NowHeath -= damageValue;
            if (NowHeath <= 0)
            {
                isEleminated = true;
                cancellationTokenSource.Cancel();
                NowHeath = 0;
                Tools.EndGameController();
            }
        }
        PrintColor(Name + NowHeath, "\u001b[31m");
    }

}
