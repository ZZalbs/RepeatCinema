public class TokenBase
{
    public string Name;
    public string Description;
    public Rarity Rarity;
    public bool IsPositive;

    public int MaxLevel;
    public int CurLevel;

    public float Timer;

    public virtual void Use()
    {

    }
}
