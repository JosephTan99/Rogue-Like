using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquarePatrolAI : BaseAI
{
    [SerializeField] private int length;

    private int n = 1;
    private Vector2Int direction = new Vector2Int(1,0);

    public override void TickUpdate()
    {
        if (MovementManager.instance.GetPlayerPos() == Vector2Int.RoundToInt(transform.position) + direction) Attack();
        else if(GridManager.instance.GetTile(Vector2Int.RoundToInt(transform.position) + direction).GetTileType() == TileType.Empty)
        {
            //to fix later here have error
            n++;
            Move(direction);
        }
        else n++;
        if (n > (length * 4 - 4) / 4f)
        {
            n = 1;
            direction = new Vector2Int(-direction.y, direction.x);
        }
    }

    private void Attack()
    {
        Move(Vector2.zero);
        Debug.Log("player -1");
    }
}
