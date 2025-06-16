using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDamageable>() != null)
        {

            other.GetComponent<IDamageable>().TakeDamage(10f);
        }
    }
}