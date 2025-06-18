using UnityEngine;

public class Skeleton : Monster
{
    protected override void Init_Childs()
    {
        this.HP = 3f;
        this.move_speed = 2f;
    }

}