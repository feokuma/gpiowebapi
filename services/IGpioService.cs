using System.Device.Gpio;

public interface IGpioService
{
    void SetPinMode(PinMode mode);
    PinMode GetPinMode();
}
