using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HUD : MonoBehaviour
{
    [SerializeField] private Transform lifeTransform;
    [SerializeField] private TextMeshProUGUI stageLevel;
    [SerializeField] private Transform p_TokenTransform;
    [SerializeField] private Transform n_TokenTransform;
    [SerializeField] private Image[] hearts;
    [SerializeField] private int curindex;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Sprite ghostHeart;
    [SerializeField] private Text stage;

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
        for(curindex=0; curindex<controller.LifeController.MaxLife;curindex++)
        {
            if (curindex < controller.LifeController.CurLife)
                hearts[curindex].sprite = fullHeart;
            else
                hearts[curindex].sprite = emptyHeart;
            hearts[curindex].gameObject.SetActive(true);
        }
        for(;curindex<hearts.Length;curindex++)
        {
            hearts[curindex].gameObject.SetActive(false);
        }
        
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
