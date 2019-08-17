using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiDataAccess;
using WebApiDomain;

namespace WebApiHomework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return DbStorage.Users();
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            try
            {
                return DbStorage.Users()[id - 1];

            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"User with id {id} does not exist.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Please fix your request: {ex.Message}");
            }
        }
        [HttpGet("{id}/isadult")]
        public ActionResult<string> IsAdult(int id)
        {
            try
            {
                var request = Request;

                if (DbStorage.Users()[id - 1].Age >= 18)
                {
                    return ($"User with id {id} is adult");
                }
                return ($"User with id {id} is not adult");
                

            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"User with id {id} does not exist.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Please fix your request: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Post()
        {
            string body;
            using (StreamReader sr = new StreamReader(Request.Body))
            {
                body = sr.ReadToEnd();
            }
            User user = JsonConvert.DeserializeObject<User>(body);
            DbStorage.Users().Add(user);
            return Ok($"User with id {DbStorage.Users().Count} added!");
        }
    }
}