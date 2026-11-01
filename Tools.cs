static class Tools
{
    internal static bool IsEndGame = false;
    private static Dictionary<int, List<BaseClass>> number = new Dictionary<int, List<BaseClass>>()
    {
        {0,new List<BaseClass>()  },
        {1,new List<BaseClass>()  },
    };
    internal static List<BaseClass> GetList(byte key) => number[key];
    internal static void AddToList(int key, BaseClass value)
    {
        number[key].Add(value);
    }
    private static List<int> potionNumber = new List<int>()
    {
        10,1,1
    };
    public static IReadOnlyList<int> PotionNumber => potionNumber.AsReadOnly();
    internal static void UsePotion(Potions type) => potionNumber[(byte)type] -= 1;
    internal enum Potions
    {
        Health,
        Mana,
        Weapon
    }
    internal static void EndGameController_Enemies()
    {

        foreach (var item in number[1])
        {
            if (item.NowHeath != 0)
                return;
        }
        EndGame();

    }
    internal static void EndGameController_Heroes()
    {

        foreach (var item in number[0])
        {
            if (item.NowHeath != 0)
                return;
        }
        EndGame();

    }
    private static void EndGame()
    {
        foreach (var item in number[0])
            item.cancellationTokenSource.Cancel();
        foreach (var item in number[1])
            item.cancellationTokenSource.Cancel();
        IsEndGame = true;
    }
    internal static void PrintColor(string text, string color)
    {
        Console.WriteLine($"{color}{text}\u001b[0m");
    }
}
