using UnityEngine;

public abstract class Monster :MonoBehaviour, IDamageable
{
    public float hp = 10f;

    public abstract void SetHealth();

    public void TakeDamage(float param_damage)
    {
        hp -= param_damage;
        if (hp <= 0)
        {
            this.Death();
        }
    }

    public void Death()
    {
        Debug.Log("");
    }
}
