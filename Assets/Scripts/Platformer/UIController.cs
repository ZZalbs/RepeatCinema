using LitMotion;
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

        curtain = Instantiate(curtain);

        // sc.AddStageEventListener(StageEventType.Awake, curtain.Close);
        // sc.AddStageEventListener(StageEventType.Start, curtain.Open);
    }

    public void Update()
    {
        hud.UpdateHUD();
    }

    public void OpenCurtain()
    {
        curtain.Open();
    }

    public void CloseCurtain(bool needCover = false)
    {
        curtain.Close(needCover);
    }

    public void ShowCurtain(float duration, bool needCover = false)
    {
        curtain.Close(needCover);

        LMotion.Create(0f, 1f, duration).WithOnComplete(() =>
        {
            curtain.Open();
        }).RunWithoutBinding();
    }
}