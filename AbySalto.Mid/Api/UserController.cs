using AbySalto.Mid.Domain.Business.Logging;
using AbySalto.Mid.Domain.Data.DTO;
using AbySalto.Mid.Infrastructure.Products.Repository;
using AbySalto.Mid.Infrastructure.Products.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Mid.WebApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthenticateUserService _userService;
        private readonly UserRepository _userRepo;
        private readonly ErrorWriter _errorLogger;
        public UserController(AuthenticateUserService userService, UserRepository userRepo, ErrorWriter errorLogger)
        {
            _userService = userService;
            _userRepo = userRepo;
            _errorLogger = errorLogger;
        }

        [HttpPost("Auth")]
        public ActionResult<UserDto> GetFullUser([FromBody] UserDto user)
        {
            try
            {
                _userService.Execute(ref user);

                if (_userService.IsAuthorized)
                {
                    return _userRepo.GetOne(_userService.UserId);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                _errorLogger.LogException(e);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult PostUser([FromBody] UserDto user)
        {
            try
            {
                UserDto dto = _userRepo.GetByEmail(user.Email);

                if (dto.Id == default)
                {
                    _userRepo.Post(user);
                    return Ok();
                }

                return Unauthorized();

            }
            catch (Exception e)
            {
                _errorLogger.LogException(e);
                return new StatusCodeResult(500);
            }


        }

        [HttpPut]
        public ActionResult PutUser([FromBody] UserDto dto)
        {
            try
            {
                _userRepo.Put(dto);
                return Ok();
            }
            catch (Exception e)
            {

                _errorLogger.LogException(e);
                return new StatusCodeResult(500);
            }
        }


        [HttpDelete]
        public ActionResult DeleteUser([FromBody] UserDto dto)
        {
            try
            {
                _userRepo.Delete(dto);
                return Ok();
            }
            catch (Exception e)
            {
                _errorLogger.LogException(e);
                return new StatusCodeResult(500);
            }

        }
    }
}
