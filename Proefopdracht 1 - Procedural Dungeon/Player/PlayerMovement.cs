using UnityEngine;
/// <summary>
/// Handles the movement of the player and handles collision
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _minSpeed, _maxSpeed;
    private float _horSpeed, _verSpeed;

    public delegate void GetHurt();
    public event GetHurt Hurt;

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Up() && Mathf.Abs(_verSpeed) < _maxSpeed)
            _verSpeed += 0.0125f;

        else if (InputManager.Down() && Mathf.Abs(_verSpeed) < _maxSpeed)
            _verSpeed -= 0.0125f;

        else
            _verSpeed = Mathf.Lerp(_verSpeed, 0, 0.125f);

        if (InputManager.Left() && Mathf.Abs(_horSpeed) < _maxSpeed)
            _horSpeed -= 0.0125f;

        else if (InputManager.Right() && Mathf.Abs(_horSpeed) < _maxSpeed)
            _horSpeed += 0.0125f;

        else
            _horSpeed = Mathf.Lerp(_horSpeed, 0, 0.125f);

        if (Mathf.Abs(_horSpeed) < _minSpeed)
            _horSpeed = 0;

        if (Mathf.Abs(_verSpeed) < _minSpeed)
            _verSpeed = 0;

        transform.Translate(new Vector2(_horSpeed, _verSpeed) * Time.timeScale);
    }

    void OnCollisionStay(Collision other)
    {
        if (other.collider.tag != "Enemy")
        {
            if (Mathf.Abs(other.transform.position.x - transform.position.x) < 0.75)
                _verSpeed = 0;

            if (Mathf.Abs(other.transform.position.y - transform.position.y) < 0.75)
                _horSpeed = 0;
        }
        else
            if (Hurt != null)
                Hurt();
    }
}
