using System.Collections.Generic;
using UnityEngine;

public class StudyArray : MonoBehaviour
{

    public float[] array_num = new float[5] { 1, 2, 3, 4, 5 };

    public List<int> list_num = new List<int>();

    public int list_count = 10;

    [SerializeField]
    private int temp = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.ListInitialize();

        int arr_index = 0;
        int list_index = 0;

        foreach (float element in this.array_num)
        {
            Debug.Log($"배열 -> {arr_index} 번째 인덱스 값 : " + element);
            arr_index++;
        }

        foreach (int element in this.list_num)
        {
            Debug.Log($"리스트 -> {list_index} 번째 인덱스 값 : " + element);
            list_index++;
        }

        Debug.Log($"배열 크기 : {this.array_num.Length} , 리스트 크기 : {this.list_num.Count}");
    }

    private void ListInitialize()
    {
        for (int i = 0; i < list_count; i++)
        {
            list_num.Add(i + 1);
        }
        Debug.Log("리스트 초기화 완료");
    }
}
