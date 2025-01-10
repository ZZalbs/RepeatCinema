using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : IBehaviour
{
    Vector2 JumpForce = new Vector2(0, 30);
    [SerializeField] CharacterController controller;

    public BehaviourType Type => BehaviourType.Jump;

    public void OnPressed()
    {
        if (controller.IsGrounded)
            controller.Body.AddForce(JumpForce);
    }

    public void OnReleased()
    {
        
    }
}
