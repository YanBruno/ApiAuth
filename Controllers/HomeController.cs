
using System.Threading.Tasks;
using ApiAuth.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{ 
    [Route("v1")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"Autenticado - {User.Identity.Name}";

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => $"Funcionário - {User.Identity.Name}";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<dynamic>> Manager() {
            var users = await UserRepository.GetUsers();
            return new {
            message = $"Acesso Gerente - {User.Identity.Name}",
            users
        };
        } 
    }
}
