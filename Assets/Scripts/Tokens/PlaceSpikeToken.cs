using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSpikeToken : TokenBase
{
    private static Spawnable spikePrefab;
    private List<Spawnable> spikes;

    static PlaceSpikeToken()
    {
        spikePrefab = Resources.Load<Spawnable>("Prefabs/Spike");
    }
    
    public PlaceSpikeToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        
    }

    public override float Timer => 0;

    public override void OnStartStage()
    {
        base.OnStartStage();
        spikes = StageManager.Instance.SpawnOnRandomTile(spikePrefab, CurLevel);
    }
    
    public override void OnEndStage()
    {
        foreach (var spike in spikes)
        {
            Object.Destroy(spike.gameObject);
        }
    }
}
