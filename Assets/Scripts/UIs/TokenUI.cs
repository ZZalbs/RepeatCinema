using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TokenUI : MonoBehaviour
{
    private Image p_Icon;
    private TextMeshProUGUI p_Name;
    private TextMeshProUGUI p_Level;
    private TextMeshProUGUI p_Description;

    private Image n_Icon;
    private TextMeshProUGUI n_Name;
    private TextMeshProUGUI n_Level;
    private TextMeshProUGUI n_Description;

    private TokenController controller;

    public void Init(TokenController controller)
    {
        this.controller = controller;
    }

    public void Updated(TokenBase p_token, TokenBase n_token)
    {
        p_Icon.sprite = p_token.SourceImage;
        p_Name.text = p_token.Name;
        p_Level.text = $"Lv. {p_token.CurLevel + 1}";
        p_Description.text = p_token.Description;

        n_Icon.sprite = n_token.SourceImage;
        n_Name.text = n_token.Name;
        n_Level.text = $"Lv. {n_token.CurLevel + 1}";
        n_Description.text = n_token.Description;
    }

    public void Select()
    {
        // controller.SelectToken(TokenBase);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(true);
    }

    public void TransitionWithCurtain()
    {
        
    }

    
} 
