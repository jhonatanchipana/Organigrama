using Microsoft.EntityFrameworkCore;
using Organigrama.Entities;
using System.Data;
using System.Reflection;

namespace Organigrama
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<WorkStation> WorkStation{ get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Configuraciones Generales

            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                //configuraciones asociadas a la baseEntity
                if (typeof(BaseEntity).IsAssignableFrom(item.ClrType))
                {
                    modelBuilder.Entity(item.ClrType).Property<string>(nameof(BaseEntity.CreateBy)).IsRequired().HasMaxLength(80);
                    modelBuilder.Entity(item.ClrType).Property<DateTime>(nameof(BaseEntity.CreationDate)).IsRequired();
                    modelBuilder.Entity(item.ClrType).Property<string>(nameof(BaseEntity.ModifiedBy)).HasMaxLength(80);
                }
            }
            #endregion

            #region Configuracion para la entidad WorkStation
            modelBuilder.Entity<WorkStation>()
               .Property(a => a.Name)
               .IsRequired()
               .HasMaxLength(240);

            modelBuilder.Entity<WorkStation>()
                .Property(a => a.Description)
                .HasMaxLength(900);
            #endregion

            #region Configuracion para la entidad Employee
            modelBuilder.Entity<Employee>()
                .Property(a => a.Names)
                .IsRequired()
                .HasMaxLength(120);

            modelBuilder.Entity<Employee>()
                .Property(a => a.LastNames)
                .IsRequired()
                .HasMaxLength(120);

            modelBuilder.Entity<Employee>()
                .Property(a => a.NroDocumento)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Employee>()
                .Property(a => a.BirthDate)
                .IsRequired()
                .HasColumnType("date");
            
            modelBuilder.Entity<Employee>()
                .Property(a => a.Phone)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Employee>()
                .Property(a => a.Email)
                .HasMaxLength(240);
            #endregion

        }

    }
}
