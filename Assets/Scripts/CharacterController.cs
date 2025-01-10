using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D Body;
    [HideInInspector] public float Speed;
    [HideInInspector] public bool IsGrounded;
}
