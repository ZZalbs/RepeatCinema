using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseInputToken : TokenBase
{
    private StageController stageController;
    private InputController inputController;
    private BehaviourController playerBehaviourController;
    
    public ReverseInputToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        stageController = controller.StageController;
        inputController = controller.InputController;
        playerBehaviourController = controller.PlayerBehaviourController;
    }

    public override float Timer => 0;

    public override void OnStartStage()
    {
        base.OnStartStage();
        playerBehaviourController.ReverseMode = false;
        if (stageController.CurrentStage % (6 - CurLevel) != 0) return;
        base.Acquire();

        inputController.RemoveAllPlayerBehaviour();

        playerBehaviourController.ReverseMode = true;

        IBehaviour left = playerBehaviourController.Behaviours[BehaviourType.LMove];
        IBehaviour right = playerBehaviourController.Behaviours[BehaviourType.RMove];
        playerBehaviourController.Behaviours .Remove(BehaviourType.LMove);
        playerBehaviourController.Behaviours.Remove(BehaviourType.RMove);
        playerBehaviourController.Behaviours.Add(BehaviourType.LMove, right);
        playerBehaviourController.Behaviours.Add(BehaviourType.RMove, left);

        inputController.AddAllPlayerBehaviour();
    }
    
    public override void OnEndStage()
    {
        base.OnEndStage();
        if (stageController.CurrentStage % (6 - CurLevel) != 0) return;

        inputController.RemoveAllPlayerBehaviour();

        playerBehaviourController.ReverseMode = false;

        IBehaviour left = playerBehaviourController.Behaviours[BehaviourType.RMove];
        IBehaviour right = playerBehaviourController.Behaviours[BehaviourType.LMove];
        playerBehaviourController.Behaviours.Remove(BehaviourType.LMove);
        playerBehaviourController.Behaviours.Remove(BehaviourType.RMove);
        playerBehaviourController.Behaviours.Add(BehaviourType.LMove, right);
        playerBehaviourController.Behaviours.Add(BehaviourType.RMove, left);

        inputController.AddAllPlayerBehaviour();
    }

}
