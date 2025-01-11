using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourController), typeof(LifeController), typeof(InputController))]
public class TokenController : MonoBehaviour
{
    public BehaviourController PlayerBehaviourController;
    public LifeController LifeController;
    public InputController InputController;

    private Dictionary<int, TokenBase> PositiveTokens;
    private Dictionary<int, TokenBase> NegativeTokens;

    private void Awake()
    {
        PlayerBehaviourController = GetComponent<BehaviourController>();
        LifeController = GetComponent<LifeController>();
        InputController = GetComponent<InputController>();

        PositiveTokens = new();
        NegativeTokens = new();

        StageController stageController = GetComponent<StageController>();
        stageController.AddStageEventListener(StageEventType.Start, Init);
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

    public void Init()
    {
        foreach (var token in PositiveTokens.Values)
        {
            token.OnStartStage();
        }
        foreach (var token in NegativeTokens.Values)
        {
            token.OnStartStage();
        }
    }

    public void SelectToken(TokenBase newToken)
    {
        if(!PositiveTokens.ContainsKey(newToken.Id))
        {
            PositiveTokens.Add(newToken.Id, newToken);
            newToken.Acquire();
        }

        PositiveTokens[newToken.Id].LevelUp();

        if (!NegativeTokens.ContainsKey(newToken.Id))
        {
            NegativeTokens.Add(newToken.Id, newToken);
            newToken.Acquire();
        }

        NegativeTokens[newToken.Id].LevelUp();
    }


    public void DestroyOnePositiveToken()
    {
        int randomIndex = Random.Range(0, PositiveTokens.Keys.Count);
        
        PositiveTokens[randomIndex].OnDestroy();
        PositiveTokens.Remove(randomIndex);
    }
    public void DestroyOneNegativeToken()
    {
        int randomIndex = Random.Range(0, NegativeTokens.Keys.Count);

        NegativeTokens[randomIndex].OnDestroy();
        NegativeTokens.Remove(randomIndex);
    }

    public void DestroyToken(TokenBase token)
    {
        if (token.IsPositive)
        {
            PositiveTokens[token.Id].OnDestroy();
            PositiveTokens.Remove(token.Id);
        }
        else
        {
            NegativeTokens[token.Id].OnDestroy();
            NegativeTokens.Remove(token.Id);
        }
    }

    public void DestroyAllPositiveToken()
    {
        foreach (var token in PositiveTokens.Values)
        {
            token.OnDestroy();
        }
        PositiveTokens.Clear();
    }

    public void DestroyAllNegativeToken()
    {
        foreach (var token in PositiveTokens.Values)
        {
            token.OnDestroy();
        }
        NegativeTokens.Clear();
    }
}