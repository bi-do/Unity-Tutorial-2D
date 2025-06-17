using UnityEngine;
public class FlashLight : MonoBehaviour, IDropItem
{
    public GameObject light_obj;
    public bool isLight = false;

    public void Grab(Transform param_grab_pos)
    {
        this.transform.SetParent(param_grab_pos);
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.identity;
        Debug.Log("손전등을 주웠다.");

    }

    public void Drop()
    {
        transform.SetParent(null);
        this.transform.position = Vector3.zero;
        Debug.Log("손전등을 버렸다.");
    }

    public void Use()
    {
        this.isLight = !this.isLight;
        this.light_obj.SetActive(this.isLight);

        Debug.Log("손전등을 킨다.");
    }
}