using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int gCost;
    public int hCost;
    public int fCost;
    public Node parent;
    public Vector2Int nodePos;

    public Node(Vector2Int pos)
    {
        nodePos = pos;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
}
