using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySwap : MonoBehaviour
{
    private Item[] _items;
    private int[] _pos;
    private int _current;
    [SerializeField] private Inventory _inv;
    [SerializeField] private GameObject _swapper;
    [SerializeField] private InventorySlot[] _slots;
    public void Swap()
    {
        _slots[0].SetName("");
        _slots[0].SetCounter("");
        _slots[0].SetTexture(new Texture2D(64, 64));
        _slots[1].SetName("");
        _slots[1].SetCounter("");
        _slots[1].SetTexture(new Texture2D(64, 64));
        _swapper.SetActive(!_swapper.activeSelf);
        Start();
    }

    public void ConfirmSwap()
    {
        _inv.RemoveItem(_pos[0]);
        _inv.RemoveItem(_pos[1]);
        _inv.AddItem(_items[0], _pos[1]);
        _inv.AddItem(_items[1], _pos[0]);
        Swap();
        Inventory.RefreshInventory();
    }

    public void SetItem(Item item, int pos)
    {
        print(_current);
        _items[_current] = item;
        _slots[_current].SetTexture(item.GetTexture());
        _slots[_current].SetName(item.GetName());
        _slots[_current].SetCounter(item.GetCount().ToString());
        _pos[_current] = pos;
        _current++;
        if (_current > 1) _current = 0;
    }

    // Use this for initialization
    void Start()
    {
        _current = 0;
        _items = new Item[2];
        _pos = new int[2];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
