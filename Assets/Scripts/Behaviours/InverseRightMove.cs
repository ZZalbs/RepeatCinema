using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InverseRightMove : IBehaviour
{
    private BehaviourController controller;
    
    public BehaviourType Type => BehaviourType.RMove;
    
    public InverseRightMove(BehaviourController controller)
    {
        this.controller = controller;
    }
    public void OnPressed(InputAction.CallbackContext ctx)
    {
        controller.MoveDir += Vector2.left;
        controller.isLookingRight = true;
    }

    public void OnReleased(InputAction.CallbackContext ctx)
    {
        controller.MoveDir -= Vector2.left;
    }
}
