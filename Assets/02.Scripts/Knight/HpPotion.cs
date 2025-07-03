using UnityEngine;

public class HpPotion : MonoBehaviour, IItemObject
{
    public ItemManager Inventory { get; set; }
    public GameObject Obj { get; set; }
    public string item_name { get; set; }
    public Sprite Icon { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.Inventory = FindFirstObjectByType<ItemManager>();

        this.Obj = this.gameObject;
        this.item_name = this.name;
        this.Icon = this.GetComponent<SpriteRenderer>().sprite;
        if (this.Icon != null)
        {
            Debug.Log("아이템 생성완료");
        }

    }

    public void Get()
    {

        gameObject.SetActive(false);
        this.Inventory.InsertInventory(this);
        Debug.Log("획득");
    }

    public void Use()
    {
        Debug.Log("아이템 사용");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Get();
        }
    }
}
