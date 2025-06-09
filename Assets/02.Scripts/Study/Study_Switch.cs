using UnityEngine;

public class Study_Switch : MonoBehaviour
{
    public enum CalculationType
    {
        Plus,
        Minus,
        Multiply,
        Divide
    }
    public CalculationType Calculationtemp = CalculationType.Plus;

    public int input1, input2;



    void Start()
    {
        Debug.Log($"계산 결과 : {this.Calculation()}");
    }

    private int Calculation()
    {
        int value = 0;

        switch (Calculationtemp)
        {
            case CalculationType.Plus:
                value = this.input1 + this.input2;
                break;
            case CalculationType.Minus:
                value = this.input1 - this.input2;
                break;
            case CalculationType.Multiply:
                value = this.input1 * this.input2;
                break;
            case CalculationType.Divide:
                value = this.input1 / this.input2;
                break;
            default:
                break;
        }

        return value;
    }
}
