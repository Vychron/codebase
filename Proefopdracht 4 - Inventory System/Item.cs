using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IItem
{
    [SerializeField] private string _name;
    [SerializeField] private int _count, _maxCount;
    private Texture2D _tex;
    private Renderer _rend;

    void Start()
    {
        SetMaxCount(_maxCount);
        _rend = GetComponent<Renderer>();
    }

    public void Drop()
    {

    }

    public virtual int Use(int cost)
    {
        if (_count >= cost)
        {
            _count -= cost;
        }
        Inventory.RefreshInventory();
        return _count;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public int GetCount()
    {
        return _count;
    }

    public void SetCount(int c)
    {
        _count = c;
        Limit();
    }

    public int GetMaxCount()
    {
        return _maxCount;
    }

    public void SetMaxCount(int m)
    {
        if (m < 0)
        {
            _maxCount = int.MaxValue;
            return;
        }
        _maxCount = m;
    }

    public void SetImage(Texture2D tex)
    {
        _tex = tex;
    }

    public Texture2D GetTexture()
    {
        return _tex;
    }

    public void Add(int a)
    {
        _count += a;
        Limit();
    }

    void Limit()
    {
        if (_count > _maxCount)
        {
            _count = _maxCount;
        }
    }
}
