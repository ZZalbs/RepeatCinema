using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourController))]
public class LeftMove : IBehaviour
{
    [SerializeField] BehaviourController controller;

    public BehaviourType Type => BehaviourType.LMove;

    public LeftMove(BehaviourController controller)
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
