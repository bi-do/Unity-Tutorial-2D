using UnityEngine;
using UnityEngine.PlayerLoop;

public class DoorEvent_2 : MonoBehaviour
{
    private Animator animator;

    public GameObject UI_doorlock;

    public string open_key;
    public string close_key;

    private bool isopen = false;


    void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.UI_doorlock.SetActive(true);

            // this.animator.SetTrigger(this.open_key);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.isopen)
            {
                this.DoorClose();
            }
            this.UI_doorlock.SetActive(false);
            // this.animator.SetTrigger(this.close_key);
        }
    }

    public void DoorOpen()
    {
        this.animator.SetTrigger(open_key);
        this.isopen = true;
    }

    public void DoorClose()
    {
        this.animator.SetTrigger(close_key);
        this.isopen = false;
    }

}
