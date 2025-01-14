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

    private void Awake()
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
        characterController.Init();

        AddAllPlayerBehaviour();
    }

    public void AddPlayerBehaviour(IBehaviour callbackBehaviour)
    {
        playerEntries[callbackBehaviour.Type].performed += callbackBehaviour.OnPressed;
        playerEntries[callbackBehaviour.Type].canceled += callbackBehaviour.OnReleased;
    }
    
    public void RemovePlayerBehaviour(IBehaviour callbackBehaviour)
    {
        playerEntries[callbackBehaviour.Type].performed -= callbackBehaviour.OnPressed;
        playerEntries[callbackBehaviour.Type].canceled -= callbackBehaviour.OnReleased;
    }
    
    public void RemoveAllPlayerBehaviour()
    {
        foreach(var behaviour in characterController.Behaviours.Values)
        {
            RemovePlayerBehaviour(behaviour);
        }
    }
    
    public void AddAllPlayerBehaviour()
    {
        
        foreach(var behaviour in characterController.Behaviours.Values)
        {
            AddPlayerBehaviour(behaviour);
        }
    }

    private void OnDisable()
    {
        RemoveAllPlayerBehaviour();
    }
}
