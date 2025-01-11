using LitMotion;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    private int currentStage = 0;

    private BehaviourController player;
    private Vector3 playerPosition;

    private Dictionary<StageEventType, Action> entries = new();
    
    public int CurrentStage => currentStage;

    private void Awake()
    {
        player = GetComponent<BehaviourController>();
    }

    private void Start()
    {
        InitStage(false);
    }

    public void AddStageEventListener(StageEventType type, Action action)
    {
        if(!entries.TryGetValue(type, out Action entry))
        {
            entry = new Action(() => { });
            entries.Add(type, entry);
        }
        entry += action;
        entries[type] = entry;
    }

    public void InitStage(bool isClear)
    {
        // 
        // 토큰 발동은 awake에서

        if (isClear) currentStage++;
        AwakeStage();
    }

    public void AwakeStage()
    {
        player.StageAwake();

        entries[StageEventType.Awake]?.Invoke();

        LMotion.Create(0f, 1f, 2f).WithOnComplete(StartStage).RunWithoutBinding();
    }

    public void StartStage()
    {
        entries[StageEventType.Start]?.Invoke();
    }

    public void ClearStage()
    {
        entries[StageEventType.Clear]?.Invoke();
    }

    public void Revive()
    {
        entries[StageEventType.Revive]?.Invoke();
    }

    public void StageOver()
    {
        entries[StageEventType.Over]?.Invoke();
    }

    public void ResetGame()
    {
        Revive();
        InitStage(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Goal"))
        {
            ClearStage();
        }
    }
} 