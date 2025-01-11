using UnityEngine;

using LitMotion;

public class CurtainUI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private MotionHandle motion;

    public void Open()
    {
        animator.SetTrigger("Open");
    }

    public void Close()
    {
        animator.SetTrigger("Close");
    }

    public void Show(float duration)
    {
        animator.SetTrigger("Close");

        LMotion.Create(0f, 1f, duration).WithOnComplete(() => animator.SetTrigger("Open")).RunWithoutBinding();
    }
}
