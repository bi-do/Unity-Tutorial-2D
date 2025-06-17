using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
public class Gun : MonoBehaviour, IDropItem
{
    public GameObject bullet_prefab;
    public Transform shot_pos;

    public void Grab(Transform param_grab_pos)
    {
        this.transform.SetParent(param_grab_pos);
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.identity;
        Debug.Log("총을 주웠다.");
    }

    public void Drop()
    {
        transform.SetParent(null);
        this.transform.position = Vector3.zero;
        Debug.Log("총을 버렸다.");
    }
    public void Use()
    {
        GameObject bullet = Instantiate(this.bullet_prefab, this.shot_pos.position, Quaternion.identity);
        Rigidbody bullet_rb = bullet.GetComponent<Rigidbody>();

        bullet_rb.AddForce(Vector3.forward * 100f , ForceMode.Impulse);

        Debug.Log("총을 발사한다.");
    }
}