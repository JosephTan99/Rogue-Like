using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquarePatrolAI : BaseAI
{
    [SerializeField] private int length;

    private int n = 1;
    private Vector2Int direction = new Vector2Int(1,0);

    [SerializeField]
    private bool isAttack = false;

    public override void TickUpdateA()
    {
        if (MovementManager.instance.GetPlayerPos() == Vector2Int.RoundToInt(transform.position) + direction)
        {
            Move(Vector2.zero);
            isAttack = true;
        }
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

    public override void TickUpdateE()
    {
        if (isAttack)
        {
            isAttack = false;
            Attack();
        }
    }

    public override Vector2Int MoveTile()
    {
        if (MovementManager.instance.GetPlayerPos() == Vector2Int.RoundToInt(transform.position) + direction)
        {
            return Vector2Int.RoundToInt(transform.position);
        }
        else if (GridManager.instance.GetTile(Vector2Int.RoundToInt(transform.position) + direction).GetTileType() == TileType.Empty)
        {
            return Vector2Int.RoundToInt(transform.position) + direction;
        }
        else
        {
            return Vector2Int.RoundToInt(transform.position);
        }
    }

    private void Attack()
    {
        
        HealthManager.instance.TakeDamage(1f);
    }
}
