public abstract class TokenBase
{
    public string Name;
    public string Description;
    public Rarity Rarity;
    public bool IsPositive;
    public int MaxLevel;
    public float Timer;

    public int CurLevel;

    protected TokenController controller;

    public TokenBase(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel, float timer)
    {
        this.controller = controller;

        Name = name;
        Description = description;
        Rarity = rarity;
        IsPositive = isPositive;
        MaxLevel = maxLevel;
        Timer = timer;
    }

    public virtual void Use()
    {

    }
}
