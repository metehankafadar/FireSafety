using FireSafety.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety.Data.repository
{
    public class MyInitializer : CreateDatabaseIfNotExists<FireSafetyContext>
    {
        protected override void Seed(FireSafetyContext context)
        {
            ProductionUnit factory1 = new ProductionUnit()
            {
                Id = 1,
                Name = "Socar Factory",
                Location = "Aliağa",
                IsActive = true
            };
            ProductionUnit headOffice = new ProductionUnit()
            {
                Id = 2,
                Name = "Socar Head Office",
                Location = "Konak",
                IsActive = true
            };
            ProductionUnit factory2 = new ProductionUnit()
            {
                Id = 3,
                Name = "Socar Factory2",
                Location = "Menemen",
                IsActive = true
            };
            context.ProductionUnits.Add(factory1);
            context.ProductionUnits.Add(headOffice);
            context.ProductionUnits.Add(factory2);
            context.SaveChanges();

            EquipmentType extingushier = new EquipmentType()
            {
                Id = 1,
                Name = "Fire Extinguisher",
                IsActive = true
            };
            EquipmentType signal = new EquipmentType()
            {
                Id = 2,
                Name = "Firealarm Signals",
                IsActive = true
            };
            EquipmentType hose = new EquipmentType()
            {
                Id = 3,
                Name = "Fire Hose",
                IsActive = true
            };
            EquipmentType pump = new EquipmentType()
            {
                Id = 4,
                Name = "Fire Pump",
                IsActive = true
            };

            EquipmentType stairs = new EquipmentType()
            {
                Id = 5,
                Name = "Fire-escape Stairs",
                IsActive = true
            };

            EquipmentType bucket = new EquipmentType()
            {
                Id = 6,
                Name = "Fire Bucket",
                IsActive = true
            };
            context.EquipmentTypes.Add(extingushier);
            context.EquipmentTypes.Add(signal);
            context.EquipmentTypes.Add(hose);
            context.EquipmentTypes.Add(pump);
            context.EquipmentTypes.Add(stairs);
            context.EquipmentTypes.Add(bucket);

            context.SaveChanges();
            Random random = new Random();
            for (int i = 1; i < 7; i++)
            {
                ProductionRequirement firstReq = new ProductionRequirement()
                {
                    EquipmentTypeId = i,
                    Count = random.Next(3, 9),
                    IsActive = true,
                    ProductionUnitId = 1
                };
                context.ProductionRequirements.Add(firstReq);

                ProductionRequirement secondReq = new ProductionRequirement()
                {
                    EquipmentTypeId = i,
                    Count = random.Next(3, 9),
                    IsActive = true,
                    ProductionUnitId = 2
                };
                context.ProductionRequirements.Add(secondReq);

                ProductionRequirement thirdReq = new ProductionRequirement()
                {
                    EquipmentTypeId = i,
                    Count = random.Next(3, 9),
                    IsActive = true,
                    ProductionUnitId = 3
                };
                context.ProductionRequirements.Add(thirdReq);
            }

            context.SaveChanges();
            int count = 1;
            for (int i = 1; i < 7; i++)
            {
                for (int j = 0; j < random.Next(1, 5); j++)
                {
                    Equipment equipment1 = new Equipment()
                    {
                        Id = count++,
                        EquipmentTypeId = i,
                        EquipmentNo = random.Next(1000000).ToString(),
                        IsActive = true,
                        ProductionUnitId = 1,
                        ExpirationDate = DateTime.Now.AddYears(1),
                        SeriNo = random.Next(1000000).ToString()
                    };
                    context.Equipments.Add(equipment1);

                }

                for (int j = 0; j < random.Next(1, 5); j++)
                {

                    Equipment equipment2 = new Equipment()
                    {
                        Id = count++,
                        EquipmentTypeId = i,
                        EquipmentNo = random.Next(1000000).ToString(),
                        IsActive = true,
                        ProductionUnitId = 2,
                        ExpirationDate = DateTime.Now.AddYears(1),
                        SeriNo = random.Next(1000000).ToString()
                    };
                    context.Equipments.Add(equipment2);
                }

                for (int j = 0; j < random.Next(1, 5); j++)
                {

                    Equipment equipment3 = new Equipment()
                    {
                        Id = count++,
                        EquipmentNo = random.Next(1000000).ToString(),
                        EquipmentTypeId = i,
                        IsActive = false,
                        ProductionUnitId = 3,
                        ExpirationDate = DateTime.Now.AddYears(1),
                        SeriNo = random.Next(1000000).ToString(),
                    };
                    context.Equipments.Add(equipment3);
                }
            }

            context.SaveChanges();
            for (int i = 1; i < count; i++)
            {
                EquipmentControl ffirst = new EquipmentControl()
                {
                    EquipmentId = i,
                    PressureLevel = 95,
                    PhysicalInspection = true,
                    ProtectionPinStatus = true,
                    ControlDate = DateTime.UtcNow.AddDays(-5),
                    CreatedByUser = "Veli",
                    IsActive = true
                };
                EquipmentControl second = new EquipmentControl()
                {
                    EquipmentId = i,
                    PressureLevel = 55,
                    PhysicalInspection = true,
                    ProtectionPinStatus = false,
                    ControlDate = DateTime.UtcNow.AddDays(-4),
                    CreatedByUser = "Metehan",
                    IsActive = false
                };
                EquipmentControl third = new EquipmentControl()
                {
                    EquipmentId = i,
                    PressureLevel = 45,
                    PhysicalInspection = false,
                    ProtectionPinStatus = true,
                    ControlDate = DateTime.UtcNow.AddDays(-1),
                    CreatedByUser = "Ayşe",
                    IsActive = true
                };
                context.EquipmentControls.Add(ffirst);
                context.EquipmentControls.Add(second);
                context.EquipmentControls.Add(third);
            }

            context.SaveChanges();
        }
    }
}