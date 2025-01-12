using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private ResultUI result;
    [SerializeField] private CurtainUI curtain;
    [SerializeField] private HUD hud;
    [SerializeField] private TokenProvider tp;

    public void Awake()
    {
        StageController sc = GetComponent<StageController>();
        TokenController tc = GetComponent<TokenController>();

        result.Init(sc, tc, tp);
        hud.Init(tc);

        //result = Instantiate(result);
        //curtain = Instantiate(curtain);

        sc.AddStageEventListener(StageEventType.Awake, curtain.Close);
        sc.AddStageEventListener(StageEventType.Start, curtain.Open);
    }
    /*
    public void SetPosToken(TokenBase token)
    {
        hud.UpdatePositiveTokens(token);
    }*/
    public void SetNegToken(TokenBase token)
    {
        hud.UpdateNegativeTokens(token);
    }

    public void ShowCurtain()
    {
        curtain.Show(2f);
    }

    public void Update()
    {
        hud.UpdateHUD();
    }
}