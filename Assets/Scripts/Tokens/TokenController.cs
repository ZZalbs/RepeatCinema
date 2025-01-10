using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(BehaviourController), typeof(LifeController), typeof(InputHandler))]
public class TokenController : MonoBehaviour
{
    public BehaviourController PlayerBehaviourController;
    public LifeController LifeController;
    public InputHandler InputController;

    private Dictionary<int, TokenBase> tokens;

    private void Awake()
    {
        PlayerBehaviourController = GetComponent<BehaviourController>();
        LifeController = GetComponent<LifeController>();
        InputController = GetComponent<InputHandler>();

        tokens = new();
    }

    private void Update()
    {
        foreach(var token in tokens.Values)
        {
            token.Update();
        }
    }

    public void SelectToken(TokenBase newToken)
    {
        if(tokens.ContainsKey(newToken.Id))
        {
            tokens[newToken.Id].LevelUp();
        }
        else
        {
            tokens.Add(newToken.Id, newToken);
            newToken.Acquire();
        }
    }
}