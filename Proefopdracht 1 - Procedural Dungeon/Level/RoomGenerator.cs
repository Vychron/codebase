using UnityEngine;
/// <summary>
/// Generates the Rooms of the dungeon, every room gets a random size, spawn chance decreases during generation
/// </summary>
public class RoomGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    private CorridorGenerator _corridor;
    public Vector2 pos;
    private int _height, _width, _length;
    public bool isFloor;

    // Generate a new Room
    public void Generate()
    {
        GridGenerator.Rooms += 0.02f;
        if (GridGenerator.Corridors < 5)
            GridGenerator.Corridors += 0.04f;

        _height = Random.Range(6, 12);
        _width = Random.Range(6, 12);
        _corridor = GetComponent<CorridorGenerator>();
        for (int i = 0; i < _width; i++)
            for (int j = 0; j < _height; j++)
                if (GridGenerator.objs[Mathf.FloorToInt(i + pos.x - _width / 2)][Mathf.FloorToInt(j + pos.y - _height / 2)] != null)
                    GridGenerator.objs[Mathf.FloorToInt(i + pos.x - _width / 2)][Mathf.FloorToInt(j + pos.y - _height / 2)].GetComponent<RoomGenerator>().ToFloor();

        _corridor.CreateCorridors(pos, _width, _height);
        GetComponent<InteriorGenerator>().Fill(pos, _height, _width);
    }

    // Change the cell into a floor tiles
    public void ToFloor()
    {
        isFloor = true;
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                GameObject o = GridGenerator.objs[Mathf.RoundToInt(pos.x) + i - 1][Mathf.RoundToInt(pos.y) + j - 1];
                o.SetActive(true);
                if (!o.GetComponent<RoomGenerator>().isFloor)
                    o.GetComponent<RoomGenerator>().ToWall();

                else o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, 1.15f);
            }  
        GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("Floor");
    }

    // Surrounds the exterior with a light-blocking wall
    public void ToWall()
    {
        GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("Wall");
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                GameObject o = GridGenerator.objs[Mathf.RoundToInt(pos.x) + i - 1][Mathf.RoundToInt(pos.y) + j - 1];
                o.SetActive(true);
            }             
    }
}
