using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HUD : MonoBehaviour
{
    //[SerializeField] private Transform lifeTransform;
    [SerializeField] private TextMeshProUGUI stageLevel;
    //[SerializeField] private Transform p_TokenTransform;
    //[SerializeField] private Transform n_TokenTransform;
    [SerializeField] private Image[] hearts;
    [SerializeField] private int curHeartIndex;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private Sprite ghostHeart;
    [SerializeField] private Text stage;
    [SerializeField] private Image[] posIcons;
    [SerializeField] private int curPosIndex;
    [SerializeField] private Image[] negIcons;
    [SerializeField] private int curNegIndex;

    private TokenController controller;


    public void Init(TokenController controller)
    {
        this.controller = controller;
        curPosIndex = 0;
        curNegIndex = 0;
    }

    public void UpdateHUD()
    {
        UpdateLife();
        UpdateLevel();
    }



    public void UpdateLife()
    {
        for(curHeartIndex=0; curHeartIndex<controller.LifeController.MaxLife+controller.LifeController.MaxShield;curHeartIndex++)
        {
            if (curHeartIndex > hearts.Length)
                continue;
            if (curHeartIndex < controller.LifeController.CurLife)
                hearts[curHeartIndex].sprite = fullHeart;
            else
                hearts[curHeartIndex].sprite = emptyHeart;
            hearts[curHeartIndex].gameObject.SetActive(true);
        }
        for(;curHeartIndex<hearts.Length;curHeartIndex++)
        {
            hearts[curHeartIndex].gameObject.SetActive(false);
        }
        
    }
    public void UpdateLevel()
    {
        
    }
    public void UpdatePositiveTokens(Sprite p)
    {
        if (curPosIndex > posIcons.Length)
            return;
        posIcons[curPosIndex].sprite = p;
        posIcons[curPosIndex].gameObject.SetActive(true);
        curPosIndex++;
        for (int i=curPosIndex; i < posIcons.Length; i++)
        {
            hearts[curPosIndex].gameObject.SetActive(false);
        }
    }
    public void UpdateNegativeTokens(Sprite n)
    {
        if (curNegIndex > negIcons.Length)
            return;
        negIcons[curNegIndex].sprite = n;
        negIcons[curNegIndex].gameObject.SetActive(true);
        curNegIndex++;
        for (int i = curNegIndex; i < negIcons.Length; i++)
        {
            hearts[curNegIndex].gameObject.SetActive(false);
        }
    }
}
