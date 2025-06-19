using Unity.VisualScripting;
using UnityEngine;

public class Gold : MonoBehaviour, IItem
{
    private Inventory inventory;

    public GameObject Obj
    {
        get { return this.gameObject; }
    }

    public enum GoldType { Coin, Diamond, Chest }
    public GoldType gold_type;

    void Start()
    {
        this.inventory = FindFirstObjectByType<Inventory>();
    }

    void OnMouseDown()
    {
        this.Get();
    }

    public void Get()
    {
        Debug.Log($"{this.name}을 획득하였습니다.");
        this.inventory.AddItem(this);
        this.gameObject.SetActive(false);
        return;
    }


}