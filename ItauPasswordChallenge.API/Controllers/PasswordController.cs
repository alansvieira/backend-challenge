using ItauPasswordChallenge.Core;
using ItauPasswordChallenge.Core.Entities;
using ItauPasswordChallenge.Core.Services;
using ItauPasswordChallenge.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItauTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly ILogger<PasswordController> _logger;

        public PasswordController(ILogger<PasswordController> logger)
        {
            _logger = logger;
        }
        
        
        [HttpPost]
        public Password CreatePassword([FromBody]string password)
        {
            try
            {
                return new PasswordService().CreatePassword(password, new CharactersModule());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw ex;
            }
            
        }
    }
}
