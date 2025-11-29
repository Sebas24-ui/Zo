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
    //erht 

        public DbSet<Animal> Animals { get; set; } = default!;

public DbSet<Especie> Especies { get; set; } = default!;

public DbSet<Raza> Razas { get; set; } = default!;

    }
