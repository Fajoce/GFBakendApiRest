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
        public async Task<IEnumerable<TechnicalsDTO>> Get()
        {
            
            return await _Irepositorio.GetAll();
        
        }

        // GET api/<TecnicosController>/5
        /// <summary>
        /// GetTechnicalById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<TechnicalsDTO> Get(int id)
        {
            
            return await _Irepositorio.GetTechnicalById(id);
            //if (res != null)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, res);
            //}
            //else
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, "No se encuentra");
            //}
        }

        // POST api/<TecnicosController>
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="tecnicosDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] TechnicalsDTO tecnicosDTO)
        {
            var res = await _Irepositorio.CreateTechnicalAsync(tecnicosDTO);
            if (res)
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
        public async Task<bool> Delete(string id)
        {
            return await _Irepositorio.DeleteTechnicalAsync(id);

        }
    }
}

