using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCriticalSpikeToken : TokenBase
{
    private static Spawnable spikePrefab;
    private List<Spawnable> spikes;

    static PlaceCriticalSpikeToken()
    {
        spikePrefab = Resources.Load<Spawnable>("Prefabs/CriticalSpike");
    }
    
    public PlaceCriticalSpikeToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        spikes = new();
    }

    public override float Timer => 0;

    public override void OnStartStage()
    {
        base.OnStartStage();
        spikes = StageManager.Instance.SpawnOnRandomTile(spikePrefab, CurLevel);
    }
    
    public override void OnEndStage()
    {
        base.OnEndStage();
        for (int i = spikes.Count - 1; i >= 0; i--)
        {
            var toDestroy = spikes[i].gameObject;
            spikes.RemoveAt(i);
            GameObject.Destroy(toDestroy);
        }
    }
}
