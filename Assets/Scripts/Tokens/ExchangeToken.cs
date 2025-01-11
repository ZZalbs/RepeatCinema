using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExchangeToken : TokenBase
{
    private LifeController playerLife;
    private UnityAction onHit;
    
    public ExchangeToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        playerLife = controller.LifeController;
    }

    public override float Timer => 0;

    public override void Acquire()
    {
        onHit = () =>
        {
            playerLife.CurLife++;
            controller.DestroyOnePositiveToken();
            controller.DestroyToken(this);
        };
        playerLife.onHit += onHit;
    }
    
    public override void OnDestroy()
    {
        playerLife.onHit -= onHit;
    }
}
