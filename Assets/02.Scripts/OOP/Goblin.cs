using UnityEngine;

public class Goblin : Monster
{
    protected new void InitStatus()
    {
        Debug.Log("자식클래스");
    }
}
