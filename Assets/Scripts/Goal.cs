using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("clear");
        }
    }
}
