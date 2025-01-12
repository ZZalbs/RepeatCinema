using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseInputToken : TokenBase
{
    private StageController stageController;
    private InputController inputController;
    private BehaviourController playerBehaviourController;

    private InverseRightMove inverseRightMove;
    private InverseLeftMove inverseLeftMove;
    
    public ReverseInputToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        stageController = controller.StageController;
        inputController = controller.InputController;
        playerBehaviourController = controller.PlayerBehaviourController;

        inverseRightMove = new InverseRightMove(playerBehaviourController);
        inverseLeftMove = new InverseLeftMove(playerBehaviourController);
    }

    // Update is called once per frame
    public override float Timer => 0;

    public override void OnStartStage()
    {
        base.OnStartStage();
        if (stageController.CurrentStage % (6 - CurLevel) != 0) return;
        base.Acquire();
        inputController.RemoveAllPlayerBehaviour();
        playerBehaviourController.Behaviours.Remove(BehaviourType.LMove);
        playerBehaviourController.Behaviours.Remove(BehaviourType.RMove);
        playerBehaviourController.Behaviours.Add(BehaviourType.LMove, inverseLeftMove);
        playerBehaviourController.Behaviours.Add(BehaviourType.RMove, inverseRightMove);
        inputController.AddAllPlayerBehaviour();
    }
    
    public override void OnEndStage()
    {
        base.OnEndStage();
        if (stageController.CurrentStage % (6 - CurLevel) != 0) return;
        inputController.RemoveAllPlayerBehaviour();
        playerBehaviourController.Behaviours.Remove(BehaviourType.LMove);
        playerBehaviourController.Behaviours.Remove(BehaviourType.RMove);
        playerBehaviourController.Behaviours.Add(BehaviourType.LMove, new LeftMove(playerBehaviourController));
        playerBehaviourController.Behaviours.Add(BehaviourType.RMove, new RightMove(playerBehaviourController));
        inputController.AddAllPlayerBehaviour();
    }

}
