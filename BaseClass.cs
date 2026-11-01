using System.Runtime.InteropServices.Marshalling;

class BaseClass
{
    private protected int maxEnergy;
    private protected int nowEnergy;
    private protected bool superAttackCheck;
    private float maxHeath;
    private float nowHeath;
    private float attackDamage;
    private protected int superAttackDamage;
    protected bool isEleminated;
    private int attackSpeed;
    private protected int superAttackSpeed;
    private protected int attackCount;
    private protected int amountOfEnergyConsumed;
    private string name;
    public string Name { get => name; protected set => name = value; }
    internal CancellationTokenSource cancellationTokenSource;

    public float AttackDamage
    {
        get => attackDamage;
        set
        {
            attackDamage = CheckInput(value);
        }
    }

    public float MaxHeath
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
            if (value > 100)
            {
                Random r = new Random();

                attackSpeed = r.Next(value - 100, value + 100);
            }
            else throw new ApplicationException("Cannot be Less than 101");

        }
    }

    internal float NowHeath { get => nowHeath; set => nowHeath = value; }

    float CheckInput(float value)
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
        void Attack()
        {
            if (Characters[n].isEleminated == false)
            {
                Tools.PrintColor(Name + (n + 1), "\u001b[32m");
                Characters[n].SendDamage(AttackDamage);
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
    }
    
    private protected virtual void SuperAttack(List<BaseClass> Character)
    {
        Tools.PrintColor(Name + "superrr", "\u001b[32m");
        Character[0].SendDamage(AttackDamage);
        nowEnergy -= amountOfEnergyConsumed;

    }

    internal void SendDamage(float damageValue)
    {
        if (isEleminated == false)
        {
            NowHeath -= damageValue;
            if (NowHeath <= 0)
            {
                ReceiveDamage();
            }
        }
        Tools.PrintColor(Name + NowHeath, "\u001b[31m");
    }
    protected virtual void ReceiveDamage()
    {
        isEleminated = true;
        cancellationTokenSource.Cancel();
        NowHeath = 0;
        Tools.EndGameController();
    }

}
