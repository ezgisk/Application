using Application.Business.Abstract;
using Application.Entitities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        public UserApiController(IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        // GET: api/productList
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userList = await _userService.GetAsync();
                if (userList == null)
                    return NotFound();

                return Ok(userList);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        // GET: api/productList/5
        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: api/productList
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User userModel)
        {
            try
            {
                var userId = await _userService.AddAsync(userModel);
                if (userId > 0)
                    return Ok(userId);
                else
                    return BadRequest("An Error Occured While Creating New product");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                    return BadRequest();

                var result = await _userService.DeleteAsync(id);
                if (result.Status)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
