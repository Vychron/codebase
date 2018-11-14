using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Text _name, _counter, _number;
    [SerializeField] private Image _image;
    [SerializeField] private InventorySwap _swap;
    [SerializeField] private Inventory _inv;
    [SerializeField] private int _num;

    public void SetName(string name)
    {
        _name.text = name;
    }

    public void SetCounter(string counter)
    {
        _counter.text = counter;
    }

    public void SetTexture(Texture2D tex)
    {
        Sprite s = new Sprite();
        s = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        _image.sprite = s;
    }

    public void SetNumber(int num)
    {
        _num = num;
        _number.text = _num.ToString();
    }

    public void OnClick()
    {
        print(_num);
        _swap.SetItem(_inv.items[_num - 1], _num - 1);
        Inventory.RefreshInventory();
    }
}
