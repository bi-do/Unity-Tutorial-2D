using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playTimeUI;
    private float timer;
    void Update()
    {
        this.timer += Time.deltaTime;
        this.playTimeUI.text = string.Format("플레이 시간 : {0:F1}초" , timer);
    }
}
