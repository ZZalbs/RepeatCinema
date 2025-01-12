using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleToken : TokenBase
{
    private float invincibleTime => 3 + 0.5f * (CurLevel - 1);
    private float timeCounter = 0f;

    private LifeController playerLife;

    public InvincibleToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        playerLife = controller.LifeController;
        timeCounter = 0;
    }

    public override float Timer => timeCounter / invincibleTime;
    
    public override void OnStartStage()
    {
        base.OnStartStage();
        timeCounter = 0f;
        playerLife.SetImmuneForTime(invincibleTime);
    }

    public override void Update()
    {
        base .Update();
        if (timeCounter < invincibleTime)
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= invincibleTime) timeCounter = invincibleTime;
        }

    }
}
