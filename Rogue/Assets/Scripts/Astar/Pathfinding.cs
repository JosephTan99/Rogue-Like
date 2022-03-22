using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private Node[,] nodeArray;
    private List<Node> openList;
    private List<Node> closedList;

    public Pathfinding(int width, int height)
    {
        nodeArray = new Node[width, height];
    }

    public List<Vector2Int> FindPath(Vector2Int startPos, Vector2Int endPos)
    {
        Node startNode = new Node(startPos);

        openList = new List<Node> { startNode };
        closedList = new List<Node>();

        for(int x = 0; x < nodeArray.GetLength(0); x++)
        {
            for(int y = 0; y< nodeArray.GetLength(1); y++)
            {
                Node node = new Node(new Vector2Int(x, y));
                nodeArray[x, y] = node;
                node.gCost = int.MaxValue;
                node.CalculateFCost();
                node.parent = null;
            }
        }

        nodeArray[startPos.x, startPos.y] = startNode;
        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startPos, endPos);
        startNode.CalculateFCost();

        while(openList.Count > 0)
        {
            Node currNode = GetLowestFCostNode(openList);
            if(currNode.nodePos == endPos)
            {
                return CalculatePath(currNode);
            }
            openList.Remove(currNode);
            closedList.Add(currNode);

            foreach(Node neighbour in CalculateNeighbourNode(currNode))
            {
                if (GridManager.instance.GetTile(new Vector2Int(neighbour.nodePos.x, neighbour.nodePos.y)).GetTileType() != TileType.Empty) continue;
                if (closedList.Contains(neighbour)) continue;

                int tentativeGCost = currNode.gCost + CalculateDistanceCost(currNode.nodePos, endPos);
                if(tentativeGCost < neighbour.gCost)
                {
                    neighbour.parent = currNode;
                    neighbour.gCost = tentativeGCost;
                    neighbour.hCost = CalculateDistanceCost(neighbour.nodePos, endPos);
                    neighbour.CalculateFCost();

                    if (!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour);
                    }
                }
            }
        }


        return null;

    }

    private List<Node> CalculateNeighbourNode(Node currNode)
    {
        List<Node> neighbourList = new List<Node>();
        if(currNode.nodePos.x - 1 >= 0)
        {
            neighbourList.Add(nodeArray[currNode.nodePos.x - 1, currNode.nodePos.y]);
        }
        if(currNode.nodePos.x + 1 <= nodeArray.GetLength(0)-1)
        {
            neighbourList.Add(nodeArray[currNode.nodePos.x + 1, currNode.nodePos.y]);
        }
        if (currNode.nodePos.y - 1 >= 0)
        {
            neighbourList.Add(nodeArray[currNode.nodePos.x, currNode.nodePos.y - 1]);
        }
        if (currNode.nodePos.y + 1 <= nodeArray.GetLength(1)-1)
        {
            neighbourList.Add(nodeArray[currNode.nodePos.x, currNode.nodePos.y + 1]);
        }
        return neighbourList;

    }

    private List<Vector2Int> CalculatePath(Node endNode)
    {
        List<Vector2Int> vectorPath = new List<Vector2Int>();
        vectorPath.Add(endNode.nodePos);
        Node currNode = endNode;
        while(currNode.parent != null)
        {
            vectorPath.Add(currNode.parent.nodePos);
            currNode = currNode.parent;
        }
        vectorPath.Reverse();
        return vectorPath;
    }

    private int CalculateDistanceCost(Vector2Int a, Vector2Int b)
    {
        int xDist = Mathf.Abs(a.x - b.x);
        int yDist = Mathf.Abs(a.y - b.y);
        return xDist + yDist;
    }

    private Node GetLowestFCostNode(List<Node> nodeList)
    {
        Node lowestFCostNode = nodeList[0];
        for(int i = 1; i < nodeList.Count; i++)
        {
            if(nodeList[i].fCost < lowestFCostNode.fCost)
            {
                lowestFCostNode = nodeList[i];
            }
        }
        return lowestFCostNode;
    }

    /*
    public List<Vector2Int> CalculatePossibleLocations(List<Vector2Int> moveablePositions, Vector2Int startPos)
    {
        openList = new List<Node>();
        closedList = new List<Node>();
        List<Vector2Int> updatedPositions = new List<Vector2Int>();
        for (int x = 0; x < nodeArray.GetLength(0); x++) 
        {
            for (int y = 0; y < nodeArray.GetLength(1); y++) 
            {
                Node node = new Node(new Vector2Int(x, y));
                nodeArray[x, y] = node;
            }
        }
        openList.Add(nodeArray[startPos.x, startPos.y]);

        while (openList.Count != 0)
        {
            Node currNode = openList[0];
            openList.Remove(currNode);
            closedList.Add(currNode);
            foreach(Node neighbourNode in CalculateNeighbourNode(currNode))
            {
                if (TileData.instance.gridData[neighbourNode.nodePos.x, neighbourNode.nodePos.y].tileType != TileType.Empty || !moveablePositions.Contains(neighbourNode.nodePos) || openList.Contains(neighbourNode)) continue;
                if (closedList.Contains(neighbourNode)) continue;

                openList.Add(neighbourNode);
            }
        }
        foreach(Node closedNode in closedList)
        {
            updatedPositions.Add(closedNode.nodePos);
        }
        updatedPositions.Remove(startPos);
        return updatedPositions;
    }
    */
}
