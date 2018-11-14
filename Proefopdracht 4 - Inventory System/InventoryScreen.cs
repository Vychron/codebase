using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreen : InventoryUI
{
    [SerializeField] private GameObject _invScreen;
    private InventorySlot[] _inv;
    private int _size;
    public static bool inventoryActive = true;

    public override void Init()
    {
        Toggle();
    }

    public void Toggle()
    {
        _invScreen.SetActive(!inventoryActive);
        inventoryActive = !inventoryActive;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Inventory())
        {
            Toggle();
        }
    }
}
