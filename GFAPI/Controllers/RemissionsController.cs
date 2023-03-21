using BLL.GF.Interfaces.Remissions;
using DAL.GF.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemissionsController : ControllerBase
    {
        public readonly IRemissions _Irepositorio;

        public RemissionsController(IRemissions repositorio)
        {
            _Irepositorio = repositorio;
        }
        // GET: api/<RemissionsController>
        /// <summary>
        /// Get All Remissions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<RemissionsDTO>> Get()
        {
            return await _Irepositorio.GetAll();
        }

        [HttpGet("Resume")]
        public async Task<IEnumerable<ItemResume>> GetResume()
        {
            return await _Irepositorio.GetResume();
        }

        // GET api/<RemissionController>/5
        /// <summary>
        /// GetTechnicalById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RemissionsDTO>> Get(int id)
        {
            var res = await _Irepositorio.GetRemissionsById(id);
            if (res != null)
            {
                return StatusCode(StatusCodes.Status200OK, res);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "No se encuentra");
            }
        }

        // POST api/<RemissionController>
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="tecnicosDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] RemissionsDTO remissions)
        {
            var res = await _Irepositorio.CreateRemissionsAsync(remissions); 
            if(res)
            {
                return StatusCode(StatusCodes.Status200OK, res);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, res);
            }
        }

        // PUT api/<TecnicosController>/5
        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tecnicosDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<RemissionsDTO>> Put(int id, [FromBody] RemissionsDTO remissions)
        {
            if (id != remissions.RemissionId)
            {
                return BadRequest();
            }

            await _Irepositorio.UpdateTechnicalsync(remissions);

            return NoContent();
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE api/<TecnicosController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _Irepositorio.DeleteRemissionsAsync(id);
        }
    }
}
