using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D Body;
    public float Speed;
    [HideInInspector] public bool IsGrounded;
    [HideInInspector] public Vector2 moveDir;
    public float JumpForce;

    public List<IBehaviour> Behaviours;

    private void Awake()
    {
        Body = GetComponent<Rigidbody2D>();

        Behaviours = new();

        Behaviours.Add(new RightMove(this));
        Behaviours.Add(new LeftMove(this));
        Behaviours.Add(new Jump(this));
    }

    private void FixedUpdate()
    {
        Body.velocity = new Vector2(moveDir.x * Speed * Time.deltaTime, Body.velocity.y);
    }
}
