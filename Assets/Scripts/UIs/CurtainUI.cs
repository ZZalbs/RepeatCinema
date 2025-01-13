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

    public void Close(bool needCover = false)
    {
        cover.SetActive(needCover);
        animator.ResetTrigger("Open");
        animator.SetTrigger("Close");
    }

    public void Show(float duration, bool needCover = false)
    {
        Close(needCover);

        LMotion.Create(0f, 1f, duration).WithOnComplete(() =>
        {
            Open();
        }).RunWithoutBinding();
    }
}
