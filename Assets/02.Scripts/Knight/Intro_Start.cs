using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Intro_Start : MonoBehaviour
{
    [SerializeField] Button button_UI;
    [SerializeField] GameObject intro_UI;

    void Awake()
    {
        this.button_UI.onClick.AddListener(this.OnStartTown);
    }

    private void OnStartTown()
    {
        this.intro_UI.SetActive(false);
    }
}
