
internal class Player
{
    public string Name { get; set; } = "Minion";
    virtual public int HP { get; protected set; } = 100;
    private int atk = 10;



    public void Attack(Minion person)
    {
        person.GetDamage(atk);
    }

    public void GetDamage(int damage)
    {
        HP -= damage;
    }

    Item[] inv = new Item[50];

    void PushItem()
    { }
    void DropItem()
    { }
    void UseItem()
    { }
    void ShowItems()
    { }
}
