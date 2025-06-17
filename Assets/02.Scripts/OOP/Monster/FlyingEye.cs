using UnityEngine;

public class FlyingEye : Monster
{
    protected override void Init()
    {
        this.HP = 2f;
        this.move_speed = 5f;
    }

}