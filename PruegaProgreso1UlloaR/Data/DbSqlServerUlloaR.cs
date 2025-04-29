using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruegaProgreso1UlloaR.Models;

    public class DbSqlServerUlloaR : DbContext
    {
        public DbSqlServerUlloaR (DbContextOptions<DbSqlServerUlloaR> options)
            : base(options)
        {
        }

        public DbSet<PruegaProgreso1UlloaR.Models.Cliente> Cliente { get; set; } = default!;
    }
