using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePosToken : TokenBase
{
    private int randomIndex;
    public RemovePosToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel, float timer) : base(controller, name, description, rarity, isPositive, maxLevel, timer)
    {
    }

    public override void Use()
    {
        randomIndex = Random.Range(0, controller.PositiveTokens.Count);
        controller.DestroyOnePositiveToken(randomIndex);
    }
}
