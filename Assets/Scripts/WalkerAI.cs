using UnityEngine;

[RequireComponent(typeof(BehaviourController), typeof(ThreateningObject), typeof(Spawnable))]
public class WalkerAI : MonoBehaviour
{
    private BehaviourController behaviourController;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        behaviourController = GetComponent<BehaviourController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        behaviourController.Init();
        behaviourController.Behaviours.Remove(BehaviourType.Jump);
        behaviourController.MoveDir = Vector2.right;
        behaviourController.SetMovable(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlatformBoundary"))
        {
            behaviourController.MoveDir *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
            
        }
    }
}