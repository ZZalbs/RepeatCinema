using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InverseLeftMove : IBehaviour
{
    private BehaviourController controller;
    private bool isValidInput;

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
        isValidInput = true;
    }

    public void OnReleased(InputAction.CallbackContext ctx)
    {
        if (!isValidInput) return;
        isValidInput = false;
        controller.MoveDir -= Vector2.right;
        controller.Animator.SetFloat("VelocityX", -controller.MoveDir.x);

        if (Mathf.Abs(controller.MoveDir.x) > 0.01f)
        {
            controller.SpriteRenderer.flipX = controller.MoveDir.x > 0.01f ? false : true;
        }
    }

    public void OnUpdate()
    {

    }
}
