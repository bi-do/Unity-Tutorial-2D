using UnityEngine;

public class DoorEvent_2 : MonoBehaviour
{
    private Animator animator;

    public string open_key;
    public string close_key;


    void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.animator.SetTrigger(this.open_key);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.animator.SetTrigger(this.close_key);
        }
    }

}
