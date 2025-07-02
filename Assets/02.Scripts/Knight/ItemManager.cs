using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] items;
    private List<IItemObject> inventory;

    private int item_index;
    public void OnDropItem(Vector3 param_drop_pos)
    {
        this.item_index = Random.Range(0, this.items.Length);
        GameObject item = Instantiate(this.items[this.item_index], param_drop_pos, Quaternion.identity);

        Rigidbody2D item_rb = item.GetComponent<Rigidbody2D>();

        item_rb.AddForce(new Vector2(Random.Range(-2f, 2f), 3f), ForceMode2D.Impulse);

        float ran_power = Random.Range(-1.5f, 1.5f);
        item_rb.AddTorque(ran_power, ForceMode2D.Impulse);
    }

    public void InsertInventory(IItemObject param_item)
    {
    }

}


