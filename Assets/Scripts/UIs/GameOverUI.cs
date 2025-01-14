using LitMotion;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private StageController stageController;
    private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private void Awake()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>();
        stageController.AddStageEventListener(StageEventType.Over, Show);
        stageController.AddStageEventListener(StageEventType.Revive, Hide);
    }

    // Start is called before the first frame update
    private void Start()
    {
        canvasGroup.alpha = 0;
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
        LMotion.Create(0, 1f, 1f)
            .Bind(a => { if (canvasGroup) canvasGroup.alpha = a; });
        scoreText.text = $"최종 회차: <b>{stageController.CurrentStage}!</b>";
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void Exit()
    {
        SceneManager.LoadScene("StartScene");
    }
}
