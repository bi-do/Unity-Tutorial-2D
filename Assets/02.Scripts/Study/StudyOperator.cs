using UnityEngine;

public class StudyOperator : MonoBehaviour
{
    public int current_level = 10;

    public int maximum_level = 99;



    void Start()
    {
        string temp_log = this.current_level >= this.maximum_level ? "현재 레벨은 만렙입니다." : $"현재 레벨은 {this.current_level} 입니다.";

        Debug.Log(temp_log);

        current_level += this.current_level >= this.maximum_level ? 0 : 1;

        // bool is_max = this.current_level >= this.maximum_level;

        // if (is_max)
        // {
        //     Debug.Log("현재 레벨은 만렙입니다.");
        // }
        // else
        // {
        //     Debug.Log($"현재 레벨은 {this.current_level} 입니다");
        // }

    }


}
