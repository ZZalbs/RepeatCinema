using System;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    private Vector3 playerPosition;

    private Dictionary<StageEventType, Action> entries;

    private void Awake()
    {
        entries = new();
    }

    public void AddStageEventListener(StageEventType type, Action action)
    {
        if(!entries.TryGetValue(type, out Action entry))
        {
            entry = new Action(() => { });
        }

        entry += action;
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