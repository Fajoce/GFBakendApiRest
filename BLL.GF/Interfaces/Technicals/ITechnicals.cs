using DAL.GF;
using DAL.GF.DTO;
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
        Task<bool> CreateTechnicalAsync(TechnicalsDTO technicals);
        Task<bool> DeleteTechnicalAsync(string code);
        Task<TechnicalsDTO> GetTechnicalById(int id);
        Task<IEnumerable<TechnicalsDTO>> GetAll();
        Task<bool> UpdateTechnicalsync(TechnicalsDTO tecnicos);
        Task<IEnumerable<TechnicalResumenDTO>> GetResumen();
    }
}
