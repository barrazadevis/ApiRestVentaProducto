using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RegistroInfraestructure.Data;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketCore.Interfaces;

namespace RegistroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //[HttpPost]
        //[Route("[action]")]
        //public IActionResult Login()
        //{
        //    var usuario =_configuration.GetValue<string>("Usuario");
        //    var clave = _configuration.GetValue<string>("Clave");

        //    // Leemos el secret_key desde nuestro appseting
        //    var secretKey = _configuration.GetValue<string>("SecretKey");
        //    var key = Encoding.ASCII.GetBytes(secretKey);

        //    // Creamos los claims (pertenencias, características) del usuario
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, usuario),
        //        new Claim(ClaimTypes.Name, clave),

        //    };

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = claims,
        //        // Nuestro token va a durar un día
        //        Expires = DateTime.UtcNow.AddDays(1),
        //        // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var createdToken = tokenHandler.CreateToken(tokenDescriptor);

        //    return tokenHandler.WriteToken(createdToken);
        //}

    }
}
