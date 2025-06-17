using UnityEngine;

public class StudyProperty : MonoBehaviour
{
    [Range(0,10)]
    [field:SerializeField]
    private int move_speed = 10;
    public int Move_speed{
        get{ return move_speed; }
        set{ move_speed = value; }
    }

}
