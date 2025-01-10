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
            controller.transform.Translate(Vector2.right);
        }
    }

    public void OnReleased()
    {

    }
}
