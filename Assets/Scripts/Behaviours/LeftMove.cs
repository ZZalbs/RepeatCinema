using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourController))]
public class LeftMove : IBehaviour
{
    private BehaviourController controller;

    public BehaviourType Type => BehaviourType.LMove;

    public LeftMove(BehaviourController controller)
    {
        this.controller = controller;
    }

    public void OnPressed()
    {
        controller.MoveDir += Vector2.left;
        controller.isLookingRight = false;
    }

    public void OnReleased()
    {
        controller.MoveDir -= Vector2.left;
    }
}
