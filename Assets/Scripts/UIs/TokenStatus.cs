using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenStatus : MonoBehaviour
{
    private TokenBase token;
    private Image tokenImage;
    private Image cooldownImage;
    
    public void Init(TokenBase token)
    {
        this.token = token;
        tokenImage = GetComponent<Image>();
        cooldownImage = transform.GetChild(0).GetComponent<Image>();

        tokenImage.sprite = token.SourceImage;
        cooldownImage.sprite = token.SourceImage;
    }

    private void Update()
    {
        cooldownImage.fillAmount = token.Timer;
    }
}
