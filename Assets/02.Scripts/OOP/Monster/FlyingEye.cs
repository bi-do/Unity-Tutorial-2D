using UnityEngine;

public class FlyingEye : Monster
{
    protected override void Init_Childs()
    {
        this.HP = 3f;
        this.move_speed = 5f;
    }

}