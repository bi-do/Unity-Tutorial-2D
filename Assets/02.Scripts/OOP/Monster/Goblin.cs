using UnityEngine;

public class Goblin : Monster
{
    protected override void Init_Childs()
    {
        this.HP = 3f;
        this.move_speed = 3f;
    }
}
