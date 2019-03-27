using UnityEngine;
/// <summary>
/// Creates the grid in which the game will be played
/// </summary>
public class GridGenerator : MonoBehaviour
{
    public static int height = 150, width = 150;
    [SerializeField] private GameObject _obj, _o;
    public static GameObject[][] objs;
    public static float Rooms, Corridors;

    // Use this for initialization
    void Start()
    {
        Rooms = 1;
        Corridors = 1;
        objs = new GameObject[width][];
        for (int i = 0; i < width; i++)
        {
            objs[i] = new GameObject[height];
            for (int j = 0; j < height; j++)
            {
                _o = Instantiate(_obj, gameObject.transform);
                _o.transform.position = new Vector3(i - width * _o.transform.localScale.x / 2, j - height * _o.transform.localScale.y / 2, -1.5f);
                _o.GetComponent<RoomGenerator>().pos = new Vector2(i, j);
                _o.SetActive(false);
                objs[i][j] = _o;
            }
        }
        _o = objs[Mathf.RoundToInt(width / 2)][Mathf.RoundToInt(width / 2)];
        _o.SetActive(true);
        _o.GetComponent<RoomGenerator>().Generate();
    }
}
