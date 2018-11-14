using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void UpdateInventory();
    public static UpdateInventory Refresh;

    public Item[] items;

    [Tooltip("Does the inventory allow stacking items?")]
    [SerializeField] private bool _stackable;

    [Tooltip("Amount of inventory slots")]
    [SerializeField] private int _invSize;

    // Use this for initialization
    void Start ()
    {
        items = new Item[_invSize];
        RefreshInventory();
    }

    public static void RefreshInventory()
    {
        if (Refresh != null)
        {
            Refresh();
        }
    }

    public void AddItem(Item item, int pos = -1)
    {
        if (pos != -1)
        {
            items[pos] = item;
            return;
        }
        int lastEmpty = items.Length;
        for (int i = items.Length-1; i > -1; i--)
        {
            if (items[i] == null)
            {
                lastEmpty = i;
            }
            if (_stackable)
            {
                if (items[i] != null && items[i].GetName() == item.GetName())
                {
                    int stackCapacity = items[i].GetMaxCount() - items[i].GetCount();
                    if (stackCapacity > 0)
                    {
                        AddToStack(item, items[i], stackCapacity);
                        return;
                    }
                }
            }
        }
        if (lastEmpty < items.Length)
        {
            items[lastEmpty] = item; 
        }
        RefreshInventory();
    }

    void AddToStack(Item pickup, Item stack, int capacity)
    {
        if (pickup.GetCount() <= capacity)
        {
            stack.Add(pickup.GetCount());
            Destroy(pickup.gameObject);
            RefreshInventory();
            return;
        }
        stack.Add(capacity);
        pickup.Add(-capacity);
        RefreshInventory();
        AddItem(pickup);
    }

    public void RemoveItem(int position)
    {
        items[position] = null;
        RefreshInventory();
    }

    public int GetSize()
    {
        return _invSize;
    }
}
