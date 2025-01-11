using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BehaviourController))]
public class RightMove : IBehaviour
{
    private BehaviourController controller;

    public BehaviourType Type => BehaviourType.RMove;

    public RightMove(BehaviourController controller)
    {
        this.controller = controller;
    }

    public void OnPressed(InputAction.CallbackContext ctx)
    {
        controller.MoveDir += Vector2.right;
        controller.isLookingRight = true;
    }

    public void OnReleased(InputAction.CallbackContext ctx)
    {
        controller.MoveDir -= Vector2.right;
    }
}
