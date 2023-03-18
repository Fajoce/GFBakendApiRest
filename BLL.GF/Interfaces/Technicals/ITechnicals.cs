using DAL.GF;
using DAL.GF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GF.Interfaces.Technicals
{
    public interface ITechnicals
    {
        Task<string> CreateTechnicalAsync(TechnicalsDTO technicals);
        Task<bool> DeleteTechnicalAsync(int id);
        Task<TechnicalsDTO> GetTechnicalById(int id);
        Task<IEnumerable<TechnicalsDTO>> GetAll();
        Task<bool> UpdateTechnicalsync(TechnicalsDTO tecnicos);
    }
}
