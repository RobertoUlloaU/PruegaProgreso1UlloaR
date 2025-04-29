using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruegaProgreso1UlloaR.Models;

    public class DBSqlServerUlloaRoberto : DbContext
    {
        public DBSqlServerUlloaRoberto (DbContextOptions<DBSqlServerUlloaRoberto> options)
            : base(options)
        {
        }

        public DbSet<PruegaProgreso1UlloaR.Models.Cliente> Cliente { get; set; } = default!;

public DbSet<PruegaProgreso1UlloaR.Models.Reserva> Reserva { get; set; } = default!;

public DbSet<PruegaProgreso1UlloaR.Models.Recompensa> Recompensa { get; set; } = default!;
    }
