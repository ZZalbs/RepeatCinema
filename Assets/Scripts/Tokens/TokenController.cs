using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(BehaviourController), typeof(LifeController), typeof(InputHandler))]
public class TokenController : MonoBehaviour
{
    public BehaviourController PlayerBehaviourController;
    public LifeController LifeController;
    public InputHandler InputController;

    private Dictionary<int, TokenBase> PositiveTokens;
    private Dictionary<int, TokenBase> NegativeTokens;

    private void Awake()
    {
        PlayerBehaviourController = GetComponent<BehaviourController>();
        LifeController = GetComponent<LifeController>();
        InputController = GetComponent<InputHandler>();

        PositiveTokens = new();
        NegativeTokens = new();
    }

    private void Update()
    {
        foreach(var token in PositiveTokens.Values)
        {
            token.Update();
        }
        foreach (var token in NegativeTokens.Values)
        {
            token.Update();
        }
    }

    public void SelectToken(TokenBase newToken)
    {
        if(PositiveTokens.ContainsKey(newToken.Id))
        {
            PositiveTokens[newToken.Id].LevelUp();
        }
        else
        {
            PositiveTokens.Add(newToken.Id, newToken);
            newToken.Acquire();
        }

        if (NegativeTokens.ContainsKey(newToken.Id))
        {
            NegativeTokens[newToken.Id].LevelUp();
        }
        else
        {
            NegativeTokens.Add(newToken.Id, newToken);
            newToken.Acquire();
        }
    }


    public void DestroyOnePositiveToken()
    {
        int randomIndex = Random.Range(0, PositiveTokens.Keys.Count);

        PositiveTokens.Remove(randomIndex);
    }
    public void DestroyOneNegativeToken()
    {
        int randomIndex = Random.Range(0, NegativeTokens.Keys.Count);

        NegativeTokens.Remove(randomIndex);
    }

    public void DestroyAllPositiveToken()
    {
        PositiveTokens.Clear();
    }

    public void DestroyAllNegativeToken()
    {
        NegativeTokens.Clear();
    }
}