using HealthyLifeAPI.Data;
using HealthyLifeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyLifeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class UserLoginDetailsController : ControllerBase
    {
        private readonly LoginContext _context;

        public UserLoginDetailsController(LoginContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<LoginInfo>> GetAll() =>
            _context.LoginDetails.ToList();

        // GET by ID action

        // POST action


        [HttpPost]
        public async Task<ActionResult<LoginInfo>> Create(LoginInfo info)
        {

            _context.LoginDetails.Add(info);
            await _context.SaveChangesAsync();


            return Ok();
        }
    }
}
