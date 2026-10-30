foreach (string item in Enum.GetNames(typeof(Name)))
{
    Console.WriteLine($"Please enter Tools.number of {item}");
    int input = int.Parse(Console.ReadLine());
    for (int i = 0; i < input; i++)
        switch (item)
        {
            case "Warrior":
                Tools.number[0].AddRange(new Warrior());
                break;
            case "Mage":
                Tools.number[0].AddRange(new Mage());
                break;
            case "Archer":
                Tools.number[0].AddRange(new Archer());
                break;
            case "Goblin":
                Tools.number[1].Add(new Goblin());
                break;
            case "Boss":
                Tools.number[1].Add(new Boss());
                break;
        }
}
await PlayGame();
foreach (var item in Tools.number[0])
{
    Console.WriteLine(item.Name + item.NowHeath);
}
foreach (var item in Tools.number[1])
{
    Console.WriteLine(item.Name + item.NowHeath);
}
async Task PlayGame()
{
    Tools.number[(byte)TypeOfCharacter.Heroes].Sort((a, b) => b.MaxHeath.CompareTo(a.MaxHeath));
    Tools.number[(byte)TypeOfCharacter.Enemies].Sort((a, b) => b.MaxHeath.CompareTo(a.MaxHeath));
    List<Task> task = new List<Task>();

    foreach (Heroes hero in Tools.number[0])
    {
        task.Add(hero.Attack(Tools.number[(byte)TypeOfCharacter.Enemies]));
    }
    foreach (Enemies enemy in Tools.number[1])
    {
        task.Add(enemy.Attack(Tools.number[(byte)TypeOfCharacter.Heroes]));
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
