using System;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rouletteSpeed = 0f;
    private bool isStop = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.rouletteSpeed = 100f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.isStop = true;
        }

        if (this.isStop)
        {
            this.rouletteSpeed *= 0.98f;

            if (this.rouletteSpeed < 0.005f)
            {
                this.rouletteSpeed = 0f;
                this.isStop = false;
            }
        }

        this.transform.Rotate(this.transform.forward * this.rouletteSpeed * Time.deltaTime * -1);
    }

    // void StopTurn()
    // {

    // }

    // void StartTurn()
    // {

    // }
}
