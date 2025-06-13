using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.InitStatus();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void InitStatus()
    {
        Debug.Log("부모클래스");
    }

    virtual protected void Temp()
    {

    }
}
