﻿internal class Inventory


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
    }


    public void Delete(string name)
    {
        int id = FindByName(name);
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
        }
    }


    public void Use(string name)
    {
        int id = FindByName(name);
        if (id != -1)
        {
            Inv[id].Use();
            Delete(name);
        }

    }




}