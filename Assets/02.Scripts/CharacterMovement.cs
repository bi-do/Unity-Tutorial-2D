using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Burst.Intrinsics;
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
        // this.transform.position = this.transform.position + Vector3.forward;
        this.move_speed_sum = this.move_speed * Time.deltaTime;

        vector3s.Add(new Vector3(move_speed_sum, 0, 0));
        vector3s.Add(new Vector3(-move_speed_sum, 0, 0));
        vector3s.Add(new Vector3(0, 0, move_speed_sum));
        vector3s.Add(new Vector3(0, 0, -move_speed_sum));

        return;
    }

    // Update is called once per frame
    void Update()
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
        return;
    }
}
