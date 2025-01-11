using UnityEngine;

public class ThreateningObject : MonoBehaviour
{
    [SerializeField] private DamageType damageType;
    private LifeController playerLife;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!playerLife)
                playerLife = collision.gameObject.GetComponent<LifeController>();

            playerLife.OnDamaged(damageType);
        }
    }
}