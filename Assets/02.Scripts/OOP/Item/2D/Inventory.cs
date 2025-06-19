using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> items = new List<GameObject>();

    public void AddItem(IItem param_item)
    {
        this.items.Add(param_item.Obj);
    }
}
