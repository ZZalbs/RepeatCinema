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
        controller.MoveDir += Vector2.right;
        controller.Animator.SetFloat("VelocityX", controller.MoveDir.x);
        controller.SpriteRenderer.flipX = false;
    }

    public void OnReleased(InputAction.CallbackContext ctx)
    {
        controller.MoveDir -= Vector2.right;
        controller.Animator.SetFloat("VelocityX", -controller.MoveDir.x);
        controller.SpriteRenderer.flipX = true;
    }

    public void OnUpdate()
    {

    }
}
