using System.Collections;
using UnityEngine;
/// <summary>
/// Keeps track of how long the current game is in play
/// </summary>
public class Clock : MonoBehaviour
{
    [SerializeField] private GameObject _h, _t, _o; // hundreds, tens, ones
    private int _time;
    private string _timeString, _theme = "Default";

    void Start()
    {
        MineCounter.WinGame += StopAllCoroutines;
        PlayfieldGenerator.Clear += Clear;
        PlayfieldGenerator.ActivateMines += StartTimer;
        MinefieldTile.Lose += StopAllCoroutines;
        PlayfieldGenerator.EasterEgg += ApplyEaster;
        SetTime();
    }

    // Applies the easter egg
    void ApplyEaster(string theme)
    {
        _theme = "Classic";
        SetTime();
    }

    // Starts the timer
    void StartTimer()
    {
        Clear();
        StartCoroutine(Count());
    }

    // Sets the timer back to 0
    void Clear()
    {
        StopAllCoroutines();
        _time = 0;
        SetTime();
    }

    // Loops every second, adds 1 to the current time
    IEnumerator Count()
    {
        _time++;
        SetTime();
        yield return new WaitForSeconds(1);
        StartCoroutine(Count());
        yield return null;
    }

    // Updates the displayed timer
    void SetTime()
    {
        _timeString = _time.ToString();
        while (_timeString.Length < 3)
            _timeString = "0" + _timeString;
        _h.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/UI/" + _theme + "/Materials/" + _timeString[0]);
        _t.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/UI/" + _theme + "/Materials/" + _timeString[1]);
        _o.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/UI/" + _theme + "/Materials/" + _timeString[2]);
    }
}