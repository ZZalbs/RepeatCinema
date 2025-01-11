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
        if (!controller.IsMovable) return;
        controller.MoveDir += Vector2.right;
        controller.Animator.SetFloat("VelocityX", controller.MoveDir.x);
        controller.SpriteRenderer.flipX = false;
    }

    public void OnReleased(InputAction.CallbackContext ctx)
    {
        if (!controller.IsMovable) return;
        controller.MoveDir -= Vector2.right;
        controller.Animator.SetFloat("VelocityX", -controller.MoveDir.x);
        controller.SpriteRenderer.flipX = true;
    }

    public void OnUpdate()
    {

    }
}
