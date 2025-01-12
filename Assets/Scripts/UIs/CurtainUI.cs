using UnityEngine;

using LitMotion;

public class CurtainUI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject cover; 
    private MotionHandle motion;
    

    public void Open()
    {
        cover.SetActive(false);
        animator.ResetTrigger("Close");
        animator.SetTrigger("Open");
    }

    public void Close()
    {
        animator.ResetTrigger("Open");
        animator.SetTrigger("Close");
    }

    public void Show(float duration)
    {
        animator.ResetTrigger("Open");
        animator.SetTrigger("Close");
        cover.SetActive(true);

        LMotion.Create(0f, 1f, duration).WithOnComplete(() =>
        {
            animator.ResetTrigger("Close");
            animator.SetTrigger("Open");
            cover.SetActive(false);
        }).RunWithoutBinding();
    }
}
