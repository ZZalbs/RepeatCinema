using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GhostMovement : MonoBehaviour
{
    private bool isMoving = false;
    [SerializeField] private Transform target;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    
    public void SetMoving(bool move)
    {
        isMoving = move;
    }
    
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        isMoving = true;
    }

    private void FixedUpdate()
    {
        if (!isMoving) return;
        Vector2 direction = (target.position - transform.position);
        float distance = direction.magnitude;

        spriteRenderer.flipX = direction.x < 0;

        var cos = Vector2.Dot(rb.velocity.normalized, direction.normalized);
        direction = cos < 0.01f ? direction.normalized : (1.1f * cos * direction.normalized - 0.1f * rb.velocity.normalized).normalized;
        var force = direction * (1.5f - cos / 2) * speed * Mathf.Clamp(distance, 0.1f, 5f);
        rb.AddForce(force, ForceMode2D.Force);
    }
}
