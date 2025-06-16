using UnityEngine;

public class WirelessEarPhone3 : WirelessEarPhone2
{
    public enum NoiseCancelType { Off, On, Around }
    public NoiseCancelType noise_cancel_type;

    public void SetNoiseCancelType(NoiseCancelType param_type)
    {
        this.noise_cancel_type = param_type;
    }

    public override void NoiseCancelling()
    {
        this.SetNoiseCancelType(this.noise_cancel_type);
        base.NoiseCancelling();
    }
}