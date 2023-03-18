using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GF.Entities
{
    public class GFDbContext: DbContext
    {
        public GFDbContext(DbContextOptions<GFDbContext>options): base(options)
        {

        }

        public virtual DbSet<Technicals> Technicals { get; set; }
        public virtual DbSet<BranchOffices> BranchOffices { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Remissions> Remissions { get; set; }
    }
}


