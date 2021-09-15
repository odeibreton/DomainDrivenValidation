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

            var user = result.AsT0;
            return Ok(new UserPostResponse
            {
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            });
        }
    }
}
