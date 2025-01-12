using System.Collections.Generic;
using UnityEngine;

public class GenerateWalkerToken : TokenBase
{
    public override float Timer => 0;

    private static Spawnable walkerPrefab;
    private List<Spawnable> walkers;

    static GenerateWalkerToken()
    {
        walkerPrefab = Resources.Load<Spawnable>("Prefabs/Walker");
    }

    public GenerateWalkerToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
    }

    public override void OnStartStage()
    {
        base.OnStartStage();
        walkers = StageManager.Instance.SpawnOnRandomTile(walkerPrefab, CurLevel * 2);
    }

    public override void OnEndStage()
    {
        foreach (var spike in walkers)
        {
            Object.Destroy(spike.gameObject);
        }
    }
}
