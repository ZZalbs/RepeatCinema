using UnityEngine;

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
            else if (curLife <= 0) curLife = 0; // die
        }
    }
    private int curLife;

    public int MaxShield;
    public int CurShield;

    public bool IsImmune;

    public void Init()
    {
        CurLife = MaxLife;
        CurShield = MaxShield;
        IsImmune = false;
    }

    public void OnDamaged(DamageType damageType)
    {
        switch(damageType)
        {
            case DamageType.Normal:
                if(!IsImmune)
                {
                    curLife--;
                    Addimmunity(2f);
                }
                break;
            case DamageType.Critical:
                if(!IsImmune)
                {
                    if(CurShield > 0)
                    {
                        curLife--;
                        CurShield--;
                        Addimmunity(2f);
                    }
                    else
                    {
                        curLife = 0;
                    }
                }
                break;
            case DamageType.Death:
                curLife = 0;
                break;
        }
    }

    public void Addimmunity(float time)
    {
        CancelInvoke(nameof(RemoveImmunity));

        IsImmune = true;

        Invoke(nameof(RemoveImmunity), time);
    }

    public void RemoveImmunity()
    {
        IsImmune = false;
    }
}
