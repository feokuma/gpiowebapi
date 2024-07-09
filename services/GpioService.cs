using System.Device.Gpio;

public class GpioService : IGpioService, IDisposable
{
    private readonly GpioController _gpioController;
    private PinMode pinMode = PinMode.Output;
    private readonly int _pin = 14; 

    public GpioService()
    {
        _gpioController = new GpioController();
        _gpioController.OpenPin(_pin, pinMode);
    }

    public void SetPinMode(PinMode mode)
    {
        _gpioController.SetPinMode(_pin, mode);
        pinMode = mode;
    }

    public PinMode GetPinMode()
    {
        return pinMode;
    }

    public void Dispose()
    {
        _gpioController?.Dispose();
    }
}
