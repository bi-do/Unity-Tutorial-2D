using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Study_Coroutine : MonoBehaviour
{
    private Coroutine coroutine;

    private bool isStop = false;

    IEnumerator Start()
    {
        StartCoroutine(BombRoutine());
        yield return null;
    }

    // 대기 기능
    IEnumerator BombRoutine()
    {
        int t = 10;
        while (t > 0)
        {
            if (isStop)
            {
                Debug.Log("폭탄이 해제되었습니다.");
                yield break;
            }
            else
                Debug.Log($"폭탄 폭발까지 {t}초 남았습니다.");

            t--;
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("폭탄이 폭발하였습니다");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.isStop = true;
        }
    }
}
