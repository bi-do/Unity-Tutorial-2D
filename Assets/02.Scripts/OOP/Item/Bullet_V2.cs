using UnityEngine;

public class Bullet_V2 : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("DestroyMe", 3f);
    }

    private void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}