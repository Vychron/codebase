using System.Collections;
using UnityEngine;
/// <summary>
/// A timer keeps track of how long the current session is active, this is the script that manages this timer
/// </summary>
public class Clock : MonoBehaviour
{
    [SerializeField] private GameObject _h, _t, _o; // hundreds, tens, ones
    private int _time;
    private string _timeString;

    // Stops the timer and puts it back to 0
    public void Clear()
    {
        End();
        _time = 0;
        SetTime();
    }

    // Start the timer on call
    public void Begin()
    {
        StartCoroutine(Count());
    }

    // Update the displayed time. It does not count by minutes, instead it counts by seconds like in the original game
    void SetTime()
    {
        _timeString = _time.ToString();
        while (_timeString.Length < 3)
        {
            _timeString = "0" + _timeString;
        }
        _h.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/Timer/Materials/" + _timeString[0]);
        _t.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/Timer/Materials/" + _timeString[1]);
        _o.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/Timer/Materials/" + _timeString[2]);
    }

    // Force the clock to stop the time, without resetting or restarting it.
    public void End()
    {
        StopAllCoroutines();
    }

    // Once activated, this coroutine calls itself every second to add 1 to the clock's current time.
    IEnumerator Count()
    {
        _time++;
        SetTime();
        yield return new WaitForSeconds(1);
        StartCoroutine(Count());
        yield return null;
    }
}
