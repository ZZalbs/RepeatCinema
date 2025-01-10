using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : IBehaviour
{
    [SerializeField] CharacterController controller;

    public BehaviourType Type => BehaviourType.Jump;

    public Jump(CharacterController controller)
    {
        this.controller = controller;
    }

    public void OnPressed()
    {
        if (controller.IsGrounded)
            controller.Body.AddForce(Vector2.up * controller.JumpForce, ForceMode2D.Impulse);
    }

    public void OnReleased()
    {
        
    }
}
