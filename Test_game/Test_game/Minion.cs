    internal class Minion
    {
        public string Name { get; set; } = "Minion";
        virtual public int HP { get; protected set; } = 100;
        public int atk = 10;
        
        public Minion(string name)
    {
        Name = name;
    }
        public void Attack(Player person)
        {
        person.GetDamage(atk); 
        }

        public void GetDamage(int damage)
        {
            HP -= damage;
        }

        public void Info()
        {
        Console.WriteLine($"Имя:{Name},ХП:{HP},Атака:{atk}");
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
}
