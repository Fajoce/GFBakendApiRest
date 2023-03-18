using DAL.GF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GF.Interfaces.Items
{
    public interface IItems
    {
        Task<IEnumerable<ItemsDTO>> GetAll();
    }
}
