    internal class Minion
    {
        public string Name { get; set; } = "Minion";
        virtual public int HP { get; protected set; } = 100;
        public int atk = 10;
        
        public void Attack(Player person)
        {
        person.GetDamage(atk); 
        }

        public void GetDamage(int damage)
        {
            HP -= damage;
        }

    }
