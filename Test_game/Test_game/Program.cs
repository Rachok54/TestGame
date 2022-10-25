Player player = new Player();
player.Name = "Artur";
Minion monster = new Monster();
Console.WriteLine(player.HP);
monster.Attack(player);
Console.WriteLine(player.HP);


Item sword = new Item("sword");
player.inventory.Add(sword);
player.inventory.ShowInventory();
player.inventory.Use(sword.Name);
player.inventory.ShowInventory();


