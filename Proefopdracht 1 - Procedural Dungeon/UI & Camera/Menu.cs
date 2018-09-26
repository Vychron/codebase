using UnityEngine;
/// <summary>
/// Toggles the menu when Escape is pressed
/// </summary>
public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttons;
    public static bool isActive;

    void Start()
    {
        Time.timeScale = 1;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Escape())
            ToggleMenu();
    }

    // shows or hides the menu, and pauses the scene accordingly
    public void ToggleMenu()
    {
        isActive = !isActive;
        for (int i = 0; i < _buttons.Length; i++)
            _buttons[i].SetActive(isActive);
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
