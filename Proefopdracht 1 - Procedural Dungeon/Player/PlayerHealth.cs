using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] private Image[] _health;
    [SerializeField] private static int _maxHealth = 3;
    [SerializeField] private int _invincibilityTime;
    private int _hitPoints = 2;
    private bool _invincible;

    private PlayerMovement _movement;

	// Use this for initialization
	void Start ()
    {
        _movement = GetComponent<PlayerMovement>();
        _movement.Hurt += TakeDamage;
	}

    void TakeDamage()
    {
        if (_invincible)
            return;

        if (_hitPoints <= 0)
            SceneManager.LoadScene(2);

        _health[_hitPoints].enabled = false;
        _hitPoints--;
        _invincible = true;
        StartCoroutine(CountDownInvincibility());
    }

    private IEnumerator CountDownInvincibility()
    {
        for (int i = 0; i < _invincibilityTime; i++)
            yield return new WaitForSeconds(1);

        _invincible = false;
        yield return null;
    }
}
