using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSafety.Data.repository;
using FireSafety.Entity;

namespace FireSafety.Data
{
    public class FireSafetyContext : DbContext
    {
        
        public FireSafetyContext()
        {   //server=stuffy.databases.net;database=stuffy;uid=konrad;pwd=Abc123(!);
            
            Database.Connection.ConnectionString = "server=localhost;database=FireSafetyDB;Trusted_Connection=True;";
            Database.SetInitializer(new MyInitializer());

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); // Fazla bağımlı Tablelar olduğu için internetten bulundu.

            modelBuilder.Entity<Equipment>().MapToStoredProcedures();
            modelBuilder.Entity<EquipmentControl>().MapToStoredProcedures();
            modelBuilder.Entity<ProductionRequirement>().MapToStoredProcedures();
            modelBuilder.Entity<EquipmentType>().MapToStoredProcedures();
            modelBuilder.Entity<ProductionUnit>().MapToStoredProcedures();
            
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentControl> EquipmentControls { get; set; }
        public DbSet<ProductionRequirement> ProductionRequirements { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<ProductionUnit> ProductionUnits { get; set; }
        


    }
}
