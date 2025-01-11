public enum DamageType
{
    Normal,
    Critical,
    Death,
}

public enum BehaviourType
{
    LMove,
    RMove,
    Jump,
    Flash,
}

public enum Rarity
{
    Common,
    Rare,
    Epic,
    Legendary
}
public enum StageEventType
{
    Awake,
    Start,
    Clear,
    Revive,
    Over,
}

public enum Theme
{
    Country,
    Cosmic,
    Apocalypse,
}

public struct TokenPair
{
    public TokenBase PositiveToken;
    public TokenBase NegativeToken;
}