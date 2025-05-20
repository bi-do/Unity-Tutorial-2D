using UnityEngine;

/// <summary>
/// 터미널에 hello,world! 찍음.
/// </summary>
public class StudyLog : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("hello,world!");
        Debug.LogWarning("hello,world!");
        Debug.LogError("hello,world!");
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
