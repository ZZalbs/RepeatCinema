using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseInputToken : TokenBase
{
    private StageController stageController;
    private InputController inputController;
    private BehaviourController playerBehaviourController;

    private RightMove rightMove;
    private LeftMove leftMove;
    
    public ReverseInputToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        stageController = controller.StageController;
        inputController = controller.InputController;
    }

    // Update is called once per frame
    public override float Timer => 0;

    public override void Acquire()
    {
        inputController.RemoveAllPlayerBehaviour();
    }

}
