using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private List<TokenUI> tokenUIs;
    private StageController stageController;
    private TokenProvider tokenProvider;
    private Canvas canvas;

    public void Init(StageController stageController, TokenController tokenController, TokenProvider tokenProvider)
    {
        canvas = GetComponent<Canvas>();

        this.stageController = stageController;
        stageController.AddStageEventListener(StageEventType.Clear, Show);

        this.tokenProvider = tokenProvider;

        foreach (var token in tokenUIs)
        {
            token.Init(tokenController);
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        var tokens = tokenProvider.GetRandomTokens();

        for(int i = 0 ; i < 3; i ++)
        {
            tokenUIs[i].Updated(tokens[i]);
        }

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        stageController.InitStage(true);
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}