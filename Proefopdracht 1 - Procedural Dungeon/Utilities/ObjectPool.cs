using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A universal object pool, can be used for anything
/// </summary>
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool pool;
    [Tooltip("What is the pool filled with?")]
    public GameObject contents;
    [Tooltip("What is the amount of pooled objects?")]
    public int amount;
    [Tooltip("Can the pool adjust it's size when asked for more objects than it contains?")]
    public bool dynamic;
    private List<GameObject> _objects;

    void Awake()
    {
        pool = this;
    }

    // Use this for initialization
    void Start()
    {
        _objects = new List<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(contents);
            obj.SetActive(false);
            _objects.Add(obj);
        }
    }

    // returns an object from the pool if available
    public GameObject GetObject()
    {
        for(int i = 0; i < _objects.Count; i++)
            if (!_objects[i].activeInHierarchy)
                return _objects[i];
        if (dynamic)
        {
            GameObject obj = Instantiate(contents);
            _objects.Add(obj);
            return obj;
        }
        return null;
    }
}
