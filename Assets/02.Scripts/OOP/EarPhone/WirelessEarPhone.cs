using UnityEngine;
public class WirelessEarPhone : EarPhone
{
    public float battery_size;
    public bool isWireless_charged;

    void Start()
    {
        this.product_name = "AirPod1";
        this.price = 100f;
        this.release_year = 2007;
        this.battery_size = 70f;
    }

    public void Charged()
    {
        string temp_log = this.isWireless_charged ? "무선 충전" : "유선 충전";
        Debug.Log(temp_log);
    }
}