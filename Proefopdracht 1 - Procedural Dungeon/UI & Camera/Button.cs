using UnityEngine.SceneManagement;
using UnityEngine;
/// <summary>
/// In here all the methods executed by the buttons are defined, all in one place because each button only uses a single method, equal to their name
/// </summary>
public class Button : MonoBehaviour
{
    // Close the menu to continue
    public void Continue()
    {
        GetComponentInParent<Menu>().ToggleMenu();
    }

    // Restart the scene
    public void Restart()
    {
        UI.enemies = 0;
        SceneManager.LoadScene(1);
    }

    // Forfeit and go to end screen
    public void Stop()
    {
        SceneManager.LoadScene(2);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Options()
    {
        SceneManager.LoadScene(3);
    }
}
