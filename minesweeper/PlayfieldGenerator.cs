using System.Collections;
using UnityEngine;
/// <summary>
/// One button to set up the entire game, applies the field size to generate the game, and adds the mines as soon as the first tile has been revealed
/// </summary>
public class PlayfieldGenerator : MonoBehaviour
{
    [Header("Define the height and width of the minefield")]
    public int height = 20;
    public int width = 25;

    [HideInInspector] public int newHeight, newWidth, newMines;

    public GameObject[,] pos;

    [Header("Mine count")]
    public int mines = 50;
    public int mineCount = 0;
    
    [Header("Tile offset")]
    [SerializeField] private float _offset;

    [Header("Tile Prefab")]
    [SerializeField] private GameObject _tile;

    private Clock _clock;
    private MineCounter _counter;

    [HideInInspector]
    public bool deployed = false;

    void Start()
    {
        newHeight = height;
        newWidth = width;
        newMines = mines;
        _clock = GameObject.FindWithTag("Clock").GetComponent<Clock>();
        _counter = GameObject.FindWithTag("Counter").GetComponent<MineCounter>();
        pos = new GameObject[ width, height];
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
            {
                GameObject g = Instantiate(_tile) as GameObject;
                g.transform.position = new Vector2(_offset * i - _offset * width / 2 + _offset / 2, _offset * j - _offset * height / 2 - _offset * 0.75f);
                g.GetComponent<MinefieldTile>().pos = new Vector2(i, j);
                pos[i, j] = g;
            }
        _clock.Clear();
    }

    // Reset the game by pressing the button
    public void OnMouseDown()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
                Destroy(pos[i, j]);
        }
            
        deployed = false;
        mineCount = 0;
        height = newHeight;
        width = newWidth;
        mines = newMines;
        _counter.Start();
        Start();
        GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/Materials/button");

    }

    // Turn tiles into mines
    public IEnumerator Mineify()
    {
        deployed = true;
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                if (mineCount < mines)
                    if (Random.Range(0f, 1f) < 0.1)
                        if (!pos[i, j].GetComponent<MinefieldTile>().mine && !pos[i,j].GetComponent<MinefieldTile>().immune)
                        {
                            pos[i, j].GetComponent<MinefieldTile>().mine = true;
                            mineCount++;
                        }
        if (mineCount < mines)
            StartCoroutine(Mineify());
        else
            Deploy();
        yield return null;
    }
    
    // Finish generation and start the game
    void Deploy()
    {
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                pos[i, j].GetComponent<MinefieldTile>().Activate();
        _clock.Begin();
    }
}
