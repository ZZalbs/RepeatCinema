using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public enum BehaviourType {
        LMove,
        RMove,
        Jump,
    }

    private PlayerInputActions actions;
    private PlayerInputActions.PlayerActions playerActions;
    private PlayerInputActions.UIActions uiActions;

    private Dictionary<BehaviourType, InputAction> playerEntries;
    private Dictionary<BehaviourType, InputAction> uiEntries;

    private void Awake()
    {
        playerEntries = new();
        uiEntries = new();

        actions = new PlayerInputActions();
        playerActions = actions.Player;

        playerEntries[BehaviourType.LMove] = playerActions.LMove;
        playerEntries[BehaviourType.RMove] = playerActions.RMove;
        playerEntries[BehaviourType.Jump] = playerActions.Jump;

        uiActions = actions.UI;
    }

    private void AddPlayerBehaviour(BehaviourType eventType, IBehaviour callbackBehaviour)
    {
        if (!playerEntries.TryGetValue(eventType, out InputAction action)) return;

        action.performed += ctx =>  callbackBehaviour.Perform();
    }
}
