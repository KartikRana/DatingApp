using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IDatingRepository Repo { get; }
        public IMapper Mapper { get; }

        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            Repo = repo;
            Mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await Repo.GetUsers();
            var usersToReturn = Mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await Repo.GetUser(id);
            var userToReturn = Mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }


    }
}
