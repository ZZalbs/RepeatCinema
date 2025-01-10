using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RightMove : MonoBehaviour,IBehaviour
{
    [SerializeField]CharacterController controller;
    private Vector2 moveDir;

    public void Init()
    {
        moveDir = Vector2.right;
    }

    public void Perform()
    {
        controller.RigidBody2D.velocity = moveDir*controller.RegidBody2D.velocity;
    }

}
