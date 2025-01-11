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
            StageManager.Instance.ThemeSwitched += theme => spriteRenderer.sprite = sprites[(int)theme];
        }
        else
        {
            StageManager.Instance.ThemeSwitched += theme => animator.runtimeAnimatorController = anims[(int)theme];
        }
    }
}
