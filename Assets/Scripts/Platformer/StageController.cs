using System;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    private Vector3 playerPosition;

    private Dictionary<StageEventType, Action> entries = new();

    // private void Awake()
    // {
    //     entries.TryAdd(StageEventType.Awake, new Action(() => { }));
    //     entries.TryAdd(StageEventType.Start, new Action(() => { }));
    //     entries.TryAdd(StageEventType.Clear, new Action(() => { }));
    //     entries.TryAdd(StageEventType.Over, new Action(() => { }));
    // }

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

        entries[StageEventType.Awake]?.Invoke();
    }

    public void StartStage()
    {
        // Ŀư ��

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