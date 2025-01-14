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
    private UIController uiController;

    public Dictionary<int, TokenBase> PositiveTokens;
    public Dictionary<int, TokenBase> NegativeTokens;

    private bool isStageActive = false;

    private void Awake()
    {
        PlayerBehaviourController = GetComponent<BehaviourController>();
        LifeController = GetComponent<LifeController>();
        InputController = GetComponent<InputController>();
        StageController = GetComponent<StageController>();
        uiController = GetComponent<UIController>();

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
        if (!isStageActive) return;
        foreach(var token in PositiveTokens.Values)
        {
            token.Update();
        }
        foreach (var token in NegativeTokens.Values)
        {
            token.Update();
        }
    }

    private void OnDisable()
    {
        DestroyAllPositiveToken();
        DestroyAllNegativeToken();
    }

    private void OnStartStage()
    {
        isStageActive = true;
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
        isStageActive = false;
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
        newToken.LevelUp();

        if (newToken.IsPositive)
        {
            if (!PositiveTokens.ContainsKey(newToken.Id))
            {
                PositiveTokens.Add(newToken.Id, newToken);
                newToken.Acquire();
            }
        }
        else
        {
            if (!NegativeTokens.ContainsKey(newToken.Id))
            {
                NegativeTokens.Add(newToken.Id, newToken);
                newToken.Acquire();
            }
        }
    }

    public bool HasToken(TokenBase newToken)
    {
        if (newToken.IsPositive)
        {
            if (PositiveTokens.ContainsKey(newToken.Id))
                return true;
        }
        else
        {
            if (NegativeTokens.ContainsKey(newToken.Id))
                return true;
        }
        return false;
    }
   

    public int GetGhostLevel()
    {
        if (PositiveTokens.ContainsKey(2))
        {
            return PositiveTokens[2].CurLevel;
        }
        else return 0;
    }

    public void DestroyOnePositiveToken()
    {
        if (PositiveTokens.Count == 0) return;
        var randomToken = PositiveTokens.Values.ToList()[Random.Range(0, PositiveTokens.Count)];

        DestroyToken(randomToken);
    }
    public void DestroyOneNegativeToken()
    {
        if (NegativeTokens.Count == 0) return;
        var randomToken = NegativeTokens.Values.ToList()[Random.Range(0, NegativeTokens.Count)];

        DestroyToken(randomToken);
    }

    public void DestroyToken(TokenBase token)
    {
        if (token.IsPositive)
        {
            PositiveTokens[token.Id]?.OnDestroy();
            PositiveTokens.Remove(token.Id);
        }
        else
        {
            NegativeTokens[token.Id]?.OnDestroy();
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