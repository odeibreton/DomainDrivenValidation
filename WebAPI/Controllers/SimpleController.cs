using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainDrivenValidationPattern;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(UserPostRequest model)
        {
            var result = DomainUser.Create(
                model.Name,
                Email.Parse(model.Email),
                PhoneNumber.Parse(model.PhoneNumber));

            return result.Match<IActionResult>(
                (DomainUser user) => Ok(new UserPostResponse
                {
                    Name = user.Name,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                }),
                (EmptyArgument _) =>
                {
                    ModelState.AddModelError(nameof(UserPostRequest.Name), "The name must not be empty.");
                    return BadRequest(ModelState);
                },
                (InvalidLength _) =>
                {
                    ModelState.AddModelError(nameof(UserPostRequest.Name), "The name is invalid.");
                    return BadRequest(ModelState);
                }
            );
        }
    }
}
