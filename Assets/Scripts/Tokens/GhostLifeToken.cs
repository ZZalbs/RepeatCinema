using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GhostLifeToken : TokenBase
{
    private UnityAction onHit;
    
    public GhostLifeToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {                
    }



    public override float Timer => 0;
    
    public override void Acquire()
    {
        base.Acquire();
        var controllerLifeController = controller.LifeController;
        onHit += () =>
        {
            controllerLifeController.CurLife++;
            if (CurLevel > 2) CurLevel--;
            else controller.DestroyToken(this);
        };
        
        controllerLifeController.onHit += onHit;
    }
    
    public override void OnDestroy()
    {
        controller.LifeController.onHit -= onHit;
    }
}
