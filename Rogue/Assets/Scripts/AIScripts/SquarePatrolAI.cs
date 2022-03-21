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
        n++;
        Move(direction);
        if (n > (length * 4 - 4) / 4f)
        {
            n = 1;
            direction = new Vector2Int(-direction.y, direction.x);
        }
    }
}
