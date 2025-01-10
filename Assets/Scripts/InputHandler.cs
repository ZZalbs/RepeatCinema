using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class InputHandler : MonoBehaviour
{
    private PlayerInputActions actions;
    private PlayerInputActions.PlayerActions playerActions;
    private PlayerInputActions.UIActions uiActions;

    private Dictionary<BehaviourType, InputAction> playerEntries;
    private Dictionary<BehaviourType, InputAction> uiEntries;

    private CharacterController characterController;

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

        uiActions = actions.UI;

        characterController = GetComponent<CharacterController>();

        // register callback
        foreach(var behaviour in characterController.Behaviours)
        {
            Debug.Log(behaviour);
            AddPlayerBehaviour(behaviour);
        }
    }

    private void AddPlayerBehaviour(IBehaviour callbackBehaviour)
    {
        if (!playerEntries.TryGetValue(callbackBehaviour.Type, out InputAction action)) return;


        action.performed += ctx =>
        {
            callbackBehaviour.OnPressed();
            Debug.Log("behaviour");
        };
        action.canceled += ctx => callbackBehaviour.OnReleased();
    }
}
