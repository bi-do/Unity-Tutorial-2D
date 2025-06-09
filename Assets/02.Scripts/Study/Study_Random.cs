using UnityEngine;

public class Study_Random : MonoBehaviour
{
    void OnEnable()
    {
        float ran_num = Random.Range(0f,10f);

        Debug.Log(ran_num);
    }
}
