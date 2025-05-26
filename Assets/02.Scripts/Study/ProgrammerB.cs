using UnityEngine;
using DevA;
using System.Security.Cryptography;

public class ProgrammerB : MonoBehaviour
{
    public ProgrammerA tempA = null;

    void Start()
    {
        if (tempA != null)
        {
            this.tempA.num2 = 0;
        }
        else
        {
            Debug.LogError("tempa 는 Null 을 참조하고 있습니다.");
        }
    }
}
