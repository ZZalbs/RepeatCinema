using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageManager : MonoBehaviour
{
    private Dictionary<Vector3Int, SpawnablePlatform> tiles;
    public Tilemap tilemap;
    [SerializeField] private Transform spawnablesParent;

    private void Start()
    {
        foreach (Transform child in spawnablesParent)
        {
            if (child.TryGetComponent<SpawnablePlatform>(out var spawnable))
            {
                tiles.Add(WorldPosToTilePos(child.position), spawnable);
            }
        }
    }
    
    public void SpawnOnRandomTile(Spawnable spawnable, int count)
    {
        System.Random random = new();
        tiles.Keys.OrderBy(x => random.Next()).Take(count)
            .ToList().ForEach(tilePos =>
            {
                var worldPos = TilePosToWorldPos(tilePos);
                Instantiate(spawnable.gameObject, worldPos, Quaternion.identity);
            });
    }
    
    private Vector3Int WorldPosToTilePos(Vector2 worldPos)
    {
        return tilemap.WorldToCell(worldPos);
    }
    
    private Vector2 TilePosToWorldPos(Vector3Int tilePos)
    {
        return tilemap.GetCellCenterWorld(tilePos);
    }
}
