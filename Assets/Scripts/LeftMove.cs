using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class LeftMove : IBehaviour
{
    [SerializeField] CharacterController controller;

    public BehaviourType Type => BehaviourType.LMove;

    public LeftMove(CharacterController controller)
    {
        this.controller = controller;
    }

    public void OnPressed()
    {
        controller.moveDir += Vector2.left;
    }

    public void OnReleased()
    {
        controller.moveDir -= Vector2.left;
    }
}
