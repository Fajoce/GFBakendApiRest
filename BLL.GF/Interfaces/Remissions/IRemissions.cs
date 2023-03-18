using DAL.GF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GF.Interfaces.Remissions
{
   public interface IRemissions
   {
        Task<string> CreateRemissionsAsync(RemissionsDTO remissions);
        Task<bool> DeleteRemissionsAsync(int id);
        Task<RemissionsDTO> GetRemissionsById(int id);
        Task<IEnumerable<RemissionsDTO>> GetAll();
        Task<bool> UpdateTechnicalsync(RemissionsDTO remissions);
    }
}
