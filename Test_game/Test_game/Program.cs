Player player = new Player();
player.Name = "Artur";
///типа сразу создается наш перс



Minion[] monsters = new Minion[3];///это черновой массив с разными существующими в игре монстрами из которых рандомом спавнится один, их надо бы запихнуть в отдельный текстовый файл
monsters[0] = new Minion("Монстр1");
monsters[1] = new Minion("Монстр2");
monsters[2] = new Minion("Монстр3");



///надо запихнуть все эти данные в текстовый документ и по надобности читать оттуда, слишком много ресурсов используется сейчас для хранения этого массива
Item[][] items = new Item[3][];///это по аналогии с монстрами, только различные предметы, сделаны с помощью массива массивов
items[0] = new Item[] { new Sword("Нож", 10, "Это холодное оружие - Нож. Имеет +10 урон, отлично подойдет если вы Чикатило."), new Sword("Меч", 20, "Это холодное оружие - Меч. Имеет +20 урон, отлично подойдет если вы из 19 века."), new Sword("Наган", 30, "Это огнестрел - Наган. Имеет +30 урон, хороший выбор.") };
items[1] = new Item[] { new Armor("Шлем", 10, "Это Шлем. Имеет +10 брони, слабо защищает"), new Armor("Дырявые носки", 20, "Это дырявые носки. Имеет +20 защиты, не многие решатся напасть на вас благодаря неповторимому аромату"), new Armor("Кожанка панка", 30, "Это лучший доспех - Кожанка панка. Имеет +30 к защите, ее невозможно прорвать или сжечь, хороший выбор.") };
items[2] = new Item[] { new Medicicne("Аптечка советская", 10, "Это обыкновенная советская аптечка. Восстанавливает +10 HP.")};

Item GenerationItem()///метод служащий для генерации случайного предмета из массива всех предметов(который выше)
{
    Random rnd = new Random();
    //Получить случайное число 
    int x = rnd.Next(0, 2);
    int y = rnd.Next(0, items[x].Length);
    Item clone = (Item) items[x][y].Clone();///поверхностное копирование, возможно не прокатит так как вложенные типы, скорее всего надо глубокое деать
    return clone;

}
Minion GenerationMonster()///соотвественно генерация монстра из массива моснтров(тот что выше)
{
    Random rnd = new Random();
    //Получить случайное число
    int x = rnd.Next(0, 2);
    Minion clone = (Minion)monsters[x].Clone();///здесь поверхностоное копирование объекта из массива выше,чтобы он в том массиве существующих монстров не менялся
    return clone;
    ///можно еще тут добавить тоже рандом - будет ли монстр первым атаковать или нет

}


void Battle(Minion monster, Player player)///метод, который имитирует бой между нами и монстром(я его сдела автоматическим пока что, ибо не вижу смысла ручным делать, все равно все по очереди
{
    while(Player.HP > 0&& monster.HP > 0)
    {
        Console.WriteLine($"У вас:{Player.HP}, у монстра:{monster.HP}");
        Console.WriteLine("Вы атакуете");
        player.Attack(monster);
        Console.WriteLine($"У вас:{Player.HP}, у монстра:{monster.HP}");
        if (monster.HP > 0)
        {
            monster.Attack(player);
            Console.WriteLine("Монстр атакует");
        }
        else break;
    }

    if (Player.HP > 0 && monster.HP <= 0)
    {
        Console.WriteLine("Вы победили");
    }
    else
    {
        Console.WriteLine("Вы проиграли");
        throw (new Exception("Вы проиграли"));
    }
}

bool Interactive(Item? item,Minion? monster)///метод с помощью которого мы выбираем текущее действие
{
    Console.WriteLine("Выберите действие: 1.Идти 2.Взаимодействовать 3.Показать инвентарь 4.Показать инфо о себе 5.Закончить игру");
    int x;
    while(true)
    {
        int y = Convert.ToInt32(Console.ReadLine());
        if(y > 0 && y<6)
        {
            x = y;
            break;
        }
    }
    
    switch (x)
    {
        case 1:
            {
                return false;
            }
        case 2:
            {
                if(monster == null&& item!= null)
                {
                    player.inventory.Add(item);
                    ///player.inventory.Use(item.Name);-нужно реализовать из инвентаря
                }
                else if(monster!=null&&item==null)
                {
                   Battle(monster, player);     
                }
                else
                {
                    Console.WriteLine("Не с чем взаимодействовать");
                }
                return false;
            }
        case 3:
            {
                player.inventory.ShowInventory();
                Console.WriteLine("Для использования предмета напишите его номер. Для выхода из инвентаря напишите 0.");
                int n;
                while (true)
                {
                    
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n >= 0 && n <= player.inventory.InvSize())
                    {
                        break;
                    }
                }
                if(n != 0)
                {
                    player.inventory.Use(n);
                }
                return true;
            }
        case 4:
            {
                player.Info();
                return true;
            }
        case 5:
            {
                throw (new Exception("Вы закончили игру"));
            }
    }
    return true;
}






Item? it = null;
Minion? mon = null;

try///я проигыш решил с помощью трай кетч ловить, а то слишком много кода будет если во всей цепочке вызовов это отрабатывать. Только может быть, более конкретный тип ошибки стоит сделать.
{
    while (true)
    {
        bool repeat = Interactive(it, mon);
        if (!repeat)
        {
            it = null;
            mon = null;
            Random rnd = new Random();
            //Получить случайное число
            int x = rnd.Next();

            if (x % 2 == 0)
            {
                mon = GenerationMonster();
                mon.Info();
            }
            else
            {
                it = GenerationItem();
                it.Inf();
            }
        }
       
        
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex);
}
