using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

    public class ZooModelosContext : DbContext
    {
        public ZooModelosContext (DbContextOptions<ZooModelosContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animal { get; set; } = default!;

public DbSet<Especie> Especie { get; set; } = default!;

public DbSet<Raza> Raza { get; set; } = default!;
    }
