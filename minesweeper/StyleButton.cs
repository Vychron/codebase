using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// When attatched to an object, it applies a new theme to the game when clicked on
/// </summary>
public class StyleButton : MonoBehaviour
{
    [SerializeField] private string _theme;
    
    // Delegate events
    public delegate void OnClick(string theme);
    public static event OnClick NewStyle;
    
    // If clicked, it tells to change the theme to the one defined in the _theme string
    void OnMouseDown()
    {
        if (NewStyle != null)
            NewStyle(_theme);
        GameObject.FindWithTag("Background").GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("My Sweeper/UI/" + _theme + "/Materials/bg");
    }
}
