using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageManager : MonoBehaviour
{
    private Dictionary<Vector3Int, bool> tiles;
    public Tilemap tilemap;

    private void Start()
    {
        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (!tilemap.HasTile(pos)) continue;

            var tile = tilemap.GetTile<TileBase>(pos);

            tiles[pos] = new();
        }
    }
}
