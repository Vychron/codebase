using UnityEngine;
/// <summary>
/// Used for different game setups
/// </summary>
public class OptionButton : MonoBehaviour
{
    [SerializeField] private int _height, _width, _mines;

    //Delegate events
    public delegate void NewSettings(int a, int b, int c);
    public static event NewSettings Apply;

    // When clicked, applies new settings for the next game
    void OnMouseDown() { Apply(_height, _width, _mines); }
}