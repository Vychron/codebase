using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryUI : MonoBehaviour
{
    public InventorySlot[] inv;
    public Inventory inventory;

    // Use this for initialization
    void Start()
    {
        Init();
        Inventory.Refresh += Refresh;
        Refresh();
    }

    public virtual void Init()
    {

    }

    void Refresh()
    {
        for (int i = 0; i < inv.Length; i++)
        {
            inv[i].SetName("");
            inv[i].SetCounter("");
            inv[i].SetTexture(new Texture2D(64, 64));
            inv[i].SetNumber(i + 1);
            if (inventory.items.ElementAtOrDefault(i) != null)
            {
                inv[i].SetName(inventory.items[i].GetName());
                inv[i].SetCounter(inventory.items[i].GetCount().ToString() + "/" + inventory.items[i].GetMaxCount().ToString());
                inv[i].SetTexture(inventory.items[i].GetTexture());
            }
        }
    }
}
