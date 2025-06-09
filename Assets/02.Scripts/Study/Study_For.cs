using System.Collections.Generic;
using UnityEngine;

public class Study_For : MonoBehaviour
{
    public int[] ints = new int[5];

    public List<int> ints2 = new List<int>();
    void Start()
    {
        // for (int i = 0; i < this.ints.Length; i++)
        // {
        //     Debug.Log(this.ints[i]);
        // }

        // for (int i = 0; i < this.ints2.Count; i++)
        // {
        //     Debug.Log(ints2[i]);
        // }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Debug.Log($"{i} / {j}");
            }
        }
    }
}
