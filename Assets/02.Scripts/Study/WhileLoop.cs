using UnityEngine;

public class WhileLoop : MonoBehaviour
{
    public int count = 0;

    void Start()
    {
        // while (this.count < 10)
        // {
        //     this.count++;
        //     Debug.Log($"현재 카운트는 {this.count}");
        // }

        do
        {

            this.count++;
            Debug.Log($"현재 카운트는 {this.count}");
        } while (count < 7);
    }
}
