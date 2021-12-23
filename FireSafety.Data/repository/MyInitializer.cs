using FireSafety.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Data.repository
{
    public class MyInitializer: CreateDatabaseIfNotExists<FireSafetyContext>
    {
        protected override void Seed(FireSafetyContext context)
        {

            ProductionUnit pastane = new ProductionUnit() {
                Id = 1,
                Name = "Pastane",
                Location="Aliağa",
                IsActive=true};
            ProductionUnit Firin = new ProductionUnit()
            {
                Id = 2,
                Name = "Firin",
                Location = "Menemen",
                IsActive = true
            }; ProductionUnit Benzinlik = new ProductionUnit()
            {
                Id = 3,
                Name = "Benzin İstasyonu",
                Location = "Karşıyaka",
                IsActive = true
            };
            context.ProductionUnits.Add(Firin);
            context.ProductionUnits.Add(pastane);
            context.ProductionUnits.Add(Benzinlik);
            context.SaveChanges();
            EquipmentType Tup = new EquipmentType()
            {
                Id=1,
                Name= "Yangın Tüpü",
                IsActive= true
            };
            EquipmentType Kova = new EquipmentType()
            {
                Id = 2,
                Name = "Yangın Kovası",
                IsActive = true
            };
            EquipmentType Elbise = new EquipmentType()
            {
                Id = 3,
                Name = "Yangin Elbisesi",
                IsActive = true
            };
            EquipmentType Gozetleme = new EquipmentType()
            {
                Id = 3,
                Name = "Yangin Elbisesi",
                IsActive = true
            };
            context.EquipmentTypes.Add(Tup);
            context.EquipmentTypes.Add(Kova);
            context.EquipmentTypes.Add(Elbise);
            context.EquipmentTypes.Add(Gozetleme);

            context.SaveChanges();
            Equipment Urun1  = new Equipment()
            {
                Id = 1,
                EquipmentTypeId=1,
                IsActive = true,
                ProductionUnitId = 3,
                ExpirationDate = DateTime.Now.AddYears(1),
                 SeriNo= "123123123"
            };
            Equipment Urun2 = new Equipment()
            {
                Id = 2,
                EquipmentTypeId = 2,
                IsActive = true,
                ProductionUnitId=1,
                ExpirationDate = DateTime.Now.AddYears(1),
                SeriNo ="84448484"
                
        };
            Equipment Urun3 = new Equipment()
            {
                Id = 3,
                EquipmentTypeId = 2,
                IsActive = false,
                ProductionUnitId = 2,
                ExpirationDate = DateTime.Now.AddYears(1),
                SeriNo = "1111111111",
            };
            context.Equipments.Add(Urun1);
            context.Equipments.Add(Urun2);
            context.Equipments.Add(Urun3);
            context.SaveChanges();
            EquipmentControl ffirst = new EquipmentControl()
            {
                EquipmentId = 1,
                PressureLevel = 95,
                PhysicalInspection = true,
                ProtectionPinStatus = true,
                ControlDate = DateTime.UtcNow,
                CreatedByUser = "Veli",
                 IsActive=true    
            };
            EquipmentControl second = new EquipmentControl()
            {
                EquipmentId = 2,
                PressureLevel = 55,
                PhysicalInspection = true,
                ProtectionPinStatus = false,
                ControlDate = DateTime.UtcNow,
                CreatedByUser = "Metehan",
                IsActive = false

            };
            EquipmentControl third = new EquipmentControl()
            {
                EquipmentId = 3,
                PhysicalInspection = false,
                ProtectionPinStatus = true,
                ControlDate = DateTime.UtcNow,
                CreatedByUser = "Ali",
                IsActive = true
            };
            context.EquipmentControls.Add(ffirst);
            context.EquipmentControls.Add(second);
            context.EquipmentControls.Add(third);

            context.SaveChanges();

            ProductionRequirement firstReq = new ProductionRequirement()
            {
           
                EquipmentId = 1,
                Count = 5,
                IsActive= true,
                ProductionUnitId = 1
            };
            ProductionRequirement secondReq = new ProductionRequirement()
            {
               
                EquipmentId = 2,
                Count = 2,
                IsActive = true,
                ProductionUnitId = 2
            };
            ProductionRequirement thirdReq = new ProductionRequirement()
            {
                EquipmentId = 3,
                Count = 7,
                IsActive = true,
                ProductionUnitId = 3
            };

            context.ProductionRequirements.Add(firstReq);
            context.ProductionRequirements.Add(secondReq);
            context.ProductionRequirements.Add(thirdReq);

            context.SaveChanges();

        }
    }
}
