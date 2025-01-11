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
        if (!controller.IsMovable) return;
        controller.MoveDir += Vector2.left;
        controller.Animator.SetFloat("VelocityX", -controller.MoveDir.x);
        controller.SpriteRenderer.flipX = true;
    }

    public void OnReleased(InputAction.CallbackContext ctx)
    {
        if (!controller.IsMovable) return;
        controller.MoveDir -= Vector2.left;
        controller.Animator.SetFloat("VelocityX", controller.MoveDir.x);
        controller.SpriteRenderer.flipX = false;
    }

    public void OnUpdate()
    {

    }
}
