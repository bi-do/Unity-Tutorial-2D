using UnityEngine;

public class HpPotion : MonoBehaviour, IItemObject
{
    public ItemManager Inventory { get; set; }
    public GameObject Obj { get; set; }
    public string item_name { get; set; }
    public Sprite icon { get; set; }

    public void Get()
    {
        gameObject.SetActive(false);
        this.Inventory.InsertInventory(this);
        Debug.Log("획득");
    }

    public void Set()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.Inventory = FindFirstObjectByType<ItemManager>();
        this.Obj = this.gameObject;
        this.item_name = this.name;
        this.icon = this.GetComponent<SpriteRenderer>().sprite;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Get();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
