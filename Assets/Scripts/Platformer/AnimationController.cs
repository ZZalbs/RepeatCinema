using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetVelocityVector(Vector2 vel)
    {
        anim.SetFloat("VelocityX", vel.x);
        anim.SetFloat("VelocityY", vel.y);
    }

    public void SetJumpTrigger()
    {
        anim.SetTrigger("Jump");
    }

}
