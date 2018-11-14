using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    void Drop();
    int Use(int cost);
    string GetName();
    void SetName(string name);
    int GetCount();
    void SetCount(int newAmount);
    int GetMaxCount();
    void SetMaxCount(int m);
    void Add(int addedAmount);
}