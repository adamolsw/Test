using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTOs.Responses;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public ContactController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _userRepository.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _userRepository.GetByIdAsync(id);

            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddContact(Contact user)
        {
            if (!ModelState.IsValid) return BadRequest(user);
            var existingUser = await _userRepository.FindByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return BadRequest(new RegistrationResponse()
                {
                    Error = new List<string>()
                    {
                        "Email already in use"
                    },
                    Success = false
                });
            }
            await _userRepository.AddAsync(user);
            await _userRepository.CompleteAsync();
            return CreatedAtAction("GetById", new { user.Id}, user);

        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, Contact user)
        {
            if (id != user.Id) return BadRequest();

            var existsUser = await _userRepository.GetByIdAsync(id);
            if (existsUser == null) return NotFound();

            await _userRepository.UpdateAsync(existsUser, user);
            await _userRepository.CompleteAsync();
            return NoContent();
        }

        [Authorize]
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            await _userRepository.DeleteAsync(user);
            await _userRepository.CompleteAsync();
            return Ok();
        }
    }
}
