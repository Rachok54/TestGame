internal class Inventory


{
    private Item[] Inv;

    public Inventory()
    {
        Inv = new Item[0];
    }


    public int FindByName(string name)
    {
        for (int i = 0; i < Inv.Length; ++i)
        {
            if (Inv[i].Name == name) return i;
        }
        Console.WriteLine("Такого предмета нет");
        return -1;
    }


    public void Add(Item item)
    {
        Item[] Inv1 = new Item[Inv.Length + 1];

        for (int i = 0; i < Inv.Length; ++i)
        {
            Inv1[i] = Inv[i];
        }

        Inv1[Inv1.Length - 1] = item;

        Inv = Inv1;
        Console.WriteLine($"Предмет {item.Name} добавлен в инвентарь");
    }


    public void Delete(int id)
    {
        id -= 1;
        if (id != -1)
        {
            Item[] Inv1 = new Item[Inv.Length - 1];
            int count = 0;

            for (int i = 0; i < Inv.Length; ++i)
            {
                if (i != id)
                {
                    Inv1[count] = Inv[i];
                    ++count;
                }

            }
            Inv = Inv1;
            Console.WriteLine($"Предмет удален из инвентаря");
        }
        
    }


    public void Use(int id)
    {
        int id1 = id-1;
        if (id1 != -1)
        {
            Inv[id1].Use();
            Delete(id);
        }

    }

    public void ShowInventory()
    {
        if(Inv.Length == 0) { Console.WriteLine("Инвентарь пустой"); }
        else
        {
            for (int i = 0; i < Inv.Length; ++i)
            {
                Console.Write($"{i + 1}Слот: ");
                Inv[i].Inf();
            }
        }
        

    }

    public int InvSize()
    {
        return Inv.Length;
    }
}