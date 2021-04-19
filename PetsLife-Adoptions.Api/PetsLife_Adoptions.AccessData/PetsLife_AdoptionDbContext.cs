using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PetsLife_Adoptions.Domain.Entities;
using System.Text;

namespace PetsLife_Adoptions.AccessData
{
    public class PetsLife_AdoptionDbContext : DbContext
    {
        public PetsLife_AdoptionDbContext(DbContextOptions<PetsLife_AdoptionDbContext> options
            ) : base(options)
        {

        }
    

    public DbSet<Adoptante> Adoptantes { get; set; }
    public DbSet<Mascota> Mascotas { get; set; }

    }
}
