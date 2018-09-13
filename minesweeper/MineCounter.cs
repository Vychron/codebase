using UnityEngine;
/// <summary>
/// Keeps track of the flags placed on the field.
/// Using information of the flagged tiles, it determines when the player wins the game.
/// </summary>
public class MineCounter : MonoBehaviour
{
    [SerializeField] private int _mines, _flags, _flaggedMines, _mineStringInt;
    [SerializeField] private GameObject _h, _t, _o;
    private string _mineString, _theme = "Default";

    // Delegate Events
    public delegate void OnWin();
    public static event OnWin WinGame;

    void Start()
    {
        StyleButton.NewStyle += ApplyTheme;
        PlayfieldGenerator.Ready += Reset;
        PlayfieldGenerator.EasterEgg += ApplyTheme;
        Reset();
    }

    // Applies the easter egg
    void ApplyTheme(string theme)
    {
        _theme = theme;
        UpdateFlags();
    }

    // Resets the counter
    void Reset()
    {
        MinefieldTile.AddFlag += Add;
        MinefieldTile.RemoveFlag += Delete;
        MinefieldTile.AddMine += AddMine;
        MinefieldTile.RemoveMine += DeleteMine;
        _mines = GameObject.FindWithTag("Button").GetComponent<PlayfieldGenerator>().mines;
        _flags = 0;
        _flaggedMines = 0;
        UpdateFlags();
    }

    // Adds one to the flag count and determines a win
    void Add()
    {
        _flags++;
        UpdateFlags();
        if (_flaggedMines == _flags && _flags == _mines)
        {
            WinGame();
        }
    }

    // substracts one form the flag count
    void Delete()
    {
        _flags--;
        UpdateFlags();
    }

    // Adds one to the count on flagged mines
    void AddMine() { _flaggedMines++; }

    // Substracts one from the count on flagged mines
    void DeleteMine() { _flaggedMines--; }

    // Updates the counter according to the amount of mines and flags on the field
    void UpdateFlags()
    {
        _mineStringInt = _mines - _flags;
        _mineString = _mineStringInt.ToString();
        if (_mineString.Length < 3 && _mineString[0] == "-"[0])
            while (_mineString.Length < 3)
                _mineString = " " + _mineString;
        else
            while (_mineString.Length < 3)
                _mineString = "0" + _mineString;
        _h.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/UI/" + _theme + "/Materials/" + _mineString[0]);
        _t.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/UI/" + _theme + "/Materials/" + _mineString[1]);
        _o.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/UI/" + _theme + "/Materials/" + _mineString[2]);
    }
}