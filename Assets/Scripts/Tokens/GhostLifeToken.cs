using UnityEngine.Events;

public class GhostLifeToken : TokenBase
{
    public GhostLifeToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
    }



    public override float Timer => 0;
    
    public override void Acquire()
    {
        base.Acquire();

        controller.LifeController.onHit += OnHit;
    }
    
    public override void OnDestroy()
    {
        base.OnDestroy();

        controller.LifeController.onHit -= OnHit;
    }

    private void OnHit()
    {
        controller.LifeController.CurLife++;
        if (CurLevel > 2) CurLevel--;
        else controller.DestroyToken(this);
    }
}
