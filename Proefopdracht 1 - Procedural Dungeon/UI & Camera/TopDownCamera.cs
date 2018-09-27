using System.Collections;
using UnityEngine;
/// <summary>
/// Zooms in on the player while the game is setting up
/// </summary>
public class TopDownCamera : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Light _dir, _spot;
    public static bool ready;

    // Use this for initialization
    void Start()
    {
        ready = false;
        _cam = GetComponent<Camera>();
        StartCoroutine(ZoomIn());
    }

    // A few visual features while setting up
    IEnumerator ZoomIn()
    {
        while (_cam.orthographicSize > 10)
        {
            _cam.orthographicSize-= 0.5f;
            yield return new WaitForSeconds(0.01f * Time.deltaTime);
            _dir.intensity -= 0.008f;
            _cam.transform.eulerAngles = Vector3.Lerp(_cam.transform.eulerAngles, Vector3.zero, 0.025f);
        }
        yield return new WaitForSeconds(20 * Time.deltaTime);
        _dir.gameObject.SetActive(false);
        _spot.gameObject.SetActive(true);
        _cam.transform.eulerAngles = Vector3.zero;
        GetComponentInParent<PlayerMovement>().enabled = true;
        GetComponentInParent<PlayerShoot>().enabled = true;
        ready = true;
        while (_spot.intensity > 1)
        {
            _spot.intensity = Mathf.Lerp(_spot.intensity, 1, 0.03f);
            yield return new WaitForSeconds(0.01f * Time.deltaTime);
        }
        
    }
}
