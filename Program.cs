foreach (string item in Enum.GetNames(typeof(Name)))
{
    Console.WriteLine($"Please enter Tools.number of {item}");
    int input = int.Parse(Console.ReadLine());
    for (int i = 0; i < input; i++)
        switch (item)
        {
            case "Warrior":
                Tools.AddToList(0,new Warrior());
                break;
            case "Mage":
                Tools.AddToList(0,new Mage());
                break;
            case "Archer":
                Tools.AddToList(0, new Archer());
                break;
            case "Goblin":
                Tools.AddToList(1, new Goblin());
                break;
            case "Boss":
                Tools.AddToList(1, new Boss());
                break;
        }
}
await PlayGame();
foreach (var item in Tools.GetList(0))
{
    Console.WriteLine(item.Name + item.NowHeath);
}
foreach (var item in Tools.GetList(1))
{
    Console.WriteLine(item.Name + item.NowHeath);
}
async Task PlayGame()
{
    Tools.GetList((byte)TypeOfCharacter.Heroes).Sort((a, b) => b.MaxHeath.CompareTo(a.MaxHeath));
    Tools.GetList((byte)TypeOfCharacter.Enemies).Sort((a, b) => b.MaxHeath.CompareTo(a.MaxHeath));
    List<Task> task = new List<Task>();

    foreach (Heroes hero in Tools.GetList(0))
    {
        task.Add(hero.Attack(Tools.GetList((byte)TypeOfCharacter.Enemies)));
    }
    foreach (Enemies enemy in Tools.GetList(1))
    {
        task.Add(enemy.Attack(Tools.GetList((byte)TypeOfCharacter.Heroes)));
    }
    await Task.WhenAll(task);
}
enum TypeOfCharacter
{
    Heroes,
    Enemies
}
enum Name
{
    Warrior,
    Mage,
    Archer,
    Goblin,
    Boss
}
