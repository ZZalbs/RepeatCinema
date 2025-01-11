using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TokenUI : MonoBehaviour
{
    [SerializeField] private Image p_Icon;
    [SerializeField] private TextMeshProUGUI p_Name;
    [SerializeField] private TextMeshProUGUI p_Level;
    [SerializeField] private TextMeshProUGUI p_Description;

    [SerializeField] private Image n_Icon;
    [SerializeField] private TextMeshProUGUI n_Name;
    [SerializeField] private TextMeshProUGUI n_Level;
    [SerializeField] private TextMeshProUGUI n_Description;

    private TokenController controller;
    private TokenPair token;

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

        n_Icon.sprite = tokens.NegativeToken.SourceImage;
        n_Name.text = tokens.NegativeToken.Name;
        n_Level.text = $"Lv. {tokens.NegativeToken.CurLevel + 1}";
        n_Description.text = tokens.NegativeToken.Description;
    }

    public void Select()
    {
        SendIconImage();
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

    public void SendIconImage()
    {
        Debug.Log("sendintokenUI");
        controller.SendImage(p_Icon.sprite,n_Icon.sprite);
    }

    
} 
