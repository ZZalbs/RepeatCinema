using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InverseLeftMove : IBehaviour
{
    private BehaviourController controller;
    
    public BehaviourType Type => BehaviourType.LMove;
    
    public InverseLeftMove(BehaviourController controller)
    {
        this.controller = controller;
    }
    public void OnPressed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Inverse LeftMove OnPressed");
        controller.MoveDir += Vector2.right;
        controller.isLookingRight = true;
    }

    public void OnReleased(InputAction.CallbackContext ctx)
    {
        controller.MoveDir -= Vector2.right;
    }
}
