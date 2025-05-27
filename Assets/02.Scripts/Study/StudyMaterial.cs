using UnityEngine;

public class StudyMaterial : MonoBehaviour
{
    // public Material mat;

    public string hexcode;

    void Start()
    {
        // Material을 바꾸는 방식 X
        // this.GetComponent<Material>() = mat; Material을 바꾸는 방식 X

        // MeshRenderer에 접근하여 메테리얼 변경
        // this.GetComponent<MeshRenderer>().Material = this.mat; 

        // 자신의 메쉬렌더러 메테리얼의 속성 변경
        // this.GetComponent<MeshRenderer>().material.color = Color.green; 

        // 자신이 갖고있는 메테리얼의 원본 데이터에 접근하여 영구적인 변경
        // this.GetComponent<MeshRenderer>().sharedMaterial.color = Color.green;

        // RGBA값으로 색상 직접 변경
        // this.GetComponent<MeshRenderer>().material.color = new Color(50f / 255f, 50f / 255f, 50f / 255f, 50f / 255f);

        Color_Hexcode();
    }

/// <summary> 컬러코드로 색상 변경 </summary>
    private void Color_Hexcode()
    {
         Material mat = this.GetComponent<MeshRenderer>().material;

        Color output_color;

        if (ColorUtility.TryParseHtmlString(this.hexcode, out output_color))
        {
            mat.color = output_color;
        }
    }


}
