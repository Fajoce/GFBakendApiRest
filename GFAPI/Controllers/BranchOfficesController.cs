using BLL.GF.Interfaces.BranchOffices;
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
    public class BranchOfficesController : ControllerBase
    {
        public readonly IBranchOffices _Irepositorio;

        public BranchOfficesController(IBranchOffices repositorio)
        {
            _Irepositorio = repositorio;
        }

        // GET: api/<TecnicosController>
        /// <summary>
        /// Get All BranchOffices
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<BranchOfficeDTO>> Get()
        {
            return await _Irepositorio.GetAll();
        }
    }
}
