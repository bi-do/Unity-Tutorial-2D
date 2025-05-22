using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    public float destroy_time = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, this.destroy_time);
    }

    void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}가 파괴되었습니다");
    }
}
