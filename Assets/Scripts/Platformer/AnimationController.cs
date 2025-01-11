using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;
       
    public void SetVelocityX(float velocityX)
    {
        anim.SetFloat("velocityX", velocityX);
    }

    public void SetVelocityY(float velocityY)
    {
        anim.SetFloat("velocityY", velocityY);
    }
}
