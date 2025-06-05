using TMPro;
using UnityEngine;

public class NumberKeyPad : MonoBehaviour
{
    /// <summary> 비밀번호 </summary>
    public string password;

    /// <summary> 입력버퍼 </summary>
    public string input_buf;

    public GameObject UI_doorlock;

    public TextMeshProUGUI output_UI;

    public DoorEvent_2 door_event;

    public string door_ani_key;

    public void OnInputNum(string param)
    {
        this.input_buf += param;
        this.output_UI.text = input_buf;
        Debug.Log($"현재 입력된 문자는 \"{param}\" 입니다.");
    }

    public void OnCheckNum()
    {
        if (this.input_buf == this.password)
        {
            this.output_UI.text = "Success";

            this.door_event.DoorOpen();

            this.UI_doorlock.SetActive(false);

            Debug.Log("문 열림");
        }
        else
        {
            this.input_buf = "";
            this.output_UI.text = "";
            Debug.Log("패스워드 틀림");
        }
    }
}
