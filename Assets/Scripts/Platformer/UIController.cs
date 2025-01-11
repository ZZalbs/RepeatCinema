using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private ResultUI result;
    [SerializeField] private HUD hud;
    [SerializeField] private TokenProvider tp;

    public void Awake()
    {
        StageController sc = GetComponent<StageController>();
        TokenController tc = GetComponent<TokenController>();
        

        result.Init(sc, tc, tp);
        hud.Init(tc);
    }

    public void Update()
    {
        hud.UpdateHUD();
    }
}