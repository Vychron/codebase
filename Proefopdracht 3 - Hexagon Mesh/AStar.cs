using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    public static List<Node> openList;
    public static List<Node> closedList;
    public static Vector3 target;
    public static Vector2Int pos;

    public void StartPath()
    {
        int indexNumber = 0;
        openList = new List<Node>();
        closedList = new List<Node>();
        Node destination = HexGridGenerator.nodes[pos.x][pos.y];
        HexGridGenerator.grid[pos.x][pos.y].GetComponent<Cell>().SetColor(1, 1, 1);
        destination.index = -1;
        closedList.Add(destination);
        SetChildren(destination, indexNumber);
    }
    void SetChildren(Node parent, int indexNumber)
    {
        List<Node> temp = new List<Node>(parent.GetNeighbours());
        for (int i = 0; i < temp.Count; i++)
        {
            if (temp[i].open && !closedList.Contains(temp[i]))
            {
                temp[i].index = indexNumber;
                temp[i].parentNode = parent;
                temp[i].H = Mathf.RoundToInt(Vector3.Distance(temp[i].position, target));
                temp[i].G = parent.F + 1;
                temp[i].F = temp[i].H + temp[i].G;
                openList.Add(temp[i]);
                indexNumber++;
            }
            else
            {
                closedList.Add(temp[i]);
            }
        }
        StartCoroutine(MoveToNext(indexNumber));
    }

    IEnumerator MoveToNext(int indexNumber)
    {
        Node lowestH = openList[0];

        for (int i = 0; i < openList.Count; i++)
        {
            if (openList[i].H < lowestH.H && !closedList.Contains(openList[i]))
            {
                lowestH = (openList[i]);
            }
        }
        openList.Remove(lowestH);
        closedList.Add(lowestH);
        HexGridGenerator.grid[lowestH.gridPosition.x][lowestH.gridPosition.y].GetComponent<Cell>().SetColor(0.5f, 1f, 0.5f);
        yield return new WaitForSeconds(0.25f);
        if (lowestH.H == 0)
        {
            StartCoroutine(FindPath(lowestH));
            yield return null;
        }
        else
        {
            SetChildren(lowestH, indexNumber);
        }
    }

    IEnumerator FindPath(Node current)
    {
        HexGridGenerator.grid[current.gridPosition.x][current.gridPosition.y].GetComponent<Cell>().SetColor(1, 1, 0);
        yield return new WaitForSeconds(0.25f);
        if (current.parentNode != null)
        {
            List<Node> nodes = current.GetNeighbours();
            Node lowestIndex = nodes[0];
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].index < lowestIndex.index)
                {
                    lowestIndex = nodes[i];
                }
            }
            StopAllCoroutines();
            StartCoroutine(FindPath(lowestIndex));
        }
        else yield return null;
    }
}
