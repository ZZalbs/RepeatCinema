using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BehaviourController))]
public class LeftMove : IBehaviour
{
    private BehaviourController controller;

    public BehaviourType Type => BehaviourType.LMove;

    private Vector2 negative;

    public LeftMove(BehaviourController controller)
    {
        this.controller = controller;
    }

    public void OnPressed(InputAction.CallbackContext ctx)
    {
        controller.MoveDir += controller.ReverseMode ? Vector2.right : Vector2.left;
        negative = controller.ReverseMode ? Vector2.left : Vector2.right;
        controller.Animator.SetFloat("VelocityX", -controller.MoveDir.x);
        controller.SpriteRenderer.flipX = true;
    }

    public void OnReleased(InputAction.CallbackContext ctx)
    {
        controller.MoveDir += negative;
        controller.Animator.SetFloat("VelocityX", controller.MoveDir.x);

        if (Mathf.Abs(controller.MoveDir.x) > 0.01f)
        {
            controller.SpriteRenderer.flipX = controller.MoveDir.x > 0.01f ? false : true;
        }
    }

    public void OnUpdate()
    {

    }
}
