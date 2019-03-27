using UnityEngine;
/// <summary>
/// Health management of an enemy
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private bool _requiredToWin;
    // Use this for initialization
    void Start()
    {
        if (_requiredToWin)
            UI.enemies++;
    }

    // Update is called once per frame
    void Update()
    {
        if (_health < 1)
            Die();
    }

    // Tells the Scoreboard it died before destroying itself
    void Die()
    {
        if (_requiredToWin)
        {
            EndScreenUI.kills++;
            UI.enemies--;
        }

        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Bullet")
            _health--;
    }
}
