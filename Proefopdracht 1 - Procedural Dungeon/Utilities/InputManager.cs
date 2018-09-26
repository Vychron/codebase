using UnityEngine;
/// <summary>
/// Universal static input manager
/// </summary>
public static class InputManager
{
    public static bool Escape()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    public static bool Up()
    {
        return Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
    }

    public static bool Down()
    {
        return Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
    }

    public static bool Left()
    {
        return Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
    }

    public static bool Right()
    {
        return Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
    }

    public static bool DebugKey()
    {
        return Input.GetKey(KeyCode.Tab);
    }
    public static bool LeftMouse()
    {
        return Input.GetMouseButton(0);
    }
}
