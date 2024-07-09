using Microsoft.AspNetCore.Mvc;
using System.Device.Gpio;

namespace GpioWebApi.Controllers
{
    [ApiController]
    public class LightController : ControllerBase
    {
        private readonly IGpioService _gpioService;

        public LightController(IGpioService gpioService)
        {
            _gpioService = gpioService;
        }

        [HttpPost("on")]
        public IActionResult TurnOnTheLight()
        {
            _gpioService.SetPinMode(PinMode.Output);
            return Ok(new { status = "on" });
        }

        [HttpPost("off")]
        public IActionResult TurnOffTheLight()
        {
            _gpioService.SetPinMode(PinMode.Input);
            return Ok(new { status = "off" });
        }

        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            var pinMode = _gpioService.GetPinMode();
            return Ok(new { status = pinMode == PinMode.Output ? "on" : "off" });
        }
    }
}
