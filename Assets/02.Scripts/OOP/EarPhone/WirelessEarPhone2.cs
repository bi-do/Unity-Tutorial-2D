using UnityEngine;

public class WirelessEarPhone2 : WirelessEarPhone
{
    public bool isNoise_cancelling;

    void Start()
    {
        this.product_name = "AirPod2";
        this.price = 120f;
        this.release_year = 2010;
        this.battery_size = 90f;
    }

    public virtual void NoiseCancelling()
    {
        string temp_log = this.isNoise_cancelling ? "노이즈 캔슬링 On" : "노이즈 캔슬링 Off";
        Debug.Log(temp_log);
    }


}