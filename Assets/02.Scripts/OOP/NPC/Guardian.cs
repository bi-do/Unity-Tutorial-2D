using UnityEngine;

public class Guardian : NPC, IMove, IAttack
{
    public void Move()
    {
        Debug.Log("Move");
    }

    public void Attack()
    {
        Debug.Log("Attack");
    }

}