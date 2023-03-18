using BLL.GF.Interfaces.Items;
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
    public class ItemsController : ControllerBase
    {
        public readonly IItems _Irepositorio;

        public ItemsController(IItems repositorio)
        {
            _Irepositorio = repositorio;
        }

        // GET: api/<TecnicosController>
        /// <summary>
        /// Get All Items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ItemsDTO>> Get()
        {
            return await _Irepositorio.GetAll();
        }

    }
}
