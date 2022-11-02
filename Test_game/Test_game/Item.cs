
   

    class Item
    {
        public string Name { get;}
        public int Koef { get; } 
        public string Description { get; }
    ///private int id ;

    public Item(string name, int koef, string desc)
        {
            Name = name;
            Koef = koef;
            Description = desc;
        }
        
        public virtual void Inf()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Description);
        }
        
        public virtual void Use()
        {
            Console.WriteLine($"Предмет {Name} использован(а)");
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
}


///Оружие
class Sword : Item
{
    static string type = "Sword";
    public Sword(string name, int armor, string desc) : base(name, armor, desc)
    {
    }

    public override void Use()
    {
        Player.SetDamage(Koef);
        base.Use();
    }

}



///Экип
class Armor : Item
{
    static string type = "Armor";
    public Armor(string name, int armor,string desc) : base(name,armor,desc)
    {
    }
    public override void Use()
    {
        Player.SetArmor(Koef);
        base.Use();
    }
}


///Лекарства
class Medicicne : Item
{
    static string type = "Medicine";
    public Medicicne(string name, int armor, string desc) : base(name, armor, desc)
    {
    }
    public override void Use()
    {
        Player.SetHP(Koef);
        base.Use();
    }

}



