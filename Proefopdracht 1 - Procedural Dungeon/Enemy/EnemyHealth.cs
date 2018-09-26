using UnityEngine;
/// <summary>
/// Health management of an enemy
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    // Use this for initialization
    void Start()
    {
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
        EndScreenUI.kills++;
        UI.enemies--;
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Bullet")
            _health--;
    }
}
