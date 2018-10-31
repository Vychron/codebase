using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int gridPos;
    public int offset;
    public bool blocked;

    // Use this for initialization
    void Start()
    {
        if (blocked)
        {
            SetColor(1, 0, 0);
        }
    }
    
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AStar.pos = gridPos;
            SetColor(1, 0.8f, 0);
        }
        if (Input.GetMouseButtonDown(1))
        {
            AStar.target = new Vector3(gridPos.x, 0f, gridPos.y);
            SetColor(0, 0.8f, 1);
        }
    }

    public void SetColor(float r, float g, float b)
    {
        Color c = new Color(r, g, b);
        GetComponent<MeshRenderer>().material.color = c;
    }
}
