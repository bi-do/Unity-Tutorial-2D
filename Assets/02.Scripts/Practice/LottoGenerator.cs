using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class LottoGenerator : MonoBehaviour
{
    public List<int> ints_list = new List<int>();

    public int max_num = 45;

    public int shake_count = 1000;

    private string result = "이번 주 당첨 번호는 ";

    IEnumerator Start()
    {
        for (int i = 0; i < max_num; i++)
        {
            this.ints_list.Add(i + 1);
        }

        for (int i = 0; i < this.shake_count; i++)
        {
            Shuffle();
            yield return new WaitForSeconds(0.003f);
        }

        List<int> result_list = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            result_list.Add(this.ints_list[i]);
        }

        result_list.Sort();

        this.result = $"이번 주 당첨 번호 : {result_list[0]} / {result_list[1]} / {result_list[2]} / {result_list[3]} / {result_list[4]} / {result_list[5]} / 보너스 넘버 : {ints_list[5]}";

        Debug.Log(this.result);
    }

    private void Shuffle()
    {
        int ran_num1 = Random.Range(0, this.max_num);
        int ran_num2;

        do
        {
            ran_num2 = Random.Range(0, this.max_num);
        } while (ran_num1 == ran_num2);

        int temp = this.ints_list[ran_num1];
        this.ints_list[ran_num1] = this.ints_list[ran_num2];
        this.ints_list[ran_num2] = temp;
    }
}
