using Unity.Mathematics;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform turret_head;

    private float theta;

    public float rot_speed = 2f;
    public float rot_range = 60f;

    private bool isTarget;
    public Transform target;

    void Update()
    {
        if (!isTarget)
        {
            TurretIdle();
        }
        else
            LookTarget();
    }

    private void TurretIdle()
    {
        theta += Time.deltaTime;

        float rotY = Mathf.Sin(theta) * rot_range;

        turret_head.localRotation = Quaternion.Euler(0, rotY, 0);
    }

    void LookTarget()
    {
        this.turret_head.transform.LookAt(target);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.target = other.transform;
            this.isTarget = true;

            Debug.Log("타겟 확인");
        }
    }
}
