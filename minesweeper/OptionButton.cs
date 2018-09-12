using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// An extension to the playfield generator, when clicked, the game restarts using the configuration of the button
/// </summary>
public class OptionButton : MonoBehaviour
{
    [Header("Custom game field size")]
    [SerializeField] private int _height;
    [SerializeField] private int _width;
    [Header("Custom amount of mines")]
    [SerializeField] private int _mines;
    private PlayfieldGenerator _field;

    void Start()
    {
        _field = GameObject.FindWithTag("Button").GetComponent<PlayfieldGenerator>();
    }

    // Apply settings bound to button
    void OnMouseDown()
    {
        _field.newHeight = _height;
        _field.newWidth = _width;
        _field.newMines = _mines;
        _field.OnMouseDown();
    }
}
