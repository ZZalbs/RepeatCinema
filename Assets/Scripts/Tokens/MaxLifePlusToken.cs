public class MaxLifePlusToken : TokenBase
{
    public MaxLifePlusToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {

    }

    public override float Timer => 0;

    public override void LevelUp()
    {
        base.LevelUp();

        controller.LifeController.MaxLife++;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        controller.LifeController.MaxLife = 1;
        controller.LifeController.CurLife = 1;
    }

}
