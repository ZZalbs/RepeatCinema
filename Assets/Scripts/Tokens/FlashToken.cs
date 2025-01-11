using UnityEngine;
using UnityEngine.InputSystem.XR;

public class FlashToken : TokenBase
{
    private IBehaviour flash;

    private float coolTime => 3 - 0.67f * (CurLevel - 1);
    private float timer;
    public float RemainCoolTime => timer;
    private int flashCount;

    public override float Timer => timer / coolTime;
    public bool IsAble => flashCount < CurLevel;

    public FlashToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        flash = new Flash(controller.PlayerBehaviourController, this);
    }

    public override void Acquire()
    {
        base.Acquire();

        controller.InputController.AddPlayerBehaviour(flash);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        controller.InputController.RemovePlayerBehaviour(flash);
    }

    public override void Update()
    {
        Debug.Log(timer);
        if (flashCount > 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                if(--flashCount > 0)
                    timer = coolTime;
            }
        }
    }

    public void CountFlash()
    {
        flashCount++;
        timer = coolTime;
    }
}
