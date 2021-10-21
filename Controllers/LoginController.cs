using System.Threading.Tasks;
using ApiAuth.Models;
using ApiAuth.Repository;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase{
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model){
            
            var user = UserRepository.GetUser(model.Username, model.Password);

            if(user == null)
                return NotFound(new {message = "Usuário não encontado"});

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new {
                user,
                token
            };
        }
    
        
    }
}