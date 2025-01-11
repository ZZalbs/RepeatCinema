using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        stageController.AddStageEventListener(StageEventType.Start, OnStartStage);
        stageController.AddStageEventListener(StageEventType.Clear, OnEndStage);
        stageController.AddStageEventListener(StageEventType.Revive, OnEndStage);
        stageController.AddStageEventListener(StageEventType.Over, OnEndStage);
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

    private void OnStartStage()
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

    private void OnEndStage()
    {
        foreach (var token in PositiveTokens.Values)
        {
            token.OnEndStage();
        }
        foreach (var token in NegativeTokens.Values)
        {
            token.OnEndStage();
        }
    }

    public void SelectToken(TokenBase newToken)
    {
        if (newToken.IsPositive)
        {
            if (!PositiveTokens.ContainsKey(newToken.Id))
            {
                PositiveTokens.Add(newToken.Id, newToken);
                newToken.Acquire();
            }

            PositiveTokens[newToken.Id].LevelUp();
        }
        else
        {
            if (!NegativeTokens.ContainsKey(newToken.Id))
            {
                NegativeTokens.Add(newToken.Id, newToken);
                newToken.Acquire();
            }

            NegativeTokens[newToken.Id].LevelUp();
        }
    }




    public void DestroyOnePositiveToken()
    {
        int randomIndex = PositiveTokens.Keys.ToList()[Random.Range(0, PositiveTokens.Count)];
        
        PositiveTokens[randomIndex].OnDestroy();
        PositiveTokens.Remove(randomIndex);
    }
    public void DestroyOneNegativeToken()
    {
        int randomIndex = NegativeTokens.Keys.ToList()[Random.Range(0, NegativeTokens.Count)];

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