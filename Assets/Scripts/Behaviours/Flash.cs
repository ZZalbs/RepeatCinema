using UnityEngine;

public class Flash : IBehaviour
{
    private BehaviourController controller;

    public BehaviourType Type => BehaviourType.Flash;

    private FlashToken token;

    public Flash(BehaviourController controller, FlashToken token)
    {
        this.controller = controller;
        this.token = token;
    }


    public void OnPressed()
    {
        if (token.IsAble)
        {
            token.CountFlash();

            Vector2 flashVector = controller.isLookingRight ? Vector2.right : Vector2.left;
            controller.transform.Translate(flashVector);
        }
    }

    public void OnReleased()
    {

    }
}