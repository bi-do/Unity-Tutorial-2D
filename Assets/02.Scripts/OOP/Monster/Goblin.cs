using UnityEngine;

public class Goblin : Monster
{
    protected override void Init()
    {
        this.HP = 3f;
        this.move_speed = 3f;
    }
}
