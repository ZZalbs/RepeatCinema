using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : IBehaviour
{
    private BehaviourController controller;
    public BehaviourType Type => BehaviourType.Jump;
    private float timer = 0f;

    public Jump(BehaviourController controller)
    {
        this.controller = controller;
    }

    public void OnPressed(InputAction.CallbackContext ctx)
    {
        if (!controller.IsMovable) return;


        if (controller.CurJumpCount < controller.MaxJumpCount)
        {
            controller.Animator.SetTrigger("Jump");
            controller.CurJumpCount++;
            controller.Body.velocity = new Vector2(controller.Body.velocity.x, 0);
            controller.Body.AddForce(Vector2.up * controller.JumpForce, ForceMode2D.Impulse);
        }
        else
        {
            timer = 0.1f;
        }
    }

    public void OnReleased(InputAction.CallbackContext ctx)
    {
        
    }

    public void OnUpdate()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                if (controller.CurJumpCount < controller.MaxJumpCount)
                {
                    controller.Animator.SetTrigger("Jump");
                    controller.CurJumpCount++;
                    controller.Body.velocity = new Vector2(controller.Body.velocity.x, 0);
                    controller.Body.AddForce(Vector2.up * controller.JumpForce, ForceMode2D.Impulse);
                }
            }
        }
        controller.Animator.SetFloat("VelocityY", controller.Body.velocity.y);
    }
}
