using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysCriticalToken : TokenBase
{
    private LifeController playerLife;
    
    // Update is called once per frame
    public override float Timer => 0;

    public AlwaysCriticalToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        
    }

    private void Critical()
    {
        playerLife.CurLife++;
        playerLife.OnDamaged(DamageType.Critical);
    }

    public override void Acquire()
    {
        base.Acquire();
        controller.LifeController.onHit += Critical;
    }
    
    public override void OnDestroy()
    {
        controller.LifeController.onHit -= Critical;
    }
}
