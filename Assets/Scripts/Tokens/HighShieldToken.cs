

public class HighShieldToken : TokenBase
{
    private LifeController playerLife;
    private int remainingCount => playerLife.CurShield;
    
    public HighShieldToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        playerLife = controller.LifeController;
    }

    public override float Timer => 1 - remainingCount / (float)CurLevel;

    public override void OnStartStage()
    {
        base.OnStartStage();
        playerLife.CurShield = CurLevel;
    }
}