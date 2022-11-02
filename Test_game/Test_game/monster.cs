
    internal class Monster:Minion
    {
    public Monster(string name):base(name)
    {
        Name = name;
    }
    override public int HP { get; protected set; } = 50;

}
