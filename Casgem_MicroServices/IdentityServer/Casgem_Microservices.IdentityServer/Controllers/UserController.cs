using Casgem_Microservices.IdentityServer.Dtos;
using Casgem_Microservices.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Casgem_Microservices.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var user = new ApplicationUser
            {
                UserName = signUpDto.UserName,
                Email = signUpDto.Email,
                City = signUpDto.City
            };
            var result=await _userManager.CreateAsync(user, signUpDto.Password);
            if(result.Succeeded)
            {
                return Ok("Kullanıcı kayıt ı oluşturuldu");
            }
            else
            {
                return Ok("Bir hata oluştu.");
            }
        }
    }
}
