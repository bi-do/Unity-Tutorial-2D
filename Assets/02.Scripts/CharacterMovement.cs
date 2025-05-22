using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Burst.Intrinsics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    public float move_speed = 0f;

    /// <summary> 실제 적용되는 이동 속도 ( 설정 이동 속도 * deltatime )</summary>
    private float move_speed_sum = 0;

    /// <summary> 방향 키 코드 배열 </summary>
    private KeyCode[] key_code_arr = {
        KeyCode.D,
        KeyCode.A,
        KeyCode.W,
        KeyCode.S };

    /// <summary> 적용되는 벡터 값 배열 </summary>
    private List<Vector3> vector3s = new List<Vector3>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // this.Input_Custom_Initialize();
        return;
    }

    // Update is called once per frame
    void Update()
    {
        this.Input_Legacy();
        return;
    }

    /// <summary> 인풋_사용자 지정 초기화 </summary>
    private void Input_Custom_Initialize()
    {
        this.move_speed_sum = this.move_speed * Time.deltaTime;

        vector3s.Add(new Vector3(move_speed_sum, 0, 0));
        vector3s.Add(new Vector3(-move_speed_sum, 0, 0));
        vector3s.Add(new Vector3(0, 0, move_speed_sum));
        vector3s.Add(new Vector3(0, 0, -move_speed_sum));
    }

    /// <summary> 인풋_사용자 지정 </summary>
    private void Input_Custom()
    {
        int index = 0;
        foreach (Vector3 element in this.vector3s)
        {
            if (Input.GetKey(this.key_code_arr[index]))
            {
                this.transform.position += element;
            }
            index++;
        }
        Debug.Log(this.transform.position);
    }

    /// <summary> 인풋 시스템 활용 ( Legacy ) </summary>
    private void Input_Legacy()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 temp_vec3 = new Vector3(h, 0, v);
        Debug.Log($"현재 입력 : {temp_vec3}");

        this.transform.position += temp_vec3 * this.move_speed * Time.deltaTime;
    }
}
