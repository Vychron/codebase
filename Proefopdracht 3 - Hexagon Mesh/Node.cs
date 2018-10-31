using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool open;
    public Vector3 position;
    public Vector2Int gridPosition;
    private List<Node> neighbours;
    public int offset;
    public int F { get; set; }
    public int G {get; set; }
    public int H { get; set; }
    public int index = 1000000;
    public Node parentNode;

    public Node(bool opened, Vector3 pos, Vector2Int gridPos, int offsetDistance)
    {
        open = opened;
        position = pos;
        gridPosition = gridPos;
        offset = offsetDistance;
    }

    public List<Node> GetNeighbours()
    {
        if (!open)
        {
            return new List<Node>();
        }
        neighbours = new List<Node>();
        HexGridGenerator gen = GameObject.FindWithTag("Generator").GetComponent<HexGridGenerator>();
        // Check left sides
        if (gridPosition.x - 1 >= 0)
        {
            if (gridPosition.y - 1 + offset >= 0)
                neighbours.Add(HexGridGenerator.nodes[gridPosition.x - 1][gridPosition.y - 1 + offset]);
            if (gridPosition.y < gen.size - offset)
                neighbours.Add(HexGridGenerator.nodes[gridPosition.x - 1][gridPosition.y + offset]);
        }
        // Check top and bottom sides
        if (gridPosition.x >= 0)
        {
            if (gridPosition.y - 1 >= 0)
                neighbours.Add(HexGridGenerator.nodes[gridPosition.x][gridPosition.y - 1]);
            if (gridPosition.y + 1 < gen.size)
                neighbours.Add(HexGridGenerator.nodes[gridPosition.x][gridPosition.y + 1]);
        }
        // Check right sides
        if (gridPosition.x + 1 < gen.size)
        {
            if (gridPosition.y - 1 + offset >= 0)
                neighbours.Add(HexGridGenerator.nodes[gridPosition.x + 1][gridPosition.y - 1 + offset]);
            if (gridPosition.y < gen.size - offset)
                neighbours.Add(HexGridGenerator.nodes[gridPosition.x + 1][gridPosition.y + offset]);
        }
        return neighbours;
    }
    
}
