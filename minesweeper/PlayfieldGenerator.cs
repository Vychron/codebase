using System.Collections;
using UnityEngine;
/// <summary>
/// The generator takes responsibility for generating the minefield whenever it should.
/// It also functions as a button to trigger it directly and restart the game.
/// </summary>
public class PlayfieldGenerator : MonoBehaviour
{
    public int mines;
    [SerializeField] private int _height, _width, _mineCount;
    [SerializeField] private float _offset;
    [SerializeField] private GameObject _tile;
    private bool _mineified;
    private string _theme = "Default";


    // Delegate Events
    public delegate void Easter(string theme);
    public static event Easter EasterEgg;

    public delegate void OnReady();
    public static event OnReady Ready;

    public delegate void RestartGame();
    public static event RestartGame Clear;

    public delegate void EnableMines();
    public static event EnableMines ActivateMines;

    // Applies new settings for the next game
    void Apply(int a, int b, int c)
    {
        _height = a;
        _width = b;
        mines = c;
        Restart();
    }

    // Start a new game
    void Restart()
    {
        _mineCount = 0;
        if (Clear != null)
            Clear();
        Setup();
    }

    // Applies the easter egg
    void ApplyEaster(string theme)
    {
        _theme = "Classic";
        GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/UI/" + _theme + "/Materials/button");
    }

    void Start()
    {
        EasterEgg += ApplyEaster;
        MineCounter.WinGame += Win;
        OptionButton.Apply += Apply;
        Setup();
    }

    // Determines how the button responds to the mouse
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            Restart();
        if (Input.GetMouseButtonDown(1))
            EasterEgg(_theme);
    }

    // Updates the sprite of the button to indicate a win
    void Win() {GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/UI/" + _theme + "/Materials/win");}

    // Set up the game
    void Setup()
    {
        MinefieldTile.Lose += Lose;
        MinefieldTile.FirstClick += Started;
        _mineified = false;
        GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/UI/" + _theme + "/Materials/button");
        for (int i = 0; i < _width; i++)
            for (int j = 0; j < _height; j++)
            {
                GameObject g = Instantiate(_tile) as GameObject;
                g.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/Tiles/" + _theme + "/Materials/blank");
                g.transform.position = new Vector2(_offset * i - _offset * _width / 2 + _offset / 2, _offset * j - _offset * _height / 2 - _offset * 0.75f);
                g.GetComponent<MinefieldTile>().theme = _theme;
            }
        if (Ready != null)
            Ready();
    }

    // Changes the sprite of the button to indicate a loss
    void Lose() {GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/UI/" + _theme + "/Materials/lose");}

    // A one-time event to tell itself to add mines
    void Started()
    {
        if (!_mineified)
        {
            StartCoroutine(Mineify());
            _mineified = true;
        }
    }

    // Loops itself until enough mines are placed
    IEnumerator Mineify()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        for (int i = 0; i < tiles.Length; i++)
        {
            MinefieldTile t = tiles[i].GetComponent<MinefieldTile>();
            if (_mineCount < mines && Random.Range(0f, 1f) > 0.95f && !t.isMine && !t.isImmune)
            {
                t.isMine = true;
                _mineCount++;
            }
        }
        if (_mineCount < mines)
            StartCoroutine(Mineify());
        else
            ActivateMines();
        yield return null;
    }
}