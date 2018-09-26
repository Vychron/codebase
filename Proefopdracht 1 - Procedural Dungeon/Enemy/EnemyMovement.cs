using UnityEngine;
/// <summary>
/// Lets the enemies move around and chase the player
/// </summary>
public class EnemyMovement : MonoBehaviour
{
    private float _speed;
    [SerializeField] private float _minSpeed, _maxSpeed;
    private Vector2 _dir;
    private Transform _player;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!TopDownCamera.ready)
            return;
        if (Vector2.Distance(transform.position, _player.position) < 6)
            Chase();
        else
            Wander();
    }

    // Chase the player while close enough
    void Chase()
    {
        _speed = Mathf.Lerp(_speed, _maxSpeed, 0.001f);
        _dir = new Vector2(transform.position.x - _player.position.x, transform.position.y - _player.position.y);
        transform.Translate(-Vector3.Normalize(_dir) * _speed * Time.timeScale);
    }

    // Wander around
    void Wander()
    {
        _speed = Mathf.Lerp(_speed, _minSpeed, 0.001f);
        _dir = new Vector2(Random.Range(_dir.x - 0.5f, _dir.x + 0.5f), Random.Range(_dir.y - 0.5f, _dir.y + 0.5f));
        transform.Translate(Vector3.Normalize(_dir) * _speed * Time.timeScale);
    }

    void OnCollisionStay(Collision other)
    {
        if (Mathf.Abs(other.transform.position.x - transform.position.x) < 0.75)
            _dir.y = 0;
        if (Mathf.Abs(other.transform.position.y - transform.position.y) < 0.75)
            _dir.x = 0;
    }
}
