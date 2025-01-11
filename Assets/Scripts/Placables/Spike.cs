using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private bool isCritical;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<LifeController>().OnDamaged(isCritical ? DamageType.Critical : DamageType.Normal);
        }
    }
}
