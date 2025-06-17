using UnityEngine;

public class Character : MonoBehaviour
{
    public IDropItem current_item;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.current_item.Use();
           
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            this.current_item.Drop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDropItem>() != null)
        {
            IDropItem temp_item = other.GetComponent<IDropItem>();

            // temp_item.Grab(this.param_grab_pos);

            this.current_item = temp_item;
        }

    }
}
