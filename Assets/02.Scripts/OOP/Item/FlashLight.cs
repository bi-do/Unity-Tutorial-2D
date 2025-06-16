using UnityEngine;
public class FlashLight : MonoBehaviour, IDropItem
{
    public GameObject light_obj;
    public bool isLight;

    public void Grab()
    {
        Debug.Log("손전등을 주웠다.");

    }

    public void Drop()
    {
        Debug.Log("손전등을 버렸다.");
    }

    public void Use()
    {
        this.isLight = !this.isLight;
        this.light_obj.SetActive(this.isLight);

        Debug.Log("손전등을 킨다.");
    }
}