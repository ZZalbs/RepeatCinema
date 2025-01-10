public class MaxLifePlusToken : TokenBase
{
    public MaxLifePlusToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {

    }

    public override float Timer => 0;

    public override void Acquire()
    {
        controller.LifeController.MaxLife++;
    }
}
