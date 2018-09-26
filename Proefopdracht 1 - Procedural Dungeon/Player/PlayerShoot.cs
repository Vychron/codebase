using UnityEngine;
/// <summary>
/// Handles the shoot function of the player
/// </summary>
public class PlayerShoot : MonoBehaviour
{
    private int _currentRate = 0;
    [SerializeField] private int _fireRate;
    // Use this for initialization
    void Update()
    {
        if (InputManager.LeftMouse() && !Menu.isActive)
            if (_currentRate <= 0)
            {
                _currentRate = _fireRate;
                Shoot();
            }
        _currentRate--;
    }

    // Shoot a projectile towards your mouse position
    void Shoot()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject obj = ObjectPool.pool.GetObject();
        if (obj == null)
            return;
        obj.transform.position = transform.position;
        obj.transform.LookAt(mousePos);
        obj.SetActive(true);
        UI.bullets++;
    }
}
