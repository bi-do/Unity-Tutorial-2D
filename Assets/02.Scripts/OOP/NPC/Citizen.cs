using UnityEngine;

public class Citizen : NPC, IMove, ITalk
{
    public void Move()
    {
        Debug.Log("Move");
    }

    public void Talk()
    {
        Debug.Log("Talk");
    }

}