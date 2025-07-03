using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory_UI;
    [SerializeField] private Button inventory_btn;

    /// <summary> 드랍 아이템 종류 </summary>
    [SerializeField] private GameObject[] items;

    /// <summary> 인벤토리 슬롯 배열 </summary>
    [SerializeField] private Slot[] slots;

    /// <summary> 슬롯 할당용 부모 그룹 오브젝트 </summary>
    [SerializeField] private Transform slot_group;

    private int item_index;

    void Start()
    {
        this.slots = this.slot_group.GetComponentsInChildren<Slot>(true);

        inventory_btn.onClick.AddListener(OnInventory);
    }

    /// <summary> 인벤토리 On/Off 토글 함수 </summary>
    public void OnInventory()
    {
        this.inventory_UI.SetActive(!this.inventory_UI.activeSelf);
    }

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
        foreach (Slot element in this.slots)
        {
            if (element.isEmpty)
            {
                element.AddItem(param_item);
                break;
            }
        }
    }

}


