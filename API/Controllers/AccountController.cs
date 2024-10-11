using BOs.DTOs;
using BOs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Service;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;

        public AccountController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<SystemAccount>> GetAll()
        {
            var accounts = _accountService.GetAccounts();

            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public ActionResult<SystemAccount> GetById(short id)
        {
            var account = _accountService.GetAccount(id);
            if (account == null) return NotFound();
            return Ok(new
            {
                account.AccountId,
                account.AccountName,
                account.AccountEmail,
                account.AccountRole
            });
        }

        [HttpPost]
        public ActionResult Add([FromBody] SystemAccount account)
        {
            _accountService.AddAccount(account);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] SystemAccount account)
        {
            if (id != account.AccountId) return BadRequest();
            _accountService.UpdateAccount(account);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(short id)
        {
            _accountService.DeleteAccount(id);
            return Ok();
        }





        #region Login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO request)
        {
            // Check for Admin credentials
            if (request.AccountEmail == _configuration["AdminCredentials:AccountEmail"] && request.AccountPassword == _configuration["AdminCredentials:AccountPassword"])
            {
                var tokenHelper = new JWTService(_configuration);
                var token = tokenHelper.GenerateJwtToken(request.AccountEmail, "Admin");

                var response = new ResultModel()
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "Login successfully as Admin",
                    Data = token
                };
                return Ok(response);
            }

            // Check for user credentials
            var user = _accountService.GetAccountByEmail(request.AccountEmail);
            if (user != null)
            {
                // Convert the role from int to string
                string roleString = GetRoleString(user.AccountRole);

                var tokenHelper = new JWTService(_configuration);
                var token = tokenHelper.GenerateJwtToken(user.AccountEmail, roleString);

                var response = new ResultModel()
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "Login successfully",
                    Data = token,
                };
                return Ok(response);
            }

            return Unauthorized(new ResultModel()
            {
                IsSuccess = false,
                StatusCode = 401,
                Message = "Invalid credentials"
            });
        }

        private string GetRoleString(int? roleId)
        {
            return roleId switch
            {
                1 => "Staff",
                2 => "Lecturer",
                
            };
        }
        #endregion

    }

}
