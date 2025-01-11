using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : IBehaviour
{
    private BehaviourController controller;
    public BehaviourType Type => BehaviourType.Jump;

    public Jump(BehaviourController controller)
    {
        this.controller = controller;
    }

    public void OnPressed(InputAction.CallbackContext ctx)
    {
        if (controller.CurJumpCount < controller.MaxJumpCount)
        {
            controller.CurJumpCount++;
            controller.Body.velocity = new Vector2(controller.Body.velocity.x, 0);
            controller.Body.AddForce(Vector2.up * controller.JumpForce, ForceMode2D.Impulse);
        }
    }

    public void OnReleased(InputAction.CallbackContext ctx)
    {
        
    }
}
