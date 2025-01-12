using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastMercyToken : TokenBase
{
    private StageController stageController;
    private LifeController playerLife;

    // Update is called once per frame
    public override float Timer => 0f;

    public LastMercyToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        stageController = controller.StageController;
        playerLife = controller.LifeController;
    }
    
    public override void Acquire()
    {
        base.Acquire();
        playerLife.onDead += Revive;
    }
    
    public override void OnDestroy()
    {
        base.OnDestroy();
        playerLife.onDead -= Revive;
    }

    private void Revive()
    {
        playerLife.Init();
        controller.DestroyAllPositiveToken();
        stageController.Revive();
    }
}
