using System.ComponentModel.Design;

partial class Heroes : BaseClass
{

    protected override void ReceiveDamage()
    {
        if (isEleminated == false && NowHeath != MaxHeath)
        {
            if (Potions.HealthPotion(Name))
            {
                NowHeath = MaxHeath;
            }
            else
            {
                isEleminated = true;
                cancellationTokenSource.Cancel();
                NowHeath = 0;
                Tools.EndGameController_Heroes();
            }
        }
    }
    protected override bool IsExistEnoughMana()
    {
        if (nowMana >= amountOfManaConsumed)
            return true;
        else if (Potions.ManaPotion(Name))
        {
            nowMana = maxMana;
            return true;
        }
        else return false;
    }

}
