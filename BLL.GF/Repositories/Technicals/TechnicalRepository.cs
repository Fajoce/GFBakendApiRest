﻿using BLL.GF.Interfaces.Technicals;
using DAL.GF;
using DAL.GF.DTO;
using DAL.GF.Entities;
using DAL.GF.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GF.Repositories
{
    public class TechnicalRepository : ITechnicals
    {
        #region Properties
        private readonly GFDbContext _context;

        public TechnicalRepository(GFDbContext context)
        {
            _context = context;
        }
        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Create Technicals
        /// </summary>
        /// <param name="technicals"></param>
        /// <returns></returns>
        public async Task<bool> CreateTechnicalAsync(TechnicalsDTO technicals)
        {
            
            try
            {
                var entity = new Technicals()
                {
                    TechnicalFullName = technicals.TechnicalFullName,
                    TechnicalCode = technicals.TechnicalCode,
                    TechnicalSalary = technicals.TechnicalSalary,                    
                    BranchOfficeCode = technicals.BranchOfficeCode
                 };

                if (!Existe(entity.TechnicalCode))
                {

                    _context.Technicals.Add(entity);
                await _context.SaveChangesAsync();
                return true;

                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        /// <summary>
        /// Delete Technicals
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<bool> DeleteTechnicalAsync(string id)
        {
            
                var entity = new Technicals()
                {
                    TechnicalCode = id
                };
               _context.Technicals.Attach(entity);
                _context.Technicals.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
           
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TechnicalsDTO>> GetAll()
        {
            try
            {
                var lst = await (from t in _context.Technicals
                                 join bo in _context.BranchOffices
                                    on t.BranchOfficeCode equals bo.BranchOfficeCode
                                 select new TechnicalsDTO
                                 {
                                     TechnicalId = t.TechnicalId,
                                     TechnicalCode = t.TechnicalCode,
                                     TechnicalFullName = t.TechnicalFullName,
                                     TechnicalSalary = t.TechnicalSalary,
                                     BranchOfficeCode = t.BranchOfficeCode,
                                     BranchOfficeName = bo.BranchOfficeName
                                 }
                           ).OrderBy(t => t.TechnicalId).ToListAsync();
                return lst;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get By id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<TechnicalsDTO> GetTechnicalById(int id)
        {
            try
            {
                var lst = await (from t in _context.Technicals
                                 join bo in _context.BranchOffices
                                 on t.BranchOfficeCode equals bo.BranchOfficeCode
                                 select new TechnicalsDTO
                                 {
                                     TechnicalId = t.TechnicalId,
                                     TechnicalCode = t.TechnicalCode,
                                     TechnicalFullName = t.TechnicalFullName,
                                     TechnicalSalary = t.TechnicalSalary,
                                     BranchOfficeCode = t.BranchOfficeCode,
                                     BranchOfficeName = bo.BranchOfficeName
                                 }
                           ).FirstOrDefaultAsync(t => t.TechnicalId == id);
                return lst;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// updat Technicals
        /// </summary>
        /// <param name="tecnicos"></param>
        /// <returns></returns>

        public async Task<bool> UpdateTechnicalsync(TechnicalsDTO tecnicos)
        {
            try
            {
                var entity = await _context.Technicals.FirstOrDefaultAsync(t => t.TechnicalId == tecnicos.TechnicalId);
                entity.TechnicalFullName = tecnicos.TechnicalFullName;
                entity.TechnicalCode = tecnicos.TechnicalCode;
                entity.TechnicalSalary = tecnicos.TechnicalSalary;
                entity.BranchOfficeCode = tecnicos.BranchOfficeCode;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion Public Methods

        #region Private Methods
        public bool Existe(string code)
        {
            return _context.Technicals.Any(t => t.TechnicalCode == code);
        }

        public async Task <IEnumerable<TechnicalResumenDTO>> GetResumen()
        {
            var lst = await (from t in _context.Technicals
                       join bo in _context.BranchOffices
                        on t.BranchOfficeCode equals bo.BranchOfficeCode
                       group t by new { t.BranchOfficeCode, bo.BranchOfficeName } into newGroup
                       select new TechnicalResumenDTO
                       {
                           BranchOfficeCode = newGroup.Key.BranchOfficeCode,
                           BranchOfficeName = newGroup.Key.BranchOfficeName,
                           Quantity =  newGroup.Count(),
                           Add = newGroup.Sum(r=> r.TechnicalSalary),
                           Avg = newGroup.Average(r => r.TechnicalSalary),
                           Maximum = (int)newGroup.Max(r => r.TechnicalSalary),
                           Minimum = (int)newGroup.Min(r => r.TechnicalSalary)
                       }).ToListAsync();
            return lst;
        }

        #endregion Private Methods
    }
}
