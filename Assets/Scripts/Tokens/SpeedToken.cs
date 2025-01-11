using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedToken : TokenBase
{
    private float FullTimer => 4.5f - CurLevel * 0.5f;
    private float currentTimer;
    private BehaviourController playerBehaviour;
    
    public SpeedToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        playerBehaviour = controller.PlayerBehaviourController;
        currentTimer = 0;
    }

    public override float Timer => 1 - (currentTimer / FullTimer);

    public override void OnStartStage()
    {
        currentTimer = 0f;
    }

    public override void Update()
    {
        if (playerBehaviour.MoveDir.SqrMagnitude() < 0.01f)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer >= FullTimer)
            {
                controller.LifeController.OnDamaged(DamageType.Death);
            }
        }
        else
        {
            currentTimer = 0f;
        }

    }
}
