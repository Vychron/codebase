using UnityEngine;
/// <summary>
/// A counter to help keeping track of how many mines you have uncovered, and how many you still need to find, given you've only marked mines with flags.
/// </summary>
public class MineCounter : MonoBehaviour
{
    [SerializeField] private GameObject _h, _t, _o; // hundreds, tens, ones
    private PlayfieldGenerator _field;
    private MinefieldTile[] _tiles;
    private string _mineCount;
    private int _mines, _flags, _mineCounter, _flaggedMines;

    public void Start()
    {
        _field = GameObject.FindWithTag("Button").GetComponent<PlayfieldGenerator>();
        _flags = 0;
        UpdateFlags();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _flags = 0;
            _flaggedMines = 0;
            GameObject[] g = GameObject.FindGameObjectsWithTag("Tile");
            _tiles = new MinefieldTile[g.Length];
            for (int i = 0; i < _tiles.Length; i++)
                {
                    _tiles[i] = g[i].GetComponent<MinefieldTile>();
                    if (_tiles[i].isFlagged)
                    {
                        _flags++;
                        if (_tiles[i].mine)
                            _flaggedMines++;
                    }
                }
            if (_flags == _flaggedMines && _flags == _mines)
            {
                _field.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/Materials/win");
                GameObject.FindWithTag("Clock").GetComponent<Clock>().End();
            }
            UpdateFlags();
        }
    }

    // Update the counter according to the amount of flags placed on the field
    void UpdateFlags()
    {
        _mines = _field.mines;
        _mineCounter = _mines - _flags;
        _mineCount = _mineCounter.ToString();
        if (_mineCount.Length < 3 && _mineCount[0] == "-"[0])
            while (_mineCount.Length < 3)
                _mineCount = " " + _mineCount;
        else
            while (_mineCount.Length < 3)
                _mineCount = "0" + _mineCount;    
        _h.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/Timer/Materials/" + _mineCount[0]);
        _t.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/Timer/Materials/" + _mineCount[1]);
        _o.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/Timer/Materials/" + _mineCount[2]);
}
}
