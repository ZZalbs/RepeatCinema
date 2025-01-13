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
        controller.Animator.SetFloat("VelocityX", controller.MoveDir.x);
        controller.SpriteRenderer.flipX = false;
    }

    public void OnReleased(InputAction.CallbackContext ctx)
    {
        controller.MoveDir -= Vector2.right;
        controller.Animator.SetFloat("VelocityX", -controller.MoveDir.x);

        if(Mathf.Abs(controller.MoveDir.x) > 0.01f)
        {
            controller.SpriteRenderer.flipX = controller.MoveDir.x > 0.01f ? false : true;
        }
    }

    public void OnUpdate()
    {

    }
}
