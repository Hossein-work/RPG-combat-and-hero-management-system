class Tools
{
    internal static bool IsEndGame = false;
    internal static Dictionary<int, List<BaseClass>> number = new Dictionary<int, List<BaseClass>>()
    {
        {0,new List<BaseClass>()  },
        {1,new List<BaseClass>()  },
    };
    internal static void EndGameController()
    {
        Enemys();
        Heroes();
        void EndGame()
        {
            foreach (var item in number[0])
                item.cancellationTokenSource.Cancel();
            foreach (var item in number[1])
                item.cancellationTokenSource.Cancel();
            IsEndGame = true;
        }
        void Enemys()
        {
            foreach (var item in number[1])
            {
                if (item.NowHeath != 0)
                    return;
            }
            EndGame();
        }
        void Heroes()
        {
            foreach (var item in number[0])
            {
                if (item.NowHeath != 0)
                    return;
            }
            EndGame();
        }
    }
}
