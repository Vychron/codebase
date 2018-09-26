using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Manages the UI of the Main scene
/// </summary>
public class UI : MonoBehaviour
{
    public static int enemies, bullets;
    [SerializeField] private Text _enemyCount, _bulletCount;

    // Use this for initialization
    void Start()
    {
        bullets = 0;
        EndScreenUI.crateHits = 0;
        EndScreenUI.crates = 0;
        EndScreenUI.enemyHits = 0;
        EndScreenUI.kills = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _enemyCount.text = enemies.ToString();
        _bulletCount.text = bullets.ToString();
        if(enemies == 0 && bullets > 0)
            SceneManager.LoadScene(1);
    }
}
