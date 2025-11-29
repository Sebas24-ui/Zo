using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos;

    public class ZoContext : DbContext
    {
        public ZoContext (DbContextOptions<ZoContext> options)
            : base(options)
        {
        }

        public DbSet<Modelos.Animal> Animals { get; set; } = default!;

public DbSet<Modelos.Especie> Especies { get; set; } = default!;

public DbSet<Modelos.Raza> Razas { get; set; } = default!;
    }
