using BLL.GF.Interfaces.Remissions;
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
    public class RemissionsRepository : IRemissions
    {
        #region Properties
        private readonly GFDbContext _context;

        public RemissionsRepository(GFDbContext context)
        {
            _context = context;
        }
        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Create Remissions
        /// </summary>
        /// <param name="remissions"></param>
        /// <returns></returns>
        public async Task<bool> CreateRemissionsAsync(RemissionsDTO remissions)
        {
           
            try
            {
                var entity = new Remissions()
                {
                    RemissionDate = remissions.RemissionDate,
                    TechnicalCode = remissions.TechnicalCode,
                    ItemCode = remissions.ItemCode,
                    RemissionQuantity = remissions.RemissionQuantity
                };

                if (!Existe(entity.TechnicalCode,entity.ItemCode))
                {
                    _context.Remissions.Add(entity);
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRemissionsAsync(int id)
        {
            try
            {
                var entity = new Remissions()
                {
                    RemissionId = id
                };
                _context.Remissions.Attach(entity);
                _context.Remissions.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Get all Remissions
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RemissionsDTO>> GetAll()
        {
            try
            {
                var lst = await (from r in _context.Remissions
                                 join t in _context.Technicals
                                 on r.TechnicalCode equals t.TechnicalCode
                                 join i in _context.Items
                                 on r.ItemCode equals i.ItemCode
                                 select new RemissionsDTO
                                 {
                                     RemissionId = r.RemissionId,
                                     RemissionDate = r.RemissionDate,
                                     TechnicalCode = t.TechnicalCode,
                                     TechnicalFullName = t.TechnicalFullName,
                                     ItemCode = i.ItemCode,
                                     ItemName = i.ItemName,
                                     RemissionQuantity = r.RemissionQuantity
                                 }
                           ).OrderBy(r => r.TechnicalCode).ToListAsync();
                return lst;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// get Remission by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<RemissionsDTO> GetRemissionsById(int id)
        {
            try
            {
                var lst = await (from r in _context.Remissions
                                 join t in _context.Technicals
                                 on r.TechnicalCode equals t.TechnicalCode
                                 join i in _context.Items
                                 on r.ItemCode equals i.ItemCode
                                 select new RemissionsDTO
                                 {
                                     RemissionId = r.RemissionId,
                                     RemissionDate = r.RemissionDate,
                                     TechnicalCode = t.TechnicalCode,
                                     TechnicalFullName = t.TechnicalFullName,
                                     ItemCode = i.ItemCode,
                                     ItemName = i.ItemName,
                                     RemissionQuantity = r.RemissionQuantity
                                 }
                           ).FirstOrDefaultAsync(r => r.RemissionId == id);
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// update remission
        /// </summary>
        /// <param name="remissions"></param>
        /// <returns></returns>
        public async Task<bool> UpdateTechnicalsync(RemissionsDTO remissions)
        {
            try
            {
                var entity = await _context.Remissions.FirstOrDefaultAsync(r => r.RemissionId == remissions.RemissionId);
                entity.RemissionDate = remissions.RemissionDate;
                entity.TechnicalCode = remissions.TechnicalCode;
                entity.ItemCode = remissions.ItemCode;
                entity.RemissionQuantity = remissions.RemissionQuantity;
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
        public bool Existe(string tcode, string icode)
        {
            return _context.Remissions.Any(t => t.TechnicalCode == tcode && t.ItemCode == icode);
        }

        public async Task<IEnumerable<ItemResume>> GetResume()
        {
            var lst = await(from r in _context.Remissions
                           join i in _context.Items
                            on r.ItemCode equals i.ItemCode
                           group r by new { r.ItemCode,i.ItemName} into newGroup
                           select new ItemResume
                           {
                               ItemeCode = newGroup.Key.ItemCode,
                               ItemName = newGroup.Key.ItemName,
                               Quantity = newGroup.Count(),
                               Add = newGroup.Sum(r => r.RemissionQuantity),
                               Maximum = (int)newGroup.Max(r => r.RemissionQuantity),
                               Minimum = (int)newGroup.Min(r => r.RemissionQuantity)
                           }).ToListAsync();
            return lst;
        }

        #endregion Private Methods
    }
}
