using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BehaviourController))]
public class InputController : MonoBehaviour
{
    private PlayerInputActions actions;
    private PlayerInputActions.PlayerActions playerActions;
    private PlayerInputActions.UIActions uiActions;

    private Dictionary<BehaviourType, InputAction> playerEntries;
    private Dictionary<BehaviourType, InputAction> uiEntries;

    private BehaviourController characterController;

    private void Start()
    {
        playerEntries = new();
        uiEntries = new();

        actions = new PlayerInputActions();
        actions.Enable();
        playerActions = actions.Player;

        playerEntries[BehaviourType.LMove] = playerActions.LMove;
        playerEntries[BehaviourType.RMove] = playerActions.RMove;
        playerEntries[BehaviourType.Jump] = playerActions.Jump;
        playerEntries[BehaviourType.Flash] = playerActions.Flash;

        uiActions = actions.UI;

        characterController = GetComponent<BehaviourController>();

        // register callback
        foreach(var behaviour in characterController.Behaviours)
        {
            AddPlayerBehaviour(behaviour);
        }
    }

    public void AddPlayerBehaviour(IBehaviour callbackBehaviour)
    {
        if (!playerEntries.TryGetValue(callbackBehaviour.Type, out InputAction action)) return;


        action.performed += ctx =>
        {
            callbackBehaviour.OnPressed();
        };
        action.canceled += ctx => callbackBehaviour.OnReleased();
    }
}
