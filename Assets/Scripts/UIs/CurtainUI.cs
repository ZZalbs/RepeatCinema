using System;
using UnityEngine;

using LitMotion;

public class CurtainUI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private MotionHandle motion;
    

    public void Open()
    {
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

        LMotion.Create(0f, 1f, duration).WithOnComplete(() =>
        {
            animator.ResetTrigger("Close");
            animator.SetTrigger("Open");
        }).RunWithoutBinding();
    }
}
