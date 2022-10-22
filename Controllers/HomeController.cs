using Microsoft.AspNetCore.Mvc;
using Todo.SDK.Services.UsersService;
using Todo.Domain.CustomModels;
//using System.Web.Http;
//using WebAPI.Models;
//using System.Data;

namespace Dummy.Controllers
{
    //var cors = new EnableCorsAttribute("*", "*", "*");
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsersService aPI;
        public UsersController(IUsersService aPI)
        {
            this.aPI = aPI;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var result = await aPI.GetAll();

            return Ok(result);
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult> GetById(int id)
        {
            var get = await aPI.GetById(id);

            return Ok(get);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Create model)
        {

            var newUser = await aPI.Create(model);


            return Ok(newUser);


        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Update(int id, Update model)
        {
            var edit = await aPI.Update(id);

            return Ok(edit);

        }
        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {

            var user = await aPI.Delete(id);

            return Ok(user);

        }

    }
}