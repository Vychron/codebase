using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static bool Up()
    {
        return Input.GetKey(KeyCode.W);
    }
    public static bool Down()
    {
        return Input.GetKey(KeyCode.S);
    }
    public static bool Left()
    {
        return Input.GetKey(KeyCode.A);
    }
    public static bool Right()
    {
        return Input.GetKey(KeyCode.D);
    }
    public static bool Use()
    {
        return Input.GetMouseButtonDown(0);
    }
    public static bool Drop()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }
    public static bool Debug()
    {
        return (Input.GetKeyDown(KeyCode.KeypadMinus) && Input.GetKey(KeyCode.KeypadPlus));
    }
    public static bool Inventory()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
    public static int Nums()
    {
        for (int i = 1; i < 9; i++)
        {
            if (Input.GetKeyDown("" + i))
            return i;
        }
        return 0;
    }
}