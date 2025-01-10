using UnityEngine;

[RequireComponent(typeof(BehaviourController))]
public class RightMove : IBehaviour
{
    private BehaviourController controller;

    public BehaviourType Type => BehaviourType.RMove;

    public RightMove(BehaviourController controller)
    {
        this.controller = controller;
    }

    public void OnPressed()
    {
        controller.moveDir += Vector2.right;
    }

    public void OnReleased()
    {
        controller.moveDir -= Vector2.right;
    }
}
