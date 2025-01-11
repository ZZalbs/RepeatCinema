using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private ResultUI result;
    [SerializeField] private CurtainUI curtain;

    public void Awake()
    {
        StageController sc = GetComponent<StageController>();
        TokenController tc = GetComponent<TokenController>();
        TokenProvider tp = GetComponent<TokenProvider>();

        result.Init(sc, tc, tp);

        result = Instantiate(result);
        curtain = Instantiate(curtain);

        sc.AddStageEventListener(StageEventType.Awake, curtain.Close);
        sc.AddStageEventListener(StageEventType.Start, curtain.Open);
    }

    public void ShowCurtain()
    {
        curtain.Show(2f);
    }
}