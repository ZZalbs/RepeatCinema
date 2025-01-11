using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private Transform lifeTransform;
    [SerializeField] private TextMeshProUGUI stageLevel;
    [SerializeField] private Transform p_TokenTransform;
    [SerializeField] private Transform n_TokenTransform;

    private TokenController controller;

    public void Init(TokenController controller)
    {
        this.controller = controller;
    }

    public void UpdateHUD()
    {
        UpdateLife();
        UpdateLevel();
        UpdatePositiveTokens();
        UpdateNegativeTokens();
    }

    public void UpdateLife()
    {

    }
    public void UpdateLevel()
    {

    }
    public void UpdatePositiveTokens()
    {

    }
    public void UpdateNegativeTokens()
    {

    }
}
