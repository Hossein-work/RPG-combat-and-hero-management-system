class Enemies : BaseClass
{
    protected override void ReceiveDamage()
    {
        isEleminated = true;
        cancellationTokenSource.Cancel();
        NowHeath = 0;
        Tools.EndGameController_Enemies();
    }
}
