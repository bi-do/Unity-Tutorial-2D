using TreeEditor;
using UnityEngine;

public class CatFollow : MonoBehaviour
{
    public Transform cat;
    private Vector3 offset;

    void Start()
    {
        this.offset = new Vector3(0, -0.9f, -3f);
    }
    void Update()
    {
        this.transform.position = this.cat.position + this.offset;
    }
}
