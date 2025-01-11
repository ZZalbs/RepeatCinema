using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BehaviourController : MonoBehaviour
{
    [SerializeField] Vector2 playerStartPosition;
    public Rigidbody2D Body;
    public float Speed;
    public int CurJumpCount;
    public int MaxJumpCount;
    public Vector2 MoveDir;
    public float JumpForce;
    public bool isLookingRight;

    public Dictionary<BehaviourType, IBehaviour> Behaviours;
    private AnimationController anim;

    public void Init()
    {
        // 바꾸지마세요
        Body = GetComponent<Rigidbody2D>();
        Behaviours = new();

        Behaviours.Add(BehaviourType.RMove, new RightMove(this));
        Behaviours.Add(BehaviourType.LMove, new LeftMove(this));
        Behaviours.Add(BehaviourType.Jump, new Jump(this));

        anim = GetComponent<AnimationController>();
    }

    public void StageAwake()
    {
        CurJumpCount = 0;
        MoveDir = Vector2.zero;
        Body.position = playerStartPosition;
    }

    private void FixedUpdate()
    {
        Body.velocity = new Vector2(MoveDir.x * Speed, Body.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground")
            && CurJumpCount > 0
            && Body.velocity.y <= -0.01f)
        {
            CurJumpCount = 0;
        }
    }
}
