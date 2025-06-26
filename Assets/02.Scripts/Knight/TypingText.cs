using System.Collections;
using TMPro;
using UnityEngine;

public class TypingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text_UI;
    private string curText;

    void Awake()
    {
        curText = text_UI.text;
    }

    void OnEnable()
    {
        text_UI.text = string.Empty;

        StartCoroutine(TypingRountine());
    }

    IEnumerator TypingRountine()
    {
        foreach (char element in curText)
        {
            text_UI.text += element;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
