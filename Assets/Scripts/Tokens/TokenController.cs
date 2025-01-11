using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviourController), typeof(LifeController), typeof(InputController))]
public class TokenController : MonoBehaviour
{
    public BehaviourController PlayerBehaviourController;
    public LifeController LifeController;
    public InputController InputController;
    public StageController StageController;

    public Dictionary<int, TokenBase> PositiveTokens;
    public Dictionary<int, TokenBase> NegativeTokens;

    private void Awake()
    {
        PlayerBehaviourController = GetComponent<BehaviourController>();
        LifeController = GetComponent<LifeController>();
        InputController = GetComponent<InputController>();
        StageController = GetComponent<StageController>();

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

    public void SelectToken(TokenPair newTokens)
    {
        if(!PositiveTokens.ContainsKey(newTokens.PositiveToken.Id))
        {
            PositiveTokens.Add(newTokens.PositiveToken.Id, newTokens.PositiveToken);
            newTokens.PositiveToken.Acquire();
        }

        PositiveTokens[newTokens.PositiveToken.Id].LevelUp();

        if (!NegativeTokens.ContainsKey(newTokens.NegativeToken.Id))
        {
            NegativeTokens.Add(newTokens.NegativeToken.Id, newTokens.NegativeToken);
            newTokens.NegativeToken.Acquire();
        }

        NegativeTokens[newTokens.NegativeToken.Id].LevelUp();
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