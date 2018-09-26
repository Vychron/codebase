using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Manages the UI of the End scene
/// </summary>
public class EndScreenUI : MonoBehaviour
{
    public static int crateHits, crates, enemyHits, kills;
    private int _hits;
    private float _hitRatio;
    [SerializeField] private Text _enemyCount, _bulletCount, _crateCount, _enemyHits, _crateHits, _kills, _hitRate;

    void Start()
    {
        _enemyCount.text = UI.enemies.ToString();
        _bulletCount.text = UI.bullets.ToString();
        _crateCount.text = crates.ToString();
        _crateHits.text = crateHits.ToString();
        _enemyHits.text = enemyHits.ToString();
        _kills.text = kills.ToString();
        _hitRatio = Mathf.Round(100f * ((float)(crateHits + enemyHits) / UI.bullets));
        _hitRate.text = _hitRatio.ToString() + "%";
    }
}
