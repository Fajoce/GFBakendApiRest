using BLL.GF.Interfaces.Items;
using DAL.GF.DTO;
using DAL.GF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GF.Repositories.Items
{
    public class ItemsRepository : IItems
    {
        #region Properties
        private readonly GFDbContext _context;

        public ItemsRepository(GFDbContext context)
        {
            _context = context;
        }
        #endregion Properties
        public async Task<IEnumerable<ItemsDTO>> GetAll()
        {
            var lst = await(from i in _context.Items

                            select new ItemsDTO
                            {
                                ItemId = i.ItemId,
                                ItemCode = i.ItemCode,
                                ItemName = i.ItemName
                            }
                       ).ToListAsync();
            return lst;
        }
    }
}
