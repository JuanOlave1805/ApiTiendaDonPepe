namespace ApiTiendaDonPepe.Controllers
{
    using ApiTiendaDonPepe.Models;
    using ApiTiendaDonPepe.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest req)
        {
            if (req.Username == "admin" && req.Password == "12345")
            {
                var token = _jwtService.GenerateToken(req.Username);
                return Ok(new
                {
                    success = true,
                    message = "Inicio de sesión exitoso.",
                    token
                });
            }

            return Ok(new
            {
                success = false,
                message = "Usuario o contraseña incorrectos."
            });
        }
    }
}
