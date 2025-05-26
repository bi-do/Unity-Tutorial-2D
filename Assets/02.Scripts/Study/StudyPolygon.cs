using UnityEngine;

public class StudyPolygon : MonoBehaviour
{
    void Start()
    {
        // 새로운 Mesh 만들기
        Mesh mesh = new Mesh();

        // Mesh 점 찍기
        Vector3[] vec3_arr = new Vector3[]{
            new Vector3(0,0,0),
            new Vector3(1,0,0),
            new Vector3(0,1,0),
            new Vector3(1,1,0)
        };

        // Polygon 만들때 사용하는 인덱스
        int[] triangles = new int[] {
            0,2,1,
            2,3,1
        };

        // uv ( 앞 뒷면 정하기 ) 
        Vector2[] uv = new Vector2[]{
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,1),
            new Vector2(1,1)
        };

        // Mesh를 만들기 위해 필요한 데이터 할당
        mesh.vertices = vec3_arr;
        mesh.triangles = triangles;
        mesh.uv = uv;

        // Mesh Filter에 Mesh 적용
        MeshFilter meshFilter = this.gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        // Mesh Reenderer에 Matarial 적용
        MeshRenderer meshRenderer = this.gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Sprites/Default"));
    }

}
