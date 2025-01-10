public class MaxLifePlusToken : TokenBase
{
    public MaxLifePlusToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel, float timer) : base(controller, name, description, rarity, isPositive, maxLevel, timer)
    {

    }

    public override void Use()
    {
        controller.LifeController.MaxLife++;
    }
}
