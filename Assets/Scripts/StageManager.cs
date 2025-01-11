using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;


public class StageManager : MonoBehaviour
{
    private Dictionary<Vector3Int, SpawnablePlatform> tiles = new();
    public Tilemap tilemap;
    [SerializeField] private Transform spawnablesParent;
    
    public static StageManager Instance { get; private set; }
    public event Action<Theme> ThemeSwitched;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        foreach (Transform child in spawnablesParent)
        {
            if (child.TryGetComponent<SpawnablePlatform>(out var spawnable))
            {
                tiles.Add(WorldPosToTilePos(child.position), spawnable);
            }
        }
    }
    
    public List<Spawnable> SpawnOnRandomTile(Spawnable spawnable, int count)
    {
        List<Spawnable> spawnables = new();
        System.Random random = new();
        tiles.Keys.OrderBy(x => random.Next()).Take(count)
            .ToList().ForEach(tilePos =>
            {
                var worldPos = TilePosToWorldPos(tilePos + Vector3Int.up);
                var spawnableInstance = Instantiate(spawnable, worldPos, Quaternion.identity);
                spawnables.Add(spawnableInstance);
            });
        return spawnables;
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
