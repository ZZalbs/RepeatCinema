using UnityEngine;

[RequireComponent(typeof(BehaviourController), typeof(ThreateningObject), typeof(Spawnable))]
public class WalkerAI : MonoBehaviour
{
    private BehaviourController behaviourController;

    private void Awake()
    {
        behaviourController = GetComponent<BehaviourController>();
        behaviourController.Init();
        behaviourController.MoveDir = Vector2.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlatformBoundary"))
        {
            behaviourController.MoveDir *= -1;
        }
    }
}