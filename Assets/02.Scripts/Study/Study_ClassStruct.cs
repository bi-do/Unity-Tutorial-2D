using Unity.VisualScripting;
using UnityEngine;

public class Study_Class
{
    public int member_id;

    public Study_Class(int param)
    {
        this.member_id = param;
    }
}

public struct Study_Data
{
    public int member_id;

    public Study_Data(int param)
    {
        this.member_id = param;
    }

}

public class Study_ClassStruct : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Debug.Log("클래스----------");
        Study_Class c1 = new Study_Class(10);
        Study_Class c2 = c1;

        c1.member_id = 5;
        Debug.Log($"C1은 {c1.member_id} , C2는 {c2.member_id}");

        Debug.Log("구조체----------");
        Study_Data d1 = new Study_Data(10);
        Study_Data d2 = d1;
        d1.member_id = 5;
        Debug.Log($"d1은 {d1.member_id} , d2는 {d2.member_id}");

    }
}
