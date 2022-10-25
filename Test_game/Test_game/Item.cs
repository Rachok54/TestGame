
    





    class Item
    {
        public string Name { get;}
        ///private int id ;
        
        public Item(string name)
        {
            Name = name;
        }
        
        public virtual void Inf()
        {
            Console.WriteLine(Name);
        }
        
        public virtual void Use()
        {
            Console.WriteLine($"Предмет {Name} использован");
        }
    }
