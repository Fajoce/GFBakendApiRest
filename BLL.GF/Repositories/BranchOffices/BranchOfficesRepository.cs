using BLL.GF.Interfaces.BranchOffices;
using DAL.GF.DTO;
using DAL.GF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GF.Repositories
{
    public class BranchOfficesRepository : IBranchOffices
    {
        #region Properties
        private readonly GFDbContext _context;

        public BranchOfficesRepository(GFDbContext context)
        {
            _context = context;
        }
        #endregion Properties
        public async Task<IEnumerable<BranchOfficeDTO>> GetAll()
        {
            var lst = await(from bo in _context.BranchOffices
                            
                            select new BranchOfficeDTO
                            {
                               BranchOfficeId = bo.BranchOfficeId,
                               BranchOfficeCode = bo.BranchOfficeCode,
                               BranchOfficeName = bo.BranchOfficeName
                            }
                       ).ToListAsync();
            return lst;
        }
    }
}
