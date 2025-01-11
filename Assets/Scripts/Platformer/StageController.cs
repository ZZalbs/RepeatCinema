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

    public void AwakeStage()
    {
        // Ŀư ����
        player.StageAwake();
        entries[StageEventType.Awake]?.Invoke();
    }

    public void StartStage()
    {
        // Ŀư ��
        currentStage++;
        entries[StageEventType.Start]?.Invoke();
    }

    public void ClearStage()
    {
        // ��ū ����

        entries[StageEventType.Clear]?.Invoke();
    }

    public void StageOver()
    {
        entries[StageEventType.Over]?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Goal"))
        {
            ClearStage();
        }
    }
} 