using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(SpriteRenderer))]
public class ThemeSwitchableObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<RuntimeAnimatorController> anims;

    [SerializeField] private bool isAnimated;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (!isAnimated)
        {
            StageManager.Instance.ThemeSwitched += ChangeSprite;
        }
        else
        {
            StageManager.Instance.ThemeSwitched += ChangeAnimator;
        }
    }

    private void OnDestroy()
    {
        if (!isAnimated)
        {
            StageManager.Instance.ThemeSwitched -= ChangeSprite;
        }
        else
        {
            StageManager.Instance.ThemeSwitched -= ChangeAnimator;
        }
    }

    private void ChangeSprite(Theme theme)
    {
        spriteRenderer.sprite = sprites[(int)theme];
    }
    
    private void ChangeAnimator(Theme theme)
    {
        animator.runtimeAnimatorController = anims[(int)theme];
    }
}
