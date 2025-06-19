using UnityEngine;

public class MathLight : MonoBehaviour
{
    private Light m_light;
    private float theta;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float power;

    void Start()
    {
        this.m_light = this.GetComponent<Light>();
    }

    void Update()
    {
        this.theta += Time.deltaTime * speed;

        // this.m_light.intensity = Mathf.Sin(this.theta) * power;
        this.m_light.intensity = Mathf.PerlinNoise(theta, 0) * power;
    }
}
