
internal class Player
{
    public string Name { get; set; } = "Minion";
    static public int HP { get; protected set; } = 100;
    static private int Armor = 0;
    static private int Damage = 10;
    public Inventory inventory = new Inventory();



    public void Attack(Minion person)
    {
        person.GetDamage(Damage);
    }

    public void GetDamage(int damage)
    {
        HP -= (damage-(damage/100*Armor));
        Armor -= damage;
    }


    ///
    static public void SetDamage(int num)
    {
        Damage += num;
    }

    static public void SetArmor(int num)
    {
        Armor += num;
    }

    static public void SetHP(int num)
    {
        int newHP = HP + num;
        if(newHP >=100) HP = 100;
        else HP = newHP;
    }

    public void Info()
    {
        Console.WriteLine($"Имя:{Name},Здоровье{HP},Броня{Armor},Урон{Damage}");
    }
}
