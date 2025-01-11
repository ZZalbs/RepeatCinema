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
    [SerializeField] private TokenStatus[] posIcons;
    [SerializeField] private int curPosIndex;
    [SerializeField] private TokenStatus[] negIcons;
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
        int hpGhostSum = controller.LifeController.MaxLife + controller.GetGhostLevel();
        for (curHeartIndex=0; curHeartIndex<hpGhostSum;curHeartIndex++)
        {
            if (curHeartIndex >= hearts.Length)
                continue;
            if (curHeartIndex < controller.LifeController.CurLife)
                hearts[curHeartIndex].sprite = fullHeart;
            else if (curHeartIndex < hpGhostSum)
                hearts[curHeartIndex].sprite = ghostHeart;
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
        stageLevel.text = $"Stage: {controller.StageController.CurrentStage}";
    }
    public void UpdatePositiveTokens(TokenBase token)
    {
        if (curPosIndex > posIcons.Length)
            return;
        posIcons[curPosIndex].Init(token);
        posIcons[curPosIndex].gameObject.SetActive(true);
        curPosIndex++;
        for (int i=curPosIndex; i < posIcons.Length; i++)
        {
            posIcons[curPosIndex].gameObject.SetActive(false);
        }
    }
    public void UpdateNegativeTokens(TokenBase token)
    {
        if (curNegIndex > negIcons.Length)
            return;
        negIcons[curNegIndex].Init(token);
        negIcons[curNegIndex].gameObject.SetActive(true);
        curNegIndex++;
        for (int i = curNegIndex; i < negIcons.Length; i++)
        {
            negIcons[curNegIndex].gameObject.SetActive(false);
        }
    }
}
