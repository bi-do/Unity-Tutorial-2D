using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    float h;
    float v;
    /// <summary>  이동속도 </summary>
    public float move_speed = 3f;

    /// <summary> 현재 갖고 있는 아이템 </summary>
    public IDropItem current_item;

    [SerializeField]
    private Transform grab_pos;

    // Update is called once per frame
    void Update()
    {
        this.Move();
        this.Interaction();
    }

    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        this.transform.position += new Vector3(h, 0, v).normalized * move_speed * Time.deltaTime;
    }

    /// <summary> 아이템 상호작용 </summary>
    private void Interaction()
    {
        if (current_item == null)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.current_item.Use(); // 아이템 사용

            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                this.current_item.Drop(); // 아이템 버리기
                this.current_item = null;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDropItem>() != null && this.current_item == null)
        {
            IDropItem temp_item = other.GetComponent<IDropItem>();

            temp_item.Grab(this.grab_pos);

            this.current_item = temp_item;
        }

    }
}
