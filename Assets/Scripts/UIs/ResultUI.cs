using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private List<TokenUI> tokenUIs;
    private StageController stageController;
    private TokenProvider tokenProvider;

    public void Init(StageController stageController, TokenController tokenController, TokenProvider tokenProvider)
    {
        this.stageController = stageController;
        stageController.AddStageEventListener(StageEventType.Clear, Show);

        this.tokenProvider = tokenProvider;

        foreach (var token in tokenUIs)
        {
            token.Init(tokenController);
        }

        Hide();
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
    }
}