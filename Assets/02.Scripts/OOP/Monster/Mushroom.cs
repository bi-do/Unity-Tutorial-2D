using UnityEngine;

public class Mushroom : Monster
{
    protected override void Init()
    {
        this.HP = 7f;
        this.move_speed = 2.5f;
    }
}