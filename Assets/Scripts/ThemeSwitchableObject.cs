using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ThemeSwitchableObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Dictionary<Theme, Sprite> sprites;
    private Dictionary<Theme, RuntimeAnimatorController> anims;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Init()
    {
        if (spriteRenderer && sprites != null)
        {
            StageManager.Instance.ThemeSwitched += theme => spriteRenderer.sprite = sprites[theme];
        }

        if (animator && anims != null)
        {
            StageManager.Instance.ThemeSwitched += theme => animator.runtimeAnimatorController = anims[theme];
        }
    }
}
