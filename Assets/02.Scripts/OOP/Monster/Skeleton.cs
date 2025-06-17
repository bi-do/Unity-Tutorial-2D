using UnityEngine;

public class Skeleton : Monster
{
    protected override void Init()
    {
        this.HP = 15f;
        this.move_speed = 2f;
    }

}