using LitMotion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CurtainUI curtainUI;

    private void Start()
    {
        curtainUI.Open();
        LMotion.Create(0f, 1f, 1f).WithOnComplete(StartCutScene).RunWithoutBinding();
    }

    private void StartCutScene()
    {
        var state = animator.GetCurrentAnimatorStateInfo(0);
        float time = state.length;

        LMotion.Create(0f, 1f, time).WithOnComplete(LoadScene).RunWithoutBinding();
    }

    private void LoadScene()
    {
        curtainUI.Close();

        LMotion.Create(0f, 1f, 1f).WithOnComplete(() => { SceneManager.LoadScene("MainScene"); }).RunWithoutBinding();
    }
}
