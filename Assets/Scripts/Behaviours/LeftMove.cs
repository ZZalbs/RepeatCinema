using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BehaviourController))]
public class LeftMove : IBehaviour
{
    private BehaviourController controller;

    public BehaviourType Type => BehaviourType.LMove;

    public LeftMove(BehaviourController controller)
    {
        this.controller = controller;
    }

    public void OnPressed(InputAction.CallbackContext ctx)
    {
        controller.MoveDir += Vector2.left;
        controller.isLookingRight = false;
    }

    public void OnReleased(InputAction.CallbackContext ctx)
    {
        controller.MoveDir -= Vector2.left;
    }
}
