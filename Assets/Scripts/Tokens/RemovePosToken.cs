public class RemovePosToken : TokenBase
{
    private int randomIndex;
    public RemovePosToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
    }

    public override float Timer => 0;

    public override void Acquire()
    {
        base.Acquire();
        controller.DestroyOnePositiveToken();
    }
}
