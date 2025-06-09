using UnityEngine;

public class Study_Foreach : MonoBehaviour
{
    public string[] persons = new string[5] { "철수", "영희", "동수", " 일렉스", "체키" };

    public string findName;
    void Start()
    {
        this.FindPerson(this.findName);

        // int count = 0;
        // foreach (string element in this.persons)
        // {
        //     count++;

        //     if (count == 3)
        //     {
        //         continue;
        //     }
        //     Debug.Log(element);
        // }
    }

/// <summary> 사람 찾기 </summary>
    private void FindPerson(string param)
    {
        foreach (string element in this.persons)
        {
            if (element == param)
            {
                Debug.Log($"인원중에 {element}이 존재합니다.");
                return;
            }
        }
        Debug.Log($"찾으시는 이름이 존재하지 않습니다. 검색 대상 : {param}");
    }
}
