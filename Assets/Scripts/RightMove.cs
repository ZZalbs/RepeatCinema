using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RightMove : IBehaviour
{
    CharacterController controller;

    public BehaviourType Type => BehaviourType.RMove;

    public RightMove(CharacterController controller)
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
