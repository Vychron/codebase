using UnityEngine;

public class HexGridGenerator : MonoBehaviour
{
    public int size;
    private float height = Mathf.Sqrt(0.75f);
    public static Node[][] nodes;
    public GameObject hex;
    public static GameObject[][] grid;

    void Start()
    {
        nodes = new Node[size][];
        grid = new GameObject[size][];
        for (int i = 0; i < size; i++)
        {
            nodes[i] = new Node[size];
            grid[i] = new GameObject[size];
            for (int j = 0; j < size; j++)
            {
                float offset = height / 2 * ((float)i % 2);
                nodes[i][j] = new Node(Random.Range(0f, 1f) < 0.75f, new Vector3(i + offset, 0f, j), new Vector2Int(i, j), i % 2);
                GameObject o = Instantiate(hex);
                o.transform.position = new Vector3(i * 0.75f, 0, j * height + offset);
                Cell c = o.GetComponent<Cell>();
                c.gridPos = new Vector2Int(i, j);
                c.offset = i % 2;
                c.blocked = !(nodes[i][j].open);
                o.name = "Hex " + (i + j * size);
                grid[i][j] = o;
            }
        }
    }
}