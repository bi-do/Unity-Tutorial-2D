using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsters;

    [SerializeField]
    private GameObject[] items;

    private float timer = 3f;

    private int item_index;
    private int monster_index;
    private int random_x;
    private int random_y;
    private Vector3 random_pos;

    void Start()
    {
        this.OnSpwanMonster();
    }

    IEnumerator Spawn_Routine()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.timer);

            this.monster_index = Random.Range(0, this.monsters.Length);
            this.random_x = Random.Range(-8, 8);
            this.random_y = Random.Range(-3, 5);
            this.random_pos = new Vector3(random_x, random_y, 0);

            Instantiate(this.monsters[monster_index], this.random_pos, Quaternion.identity);
        }
    }

    public void OnDropCoin(Vector3 param_coin_pos)
    {
        this.item_index = Random.Range(0, this.items.Length);
        GameObject item = Instantiate(this.items[this.item_index], param_coin_pos, Quaternion.identity);

        Rigidbody2D item_rb = item.GetComponent<Rigidbody2D>();

        item_rb.AddForce(new Vector2(Random.Range(-2f, 2f), 3f), ForceMode2D.Impulse);

    }

    public void OnSpwanMonster()
    {
        StartCoroutine(this.Spawn_Routine());
    }
}
