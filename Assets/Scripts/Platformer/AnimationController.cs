using UnityEngine;

[RequireComponent(typeof(Animator), typeof(BehaviourController))]
public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private BehaviourController behaviourController;

    private void Awake()
    {
        behaviourController = GetComponent<BehaviourController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        SetVelocityVector();
        SetFilp();
    }

    public void SetJumpTrigger()
    {
        anim.SetTrigger("Jump");
    }

    public void SetVelocityVector()
    {
        Vector2 velocity = behaviourController.Body.velocity;

        anim.SetFloat("VelocityX", Mathf.Abs(velocity.x));
        anim.SetFloat("VelocityY", velocity.y);
    }

    public void SetFilp()
    {
        spriteRenderer.flipX = !behaviourController.isLookingRight;
    }

}
