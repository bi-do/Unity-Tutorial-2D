using UnityEngine;

public class Material_LoopMap : MonoBehaviour
{
    private MeshRenderer mesh_renderer;

    public float move_speed = 0.5f;

    void Start()
    {
        // 메쉬 렌더러 변수 초기화
        this.mesh_renderer = this.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // offset 값 계산
        Vector2 offset = Vector2.right * move_speed * Time.deltaTime;

        // '렌더러'의 '메테리얼'에 접근하여 오프셋 세팅 ( 자신의 현재 offset + 실시간 offset 계산 값 )
        this.mesh_renderer.material.SetTextureOffset("_MainTex", this.mesh_renderer.material.mainTextureOffset + offset);
    }
}
