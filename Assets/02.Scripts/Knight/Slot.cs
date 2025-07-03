using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    /// <summary> 아이템 슬롯 버튼 </summary>
    [SerializeField] private Button button_UI;
    /// <summary> 획득한 아이템 이미지를 띄울 컴포넌트 </summary>
    [SerializeField] private Image item_image_UI;
    /// <summary> 획득 아이템 </summary>
    private IItemObject item;

    public bool isEmpty = true;

    void Awake()
    {
        Debug.Log("호출");

    }

    void Start()
    {
        this.button_UI.onClick.AddListener(UseItem);
    }

    void OnEnable()
    {
        this.button_UI.interactable = !isEmpty;
        this.item_image_UI.gameObject.SetActive(!isEmpty);
    }

    public void AddItem(IItemObject param_new_item)
    {
        this.item = param_new_item;
        isEmpty = false;
        this.item_image_UI.sprite = param_new_item.Icon;
        this.item_image_UI.SetNativeSize();
    }

    public void UseItem()
    {
        if (this.item != null)
        {
            this.item.Use();
            this.ClearSlot();
        }
    }

    public void ClearSlot()
    {
        this.item = null;
        this.isEmpty = true;
        this.button_UI.interactable = !isEmpty;
        this.item_image_UI.gameObject.SetActive(!isEmpty);
    }


}
