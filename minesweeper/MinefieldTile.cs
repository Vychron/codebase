using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script handles all the functionality of an independent tile,
/// it keeps track of everything it needs to know,
/// this includes whether it's a mine or not,
/// detecting tiles surrounding it and determining whether they are mines or not,
/// responding to being clicked on,
/// connecting to each other in case of a "flood fill"
/// </summary>
public class MinefieldTile : MonoBehaviour
{
    public Vector2 pos;
    public bool mine, immune, isRevealed, isFlagged;

    private List<MinefieldTile> _neighbourCells;
    private MinefieldTile[] _tiles;
    private MeshRenderer _rend;
    private RaycastHit2D _hit;
    private GameObject _button;
    private int _adjecentMines;
    [SerializeField] private bool _deployed = false;


    // a typical mouse event, triggered when the mouse is hovering over it, and determines which mouse button is pressed before responding
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            if (!_deployed)
                FirstMove();
            else
                if (!isFlagged)
                {
                    if (mine)
                        Explode();
                    else
                        if (!isRevealed)
                            Reveal();
                }
        if (Input.GetMouseButtonDown(1))
            if (!isRevealed && _deployed)
                Flag();
    }

    // mark a tile with a flag, or remove the flag
    void Flag()
    {
        isFlagged = !isFlagged;
        if (isFlagged)
            _rend.sharedMaterial = Resources.Load<Material>("My Sweeper/Materials/flag");
        else
            _rend.sharedMaterial = Resources.Load<Material>("My Sweeper/Materials/blank");
    }

    void Update()
    {
        if (!_deployed)
            if (GameObject.FindWithTag("Button").GetComponent<PlayfieldGenerator>().deployed)
                _deployed = true;
    }

    // reveal the tile, and if no mines are surrounding it, trigger a flood fill
    public void Reveal()
    {
        isRevealed = true;
        _rend.sharedMaterial = Resources.Load<Material>("My Sweeper/Materials/" + _adjecentMines.ToString());
        if (_adjecentMines == 0) 
            for (int i = 0; i < _neighbourCells.Count; i++)
                if (!_neighbourCells[i].isRevealed)
                    _neighbourCells[i].Reveal();
    }

    // Detonate all Mines
    void Explode()
    {
        GameObject[] a = GameObject.FindGameObjectsWithTag("Tile");
        _tiles = new MinefieldTile[a.Length];
        for (int i = 0; i < a.Length; i++)
            _tiles[i] = a[i].GetComponent<MinefieldTile>();
        for (int i = 0; i < _tiles.Length; i++)
        {
            _tiles[i].isRevealed = true;
            if (_tiles[i].mine)
            {    
                if (_tiles[i].isFlagged)
                    _tiles[i].GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/Materials/dismantled");
                else
                    _tiles[i].GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/Materials/bomb");
            }
        }
        _rend.sharedMaterial = Resources.Load<Material>("My Sweeper/Materials/explode");
        _button.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/Materials/lose");
        GameObject.FindWithTag("Clock").GetComponent<Clock>().End();
    }

    // Executed only once, but AFTER all cells are created, instead of at the start
    public void Activate()
    {
        _button = GameObject.FindGameObjectWithTag("Button");
        _button.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/Materials/button");
        _rend = GetComponent<MeshRenderer>();
        _neighbourCells = new List<MinefieldTile>();
        if (!mine)
        {
            CheckAdjecent(-1, -1, false);
            CheckAdjecent(-1, 0, false);
            CheckAdjecent(-1, 1, false);
            CheckAdjecent(0, -1, false);
            CheckAdjecent(0, 1, false);
            CheckAdjecent(1, -1, false);
            CheckAdjecent(1, 0, false);
            CheckAdjecent(1, 1, false);
        }
    }

    // Shoot a ray to detect adjecent tiles, adapt to their properties and grant first-turn immunity from becoming a mine
    void CheckAdjecent(int a, int b, bool setImmune)
    {
        _hit = Physics2D.Raycast(transform.position, new Vector2(a / 1.2f, b / 1.2f));
        if (_hit.collider != null && _hit.collider.tag == "Tile")
        {
            if (setImmune)
                _hit.collider.GetComponent<MinefieldTile>().immune = true;
            else
            {
                if (_hit.collider.GetComponent<MinefieldTile>().mine)
                    _adjecentMines++;
                else
                    _neighbourCells.Add(_hit.collider.GetComponent<MinefieldTile>());
            }

        }          
    }

    // The first move is obligated to reveal at least a bit of the field, therefor, this move must be protected from all mines
    void FirstMove()
    {
        immune = true;
        CheckAdjecent(-1, -1, true);
        CheckAdjecent(-1, 0, true);
        CheckAdjecent(-1, 1, true);
        CheckAdjecent(0, -1, true);
        CheckAdjecent(0, 1, true);
        CheckAdjecent(1, -1, true);
        CheckAdjecent(1, 0, true);
        CheckAdjecent(1, 1, true);
        StartCoroutine(GameObject.FindWithTag("Button").GetComponent<PlayfieldGenerator>().Mineify());
        Reveal();
    }
}
