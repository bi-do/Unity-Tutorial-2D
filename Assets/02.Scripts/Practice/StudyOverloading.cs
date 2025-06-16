using UnityEngine;

public class StudyOverloading : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.Attack();
        this.Attack(true);
        this.Attack(10);

        GameObject monster = new GameObject("몬스터");

        this.Attack(15, monster);

        Attack();


    }

    public void Attack()
    {
        Debug.Log("공격");
    }

    public void Attack(bool param_isMagic)
    {
        if (param_isMagic)
            Debug.Log("마법공격");
    }

    public void Attack(int param_damage)
    {
        Debug.Log($"{param_damage} 피해의 공격 ");
    }

    public void Attack(int param_damage , GameObject param_target)
    {
        Debug.Log($"{param_target.name}에게 {param_damage} 피해의 공격");
    }
}
