using UnityEngine;
using UnityEngine.InputSystem;

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


    public void OnPressed(InputAction.CallbackContext ctx)
    {
        if (!controller.IsMovable) return;
        if (token.IsAble)
        {
            token.CountFlash();

            Vector2 flashVector = !controller.SpriteRenderer.flipX ? Vector2.right : Vector2.left;

            RaycastHit2D hit = Physics2D.Raycast(controller.transform.position, flashVector, 1f, 1 << LayerMask.NameToLayer("Ground"));
            if (hit)
            {
                flashVector.x *= Mathf.Min(0f, hit.distance - 0.1f);
            }

            controller.Body.transform.Translate(flashVector);
        }
    }

    public void OnReleased(InputAction.CallbackContext ctx)
    {

    }

    public void OnUpdate()
    {

    }
}
