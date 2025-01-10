using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Jump : IBehaviour
{
    [SerializeField] BehaviourController controller;

    public BehaviourType Type => BehaviourType.Jump;

    public Jump(BehaviourController controller)
    {
        this.controller = controller;
    }

    public void OnPressed()
    {
        if (controller.CurJumpCount < controller.MaxJumpCount)
        {
            controller.CurJumpCount++;
            controller.Body.velocity = new Vector2(controller.Body.velocity.x, 0);
            controller.Body.AddForce(Vector2.up * controller.JumpForce, ForceMode2D.Impulse);
        }
    }

    public void OnReleased()
    {
        
    }
}
