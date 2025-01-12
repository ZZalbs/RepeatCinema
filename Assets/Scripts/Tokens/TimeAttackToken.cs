using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeAttackToken : TokenBase
{
    private float fullTime => 30 - (CurLevel - 1) * 5;
    private float timer;
    
    public TimeAttackToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
    }

    public override float Timer => 1 - timer / fullTime;
    
    public override void OnStartStage()
    {
        base.OnStartStage();
        timer = 0;
    }
    
    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (timer >= fullTime)
        {
            controller.LifeController.OnDamaged(DamageType.Death);
        }
    }
}