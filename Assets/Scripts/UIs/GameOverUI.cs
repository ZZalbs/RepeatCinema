using System;
using System.Collections;
using System.Collections.Generic;
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
            .Bind(a => canvasGroup.alpha = a);
        scoreText.text = $"도달 스테이지: <b>{stageController.CurrentStage}!</b>";
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
