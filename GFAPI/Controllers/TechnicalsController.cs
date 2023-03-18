using BLL.GF.Interfaces.Technicals;
using DAL.GF;
using DAL.GF.Utils;
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
    public class TechnicalsController : ControllerBase
    {
        public readonly ITechnicals _Irepositorio;

        public TechnicalsController(ITechnicals repositorio)
        {
            _Irepositorio = repositorio;
        }
        // GET: api/<TecnicosController>
        /// <summary>
        /// Get All Technicals
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<TechnicalsDTO>> Get(PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            return await _Irepositorio.GetAll();
        
        }

        // GET api/<TecnicosController>/5
        /// <summary>
        /// GetTechnicalById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TechnicalsDTO>> Get(int id)
        {
            
            var res = await _Irepositorio.GetTechnicalById(id);
            if (res != null)
            {
                return Ok(new Response<TechnicalsDTO>(res));
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "No se encuentra");
            }
        }

        // POST api/<TecnicosController>
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="tecnicosDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] TechnicalsDTO tecnicosDTO)
        {
            return await _Irepositorio.CreateTechnicalAsync(tecnicosDTO);

        }

        // PUT api/<TecnicosController>/5
        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tecnicosDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<TechnicalsDTO>> Put(int id, [FromBody] TechnicalsDTO tecnicosDTO)
        {
            if (id != tecnicosDTO.TechnicalId)
            {
                return BadRequest();
            }

            await _Irepositorio.UpdateTechnicalsync(tecnicosDTO);

           

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
            return await _Irepositorio.DeleteTechnicalAsync(id);

        }
    }
}

