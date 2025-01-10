public abstract class TokenBase
{
    public int Id;
    public string Name;
    public string Description;
    public Rarity Rarity;
    public bool IsPositive;
    public int MaxLevel;
    public abstract float Timer { get; }

    public int CurLevel;

    protected TokenController controller;

    public TokenBase(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel)
    {
        this.controller = controller;
        CurLevel = 1;
        Name = name;
        Description = description;
        Rarity = rarity;
        IsPositive = isPositive;
        MaxLevel = maxLevel;
    }

    public void LevelUp()
    {
        CurLevel++;
    }

    public virtual void Acquire()
    {
    }

    public virtual void Update()
    {

    }
}
