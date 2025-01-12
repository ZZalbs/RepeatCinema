using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BehaviourController : MonoBehaviour
{
    [SerializeField] Vector2 playerStartPosition;
    public Animator Animator;
    public SpriteRenderer SpriteRenderer;
    public Rigidbody2D Body;
    public float Speed;
    public int CurJumpCount;
    public int MaxJumpCount;
    public Vector2 MoveDir;
    public float JumpForce;

    public Dictionary<BehaviourType, IBehaviour> Behaviours;

    private bool movable = false;

    public bool IsMovable => movable;

    public void Init()
    {
        // �ٲ���������
        Body = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Behaviours = new();
        MoveDir = Vector2.zero;

        Behaviours.Add(BehaviourType.RMove, new RightMove(this));
        Behaviours.Add(BehaviourType.LMove, new LeftMove(this));
        Behaviours.Add(BehaviourType.Jump, new Jump(this));
    }

    private void Update()
    {
        foreach (var behaviour in Behaviours)
        {
            behaviour.Value.OnUpdate();
        }
    }

    public void SetMovable(bool movable)
    {
        this.movable = movable;
        if (!movable) MoveDir = Vector2.zero;
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
            && Body.velocity.y < 0.01f)
        {
            foreach(var contact in collision.contacts)
            {
                if(contact.point.y < Body.position.y - 0.74f)
                {
                    CurJumpCount = 0;
                    break;
                }
            }
        }
    }
}
