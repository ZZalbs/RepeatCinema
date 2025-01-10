using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BehaviourController : MonoBehaviour
{
    public Rigidbody2D Body;
    public float Speed;
    public int CurJumpCount;
    public int MaxJumpCount;
    public Vector2 MoveDir;
    public float JumpForce;
    public bool isLookingRight;

    public List<IBehaviour> Behaviours;

    private void Awake()
    {
        Body = GetComponent<Rigidbody2D>();

        Behaviours = new();

        Behaviours.Add(new RightMove(this));
        Behaviours.Add(new LeftMove(this));
        Behaviours.Add(new Jump(this));

        StageController stageController = GetComponent<StageController>();
        stageController.AddStageEventListener(StageEventType.Awake, Init);
    }

    public void Init()
    {
        CurJumpCount = 0;
        MoveDir = Vector2.zero;
    }

    private void FixedUpdate()
    {
        Body.velocity = new Vector2(MoveDir.x * Speed * Time.deltaTime, Body.velocity.y);
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
