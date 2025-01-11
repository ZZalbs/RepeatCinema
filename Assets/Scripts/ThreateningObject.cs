using UnityEngine;

public class ThreateningObject : MonoBehaviour
{
    [SerializeField] private DamageType damageType;
    private LifeController playerLife;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            if(!playerLife)
                playerLife = collider.GetComponent<LifeController>();

            playerLife.OnDamaged(damageType);
        }
    }
}