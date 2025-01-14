using LitMotion;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    private int currentStage = 1;

    private BehaviourController player;
    private LifeController lifeController;
    private UIController uiController;
    private Vector3 playerPosition;

    private Dictionary<StageEventType, Action> entries = new();
    
    public int CurrentStage => currentStage;

    private void Awake()
    {
        player = GetComponent<BehaviourController>();
        lifeController = GetComponent<LifeController>();
        uiController = GetComponent<UIController>();
        lifeController.onDead += StageOver;
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
        if (isClear) currentStage++;
        AwakeStage();
    }

    public void AwakeStage()
    {
        StageManager.Instance.RollTheme();

        player.StageAwake();
        if (currentStage > 1) uiController.CloseCurtain(true);

        entries[StageEventType.Awake]?.Invoke();

        LMotion.Create(0f, 1f, 1f).WithOnComplete(StartStage).RunWithoutBinding();
    }

    public void StartStage()
    {
        entries[StageEventType.Start]?.Invoke();
        uiController.OpenCurtain();
        player.SetMovable(true);
    }

    public void ClearStage()
    {
        entries[StageEventType.Clear]?.Invoke();
        player.SetMovable(false);
    }

    public void Revive()
    {
        uiController.ShowCurtain(1f);
        player.StageAwake();
        lifeController.Init();
        player.SetMovable(true);
        
        entries[StageEventType.Revive]?.Invoke();
        
    }

    public void StageOver()
    {
        uiController.CloseCurtain(false);
        entries[StageEventType.Over]?.Invoke();
        player.SetMovable(false);
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