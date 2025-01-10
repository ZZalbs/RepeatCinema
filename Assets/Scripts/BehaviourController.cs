using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(Rigidbody2D))]
public class BehaviourController : MonoBehaviour
{
    public Rigidbody2D Body;
    public float Speed;
    public int CurJumpCount;
    public int MaxJumpCount;
    public Vector2 moveDir;
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground")
            && CurJumpCount > 0
            && Body.velocity.y <= 0)
        {
            CurJumpCount = 0;
        }
    }
}
