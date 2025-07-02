using UnityEngine;

public interface IItemObject
{
    ItemManager Inventory { get; set; }
    GameObject Obj { get; set; }
    string item_name { get; set; }
    Sprite icon { get; set; }

    void Get();
    void Set();
}
