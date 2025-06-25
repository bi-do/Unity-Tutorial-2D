using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Vector3 start_pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Init()
    {
        this.start_pos = this.transform.localPosition;
    }

    public void InitColliderPos()
    {
        this.transform.localPosition = this.start_pos;
 
    }

    public void ColliderPosExit()
    {
        this.transform.localPosition += Vector3.up * 100;
    }
}
