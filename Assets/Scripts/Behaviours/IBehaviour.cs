using UnityEngine.InputSystem;

public interface IBehaviour
{
    public BehaviourType Type { get; }
    public void OnPressed(InputAction.CallbackContext ctx);
    public void OnReleased(InputAction.CallbackContext ctx);
}
