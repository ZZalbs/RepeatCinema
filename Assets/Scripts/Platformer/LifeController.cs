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

    [SerializeField] private bool isImmune;
    private float remainingImmuneTimer;
    private MotionHandle immuneMotion;
    
    public event UnityAction onHit;
    public event UnityAction onDead;

    private void Awake()
    {
        StageController stageController = GetComponent<StageController>();
        stageController.AddStageEventListener(StageEventType.Awake, Init);
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
                    if (curLife <= 0) Die();
                }
                break;
            case DamageType.Critical:
                if(!isImmune)
                {
                    if(CurShield > 0)
                    {
                        curLife--;
                        CurShield--;
                        if (curLife <= 0) Die();
                        else SetImmuneForTime(2f);
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
                break;
        }
    }

    public void Die()
    {
        onDead?.Invoke();
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
        immuneMotion = LMotion.Create(time, 0f, time).WithOnComplete(() => isImmune = false)
            .Bind(t => remainingImmuneTimer = t);
    }
}
