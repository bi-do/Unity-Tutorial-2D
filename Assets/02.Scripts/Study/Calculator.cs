using UnityEngine;

public class Calculator : MonoBehaviour
{
    public int num1, num2 = 0;
    void Start()
    {
        this.num1 = 100;
        this.num2 = 50;
        Debug.Log($"ADD : {this.Add(this.num1, this.num2)} , MINUS : {this.Minus(this.num1, this.num2)}");
    }

    public int Add(int param1, int param2)
    {
        return param1 + param2;
    }

    public int Minus(int param1, int param2)
    {
        return param1 - param2;
    }




}
