using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostToken : TokenBase
{
    private static GhostMovement ghostMovementPrefab;
    private static Vector2 ghostPosition;
    private GhostMovement ghost;

    static GhostToken()
    {
        ghostMovementPrefab = Resources.Load<GhostMovement>("Prefabs/Ghost");
        ghostPosition = new Vector2(-10, 4);
    }
    
    public GhostToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
    }

    public override float Timer => 0;
    
    public override void Acquire()
    {
        base.OnStartStage();
        ghost = Object.Instantiate(ghostMovementPrefab, ghostPosition, Quaternion.identity);
    }
    
    public override void OnDestroy()
    {
        Object.Destroy(ghost.gameObject);
    }
}
