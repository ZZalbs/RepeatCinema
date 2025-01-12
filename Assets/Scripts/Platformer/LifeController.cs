using LitMotion;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    public int MaxLife;
    public int CurLife
    {
        get
        {
            return curLife;
        }
        set
        {
            curLife = value;

            if (curLife > MaxLife) curLife = MaxLife;
            else if (curLife <= 0)
            {
                curLife = 0;
                Die();
            }
        }
    }
    private int curLife;

    public int MaxShield;
    public int CurShield;

    private bool isImmune;
    private float remainingImmuneTimer;
    private MotionHandle immuneMotion;
    public event UnityAction onHit;
    public event UnityAction onHitUI;
    public event UnityAction onDead;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        StageController stageController = GetComponent<StageController>();
        stageController.AddStageEventListener(StageEventType.Awake, Init);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init()
    {
        CurLife = MaxLife;
        CurShield = MaxShield;
        isImmune = false;
    }

    public void OnDamaged(DamageType damageType)
    {
        switch(damageType)
        {
            case DamageType.Normal:
                if(!isImmune)
                {
                    curLife--;
                    onHit?.Invoke();
                    onHitUI?.Invoke();
                    if (curLife <= 0) Die();
                    else SetImmuneForTime(2f);
                }
                break;
            case DamageType.Critical:
                if(!isImmune)
                {
                    if(CurShield > 0)
                    {
                        CurShield--;
                        OnDamaged(DamageType.Normal);
                    }
                    else
                    {
                        curLife = 0;
                        Die();
                    }
                }
                break;
            case DamageType.Death:
                curLife = 0;
                Die();
                break;
        }
    }

    public void Die()
    {
        onDead?.Invoke();
        Debug.Log("Player Died!");
    }

    public void SetImmune(bool value)
    {
        isImmune = value;
    }

    public void SetImmuneForTime(float time)
    {
        if (isImmune)
        {
            if (time > remainingImmuneTimer)
            {
                immuneMotion.Cancel();
            }
            else
            {
                return;
            }
        }
        isImmune = true;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        immuneMotion = LMotion.Create(time, 0f, time).WithOnComplete(() => {
            isImmune = false;
            spriteRenderer.color = Color.white;
            })
            .Bind(t => remainingImmuneTimer = t);
    }
}
