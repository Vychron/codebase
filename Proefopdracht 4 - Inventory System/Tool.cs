using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tools are items, but have a different usage
/// </summary>

public class Tool : Item
{
    public override int Use(int cost)
    {
        return GetCount();
    }
}