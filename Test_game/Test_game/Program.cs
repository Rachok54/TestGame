Player player = new Player();
player.Name = "Artur";
Minion monster = new Monster();
Console.WriteLine(player.HP);
monster.Attack(player);
Console.WriteLine(player.HP);


