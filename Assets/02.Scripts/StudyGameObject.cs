using Unity.Mathematics;
using UnityEngine;

public class StudyGameObject : MonoBehaviour
{
    public GameObject prefab = null;

    public Vector3 pos = Vector3.zero;

    public Quaternion rot = Quaternion.identity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GenerateAmongUs();
    }

    /// <summary> 어몽어스 캐릭터 생성 </summary>
    private void GenerateAmongUs()
    {
        GameObject obj = Instantiate(this.prefab, this.pos, this.rot);
        obj.name = "어몽어스 캐릭터";

        Transform objtf = obj.transform;

        int c_count = objtf.childCount;

        Debug.Log($"자식 오브젝트의 수 : {c_count}");

        Debug.Log($"첫째 자식 오브젝트의 이름 : {objtf.GetChild(0).name}");

        Debug.Log($"마지막 자식 오브젝트의 이름 : {objtf.GetChild(c_count - 1).name}");

        // GameObject가 줄 수 있는 정보를 TransForm도 줄 수 있는 듯 함.
        // .gameObject를 거치지 않아도 바로 다이렉트로 줄 수 있는건 왜그런건지 모르겠음 ( C++에는 없는 문법인듯 ? ) 
        Debug.Log($"이름 : {objtf.name} , 태그 : {objtf.tag}");
    }
    
}
