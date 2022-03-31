using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    public GameObject testSlime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnEnemy(testSlime, new Vector2Int(8, 0));
        }
    }

    public void SpawnEnemy(GameObject prefab, Vector2Int position)
    {
        Instantiate(prefab, (Vector2)position, Quaternion.identity);
        GridManager.instance.SetGridTile(new GameTile(TileType.Enemy, prefab),position);
    }
}
