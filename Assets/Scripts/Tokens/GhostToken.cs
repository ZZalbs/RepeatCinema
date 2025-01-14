using UnityEngine;

public class GhostToken : TokenBase
{
    private static GhostMovement ghostMovementPrefab;
    private static Vector2 ghostPosition;
    private GhostMovement ghost;
    private Transform target;

    static GhostToken()
    {
        ghostMovementPrefab = Resources.Load<GhostMovement>("Prefabs/Ghost");
        ghostPosition = new Vector2(-40, -5);
    }
    
    public GhostToken(TokenController controller, string name, string description, Rarity rarity, bool isPositive, int maxLevel) : base(controller, name, description, rarity, isPositive, maxLevel)
    {
        target = controller.transform;
    }

    public override float Timer => 0;
    
    public override void OnStartStage()
    {
        base.OnStartStage();
        ghost = Object.Instantiate(ghostMovementPrefab, ghostPosition + Vector2.up * Random.Range(-3f, 3f), Quaternion.identity);
        ghost.SetTarget(target);
    }
    
    public override void OnEndStage()
    {
        base.OnEndStage();
        Object.Destroy(ghost.gameObject);
    }
}
