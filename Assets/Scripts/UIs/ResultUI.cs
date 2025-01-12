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

        if(tokens.Count == 0)
        {
            stageController.InitStage(true);

            return;
        }

        for(int i = 0 ; i < 3; i ++)
        {
            if(i < tokens.Count)
            {
                tokenUIs[i].Updated(tokens[i]);
                tokenUIs[i].gameObject.SetActive(true);
            }
            else
            {
                tokenUIs[i].gameObject.SetActive(false);
            }
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