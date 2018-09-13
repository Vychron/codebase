using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Each tile manages itself and, in some occations, the cells adjecent to it.
/// The cells know when they are clicked on and how to respond to clicks and each other.
/// </summary>
public class MinefieldTile : MonoBehaviour
{
    [SerializeField] private bool _exploded, _isRevealed, _isFlagged, _canClick = true;
    public bool isMine, isImmune, started;
    private RaycastHit2D _hit;
    [SerializeField] private int _adjecentMines;
    private List<MinefieldTile> _adjecentCells;
    private MeshRenderer _rend;
    public string theme;

    // Delegade events
    public delegate void OnLose();
    public static event OnLose Lose;

    public delegate void OnDetonate();
    public static event OnDetonate Detonate;

    public delegate void OnFirstCick();
    public static event OnFirstCick FirstClick;

    public delegate void OnStarted();
    public static event OnStarted Started;

    public delegate void AddFlags();
    public static event AddFlags AddFlag;

    public delegate void DelFlags();
    public static event DelFlags RemoveFlag;

    public delegate void AddMines();
    public static event AddMines AddMine;

    public delegate void DelMines();
    public static event DelMines RemoveMine;

    // After the first turn, the tiles should no longer get immunity from being mines
    void RemoveImmunity()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("Tile");
        for (int i = 0; i < g.Length; i++)
            g[i].GetComponent<MinefieldTile>().started = true;
    }

    // Forces all other mines on the field to explode
    void Explode()
    {
        if (Detonate != null)
        {
            if (_isFlagged)
                _rend.sharedMaterial = Resources.Load<Material>("My Sweeper/Tiles/" + theme + "/Materials/dismantled");
            else
                _rend.sharedMaterial = Resources.Load<Material>("My Sweeper/Tiles/" + theme + "/Materials/mine");
        }
    }

    // Applies the effects of the easter egg
    void ApplyEaster(string theme)
    {
        this.theme = "Classic";
        UpdateTile();
    }

    // Adds all listeners at start of creation
    void Awake()
    {
        Lose += Stop;
        MineCounter.WinGame += Stop;
        PlayfieldGenerator.Clear += Delete;
        PlayfieldGenerator.ActivateMines += Activate;
        PlayfieldGenerator.EasterEgg += ApplyEaster;
        Started += RemoveImmunity;
        _rend = GetComponent<MeshRenderer>();
    }

    // After all mines have been placed, the tile will detect their surroundings for their final phase of the setup
    void Activate()
    {
        if (isMine)
            Detonate += Explode;
        _adjecentCells = new List<MinefieldTile>();
        Examine(false);
    }

    // how the tile responses to the mouse
    void OnMouseOver()
    {
        if (_canClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (FirstClick != null && !started)
                {
                    isImmune = true;
                    Examine(true);
                    FirstClick();
                    Reveal();
                    RemoveImmunity();
                }
                else
                {
                    if (!_isFlagged)
                    {
                        if (isMine)
                        {
                            Detonate();
                            _rend.sharedMaterial = Resources.Load<Material>("My Sweeper/Tiles/" + theme + "/Materials/explode");
                            if (Lose != null)
                                Lose();
                        }
                        else
                            Reveal();
                    }
                }
            }
            if (Input.GetMouseButtonDown(1) && !_isRevealed && started)
            {
                if (_isFlagged)
                {
                    if (isMine)
                        RemoveMine();
                    RemoveFlag();
                }
                else
                {
                    if (isMine)
                        AddMine();
                    AddFlag();
                }
                _isFlagged = !_isFlagged;
                UpdateTile();
            }
        }
    }

    // Disables the tile, it will no longer be clickable
    void Stop() { _canClick = false; }

    // Removes the tile from the field
    void Delete()
    {
        AddFlag = null;
        AddMine = null;
        RemoveFlag = null;
        RemoveMine = null;
        Lose -= Stop;
        MineCounter.WinGame -= Stop;
        PlayfieldGenerator.Clear -= Delete;
        PlayfieldGenerator.ActivateMines -= Activate;
        PlayfieldGenerator.EasterEgg -= ApplyEaster;
        Started -= RemoveImmunity;
        if (isMine)
            Detonate -= Explode;
        Destroy(gameObject);
    }

    // The tile will reveal itself and, if no mines surround it, will trigger a flood fill
    void Reveal()
    {
        _isRevealed = true;
        _rend.sharedMaterial = Resources.Load<Material>("My Sweeper/Tiles/" + theme + "/Materials/" + _adjecentMines.ToString());
        if (_adjecentMines == 0)
            for (int i = 0; i < _adjecentCells.Count; i++)
                if (!_adjecentCells[i]._isRevealed)
                    _adjecentCells[i].Reveal();
    }

    // The tile will examine the tiles surrounding it
    void Examine(bool makeImmune)
    {
        CastRay(-1, -1, makeImmune);
        CastRay(-1, 0, makeImmune);
        CastRay(-1, 1, makeImmune);
        CastRay(0, -1, makeImmune);
        CastRay(0, 1, makeImmune);
        CastRay(1, -1, makeImmune);
        CastRay(1, 0, makeImmune);
        CastRay(1, 1, makeImmune);
    }

    // The tile examines an adjecent tile to determine whether it's a mine or not, or grant it immunity if it's the first turn
    void CastRay(int a, int b, bool makeImmune)
    {
        _hit = Physics2D.Raycast(transform.position, new Vector2(a / 1.2f, b / 1.2f));
        if (_hit.collider != null && _hit.collider.tag == "Tile")
        {
            if (makeImmune)
                _hit.collider.GetComponent<MinefieldTile>().isImmune = true;
            else
            {
                if (_hit.collider.GetComponent<MinefieldTile>().isMine)
                    _adjecentMines++;
                else
                    _adjecentCells.Add(_hit.collider.GetComponent<MinefieldTile>());
            }
        }
    }

    // Update the current sprite the tile uses
    void UpdateTile()
    {
        if (!_isRevealed)
        {
            if (_isFlagged)
                _rend.sharedMaterial = Resources.Load<Material>("My Sweeper/Tiles/" + theme + "/Materials/flag");
            else
                _rend.sharedMaterial = Resources.Load<Material>("My Sweeper/Tiles/" + theme + "/Materials/blank");
        }
        else
            _rend.sharedMaterial = Resources.Load<Material>("My Sweeper/Tiles/" + theme + "/Materials/" + _adjecentMines.ToString());     
    }
}