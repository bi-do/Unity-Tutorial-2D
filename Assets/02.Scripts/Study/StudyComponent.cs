using Unity.VisualScripting;
using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    // 컴포넌트 요소 변경 및 게임 오브젝트와의 참조 구조 이해
    private GameObject temp_obj_bf;

    private GameObject temp_cube;

    private MeshRenderer temp_rend;

    [SerializeField]
    private string change_name;

    // 오브젝트 및 컴포넌트 코드상에서 생성
    private GameObject obj;

    public Mesh mesh;

    public Material mat;



    void Start()
    {
        this.obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.Component_Generate("hello");
        this.Component_Generate();
    }

    /// <summary> 컴포넌트 참조 구조 이해 및 컴포넌트 요소 변경</summary>
    public void Component_Ref()
    {
        this.temp_obj_bf = GameObject.FindGameObjectWithTag("Cube");

        this.temp_rend = this.temp_obj_bf.GetComponent<MeshRenderer>();

        this.temp_cube = this.temp_rend.gameObject;

        this.temp_cube.SetActive(false);

        this.temp_cube.name = this.change_name;
        this.temp_cube.transform.position += new Vector3(3, 3, 3);

        Debug.Log("오브젝트 이름 : " + this.temp_cube.name);
        Debug.Log("오브젝트 태그 : " + this.temp_cube.tag);
        Debug.Log("오브젝트 위치 : " + this.temp_cube.transform.position);
        Debug.Log("오브젝트 회전 : " + this.temp_cube.transform.rotation);
        Debug.Log("오브젝트 크기 : " + this.temp_cube.transform.localScale);

        Debug.Log($"Mesh 데이터 : {this.temp_cube.GetComponent<MeshFilter>().mesh}");
        Debug.Log($"Meterial 데이터 : {this.temp_cube.GetComponent<MeshRenderer>().material}");
    }

    /// <summary> 새로운 게임 오브젝트 및 컴포넌트 생성 </summary>
    public void Component_Generate(string parma_name = "Cube")
    {
        
        this.obj = new GameObject(parma_name);

        this.obj.AddComponent<MeshFilter>();
        this.obj.AddComponent<MeshRenderer>();
        this.obj.AddComponent<BoxCollider>();


        this.obj.transform.position += new Vector3(1, 1, 1);
        this.obj.GetComponent<MeshFilter>().mesh = this.mesh;
        this.obj.GetComponent<MeshRenderer>().material = this.mat;
    }
}
