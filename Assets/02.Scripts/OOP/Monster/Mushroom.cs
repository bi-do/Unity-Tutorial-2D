using UnityEngine;

public class Mushroom : Monster
{
    protected override void Init_Childs()
    {
        this.HP = 7f;
        this.move_speed = 2.5f;
    }
}