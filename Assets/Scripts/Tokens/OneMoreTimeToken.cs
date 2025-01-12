using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneMoreTime : TokenBase
{
    private StageController stageController;
    private LifeController playerLife;

    // Update is called once per frame
    public override float Timer => 0f;

    public OneMoreTime(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        stageController = controller.StageController;
        playerLife = controller.LifeController;
    }
    
    public override void Acquire()
    {
        base.Acquire();
        playerLife.onHit += Revive;
    }
    
    public override void OnDestroy()
    {
        base.OnDestroy();
        playerLife.onHit -= Revive;
    }

    private void Revive()
    {
        if (playerLife.CurLife > 0) return;

        controller.DestroyAllNegativeToken();
        controller.DestroyAllPositiveToken();
        stageController.Revive();
    }
}
