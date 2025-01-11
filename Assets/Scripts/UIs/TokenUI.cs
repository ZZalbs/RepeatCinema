using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TokenUI : MonoBehaviour
{
    [SerializeField] private Image p_Icon;
    [SerializeField] private TextMeshProUGUI p_Name;
    [SerializeField] private TextMeshProUGUI p_Level;
    [SerializeField] private TextMeshProUGUI p_Description;
    [SerializeField] private TextMeshProUGUI p_Rarity;

    [SerializeField] private Image n_Icon;
    [SerializeField] private TextMeshProUGUI n_Name;
    [SerializeField] private TextMeshProUGUI n_Level;
    [SerializeField] private TextMeshProUGUI n_Description;
    [SerializeField] private TextMeshProUGUI n_Rarity;

    private TokenController controller;
    private TokenPair token;
    
    private static string RarityToString(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.Common:
                return "커먼";
            case Rarity.Rare:
                return "레어";
            case Rarity.Epic:
                return "에픽";
            case Rarity.Legendary:
                return "레전더리";
            default:
                return "커먼";
        }
    }

    private static Color RarityToColor(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.Common:
                return new Color(34f / 255f, 171 / 255f, 42 / 255f);
            case Rarity.Rare:
                return new Color(39 / 255f, 122 / 255f, 194 / 255f);
            case Rarity.Epic:
                return new Color(173 / 255f, 38f / 255f, 172 / 255f);
            case Rarity.Legendary:
                return new Color(210 / 255f, 159 / 255f, 36 / 255f);
            default:
                return Color.white;
        }
    }

    public void Init(TokenController controller)
    {
        this.controller = controller;
    }

    public void Updated(TokenPair tokens)
    {
        token = tokens;
        p_Icon.sprite = tokens.PositiveToken.SourceImage;
        p_Name.text = tokens.PositiveToken.Name;
        p_Level.text = $"Lv. {tokens.PositiveToken.CurLevel + 1}";
        p_Description.text = tokens.PositiveToken.Description;
        p_Rarity.text = RarityToString(tokens.PositiveToken.Rarity);
        p_Rarity.color = RarityToColor(tokens.PositiveToken.Rarity);

        n_Icon.sprite = tokens.NegativeToken.SourceImage;
        n_Name.text = tokens.NegativeToken.Name;
        n_Level.text = $"Lv. {tokens.NegativeToken.CurLevel + 1}";
        n_Description.text = tokens.NegativeToken.Description;
        n_Rarity.text = RarityToString(tokens.NegativeToken.Rarity);
        n_Rarity.color = RarityToColor(tokens.NegativeToken.Rarity);
    }

    public void Select()
    {
        if (!controller.HasToken(token.PositiveToken))
            controller.SendPosToken(token.PositiveToken);
        if (!controller.HasToken(token.NegativeToken))
            controller.SendNegToken(token.NegativeToken);

        controller.SelectToken(token.PositiveToken);
        controller.SelectToken(token.NegativeToken);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

} 
