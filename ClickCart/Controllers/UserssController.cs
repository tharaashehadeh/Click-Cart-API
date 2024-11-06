using ClickCart.Core.Entites;
using ClickCart.Core.Entites.DTO;
using ClickCart.Core.IRepositiers;
using ClickCart.Core.IRepositiers.IServieces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClickCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserssController : ControllerBase
    {
        private readonly IUserRepositery userRepositery;
        private readonly UserManager<Users> userManager;
        private readonly IEmailServieces emailServieces;

        public UserssController(IUserRepositery userRepositery,
            UserManager<Users> userManager,
            IEmailServieces emailServieces
            )
        {
            this.userRepositery = userRepositery;
            this.userManager = userManager;
            this.emailServieces = emailServieces;
        }
        [HttpPost("login")]
        public async Task<IActionResult>Login([FromBody] LoginRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                var user =await userRepositery.Login(model);
                if (user.User==null)
                {
                    return Unauthorized(new ApiValidationRespones(new List<string>() {"Email or Password incorrect"},401));
                }
                return Ok(user);
            }
            return BadRequest(new ApiValidationRespones(new List<string>() { "Please try to enter the email and password correctly" }, 400));
        }


        [HttpPost("register")]
        public async Task<IActionResult>Register([FromBody]RegistrationRequestDTO model)
        {
            try
            {
                bool uniqueEmail = userRepositery.IsUniqueUser(model.Email);
                if(!uniqueEmail)
                {
                    return BadRequest(new ApiRespones(400, "email already exists !!"));

                }
                var user =await userRepositery.Register(model);
                if(user == null)
                {
                    return BadRequest(new ApiRespones(400, "Error while Registreation user !!"));
                }
                else
                {
                    return Ok(new ApiRespones(201,result:user));
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ApiValidationRespones(new List<string>()
                {
                    ex.Message,"an error occured while procssing your request " }));
            }
        }

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmailForUser(string email)
        {
            var user =await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest(new ApiValidationRespones(new List<string> { $"This Email{email}not found:(" }));
            }
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var forgetpasswordlink = Url.Action("ResetPassword", "Userss", new {token=token,email=user.Email},Request.Scheme);
            var subject = "Reset Password Request";
            var message = $"Please click on the link to reset your Password:{forgetpasswordlink}";

             await  emailServieces.SendEmailAsync(user.Email, subject, message);
            return Ok(new ApiRespones(200, "Password Reset Link has been sent to your email... check your email:)"));

        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model) 
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return NotFound(new ApiRespones(404, "Email incorrect"));

                }
                if (string.Compare(model.NewPassword, model.ConfirmNewPassword) != 0)
                {
                    return BadRequest(new ApiRespones(400,"Password Not Match" ));

                }
                if (string.IsNullOrEmpty(model.Token))
                {
                    return BadRequest(new ApiRespones(400, "Token in Vaild"));

                }
                var result =await userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    return Ok(new ApiRespones(200, "reseting successes"));
                }
                else
                {
                    return BadRequest(new ApiRespones(400, "error while reseting"));

                }

            }
            return BadRequest(new ApiRespones(400, "check  your info"));

        }

        [HttpPost("reset-token")]
        public async Task<IActionResult> tokentoResetPassword([FromBody] string email)
        {
            var user =await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound(new ApiRespones(404));

            }
            var token = userManager.GeneratePasswordResetTokenAsync(user);
            return Ok(new { token = token });
        }
    }
}
