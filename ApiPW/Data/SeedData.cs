using Microsoft.EntityFrameworkCore;
using ApiPW.Models;

namespace ApiPW.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Departments.Any())
                {
                    return; 
                }

                var departments = new Department[]
                {
                    new Department { Name = "Хирургическое отделение", Location = "Корпус А, 2 этаж" },
                    new Department { Name = "Терапевтическое отделение", Location = "Корпус Б, 1 этаж" },
                    new Department { Name = "Реанимация", Location = "Корпус А, 1 этаж" },
                    new Department { Name = "Рентгенология", Location = "Корпус В, 1 этаж" },
                    new Department { Name = "Лаборатория", Location = "Корпус Г, 3 этаж" }
                };
                context.Departments.AddRange(departments);
                context.SaveChanges();

                var equipmentTypes = new EquipmentType[]
                {
                    new EquipmentType { Name = "Аппарат ИВЛ", Description = "Аппарат искусственной вентиляции легких" },
                    new EquipmentType { Name = "Дефибриллятор", Description = "Медицинский прибор для дефибрилляции" },
                    new EquipmentType { Name = "Рентгеновский аппарат", Description = "Аппарат для рентгенографии" },
                    new EquipmentType { Name = "Кардиомонитор", Description = "Монитор для отслеживания сердечной деятельности" },
                    new EquipmentType { Name = "Инфузомат", Description = "Аппарат для инфузионной терапии" }
                };
                context.EquipmentTypes.AddRange(equipmentTypes);
                context.SaveChanges();

                var equipment = new Equipment[]
                {
                    new Equipment {
                        Name = "ИВЛ Drager",
                        SerialNumber = "DRG-2023-001",
                        Status = EquipmentStatus.Active,
                        PurchaseDate = new DateTime(2023, 1, 15),
                        PurchasePrice = 1500000,
                        DepartmentId = departments[2].Id,
                        EquipmentTypeId = equipmentTypes[0].Id
                    },
                    new Equipment {
                        Name = "Дефибриллятор Philips",
                        SerialNumber = "PHL-2022-045",
                        Status = EquipmentStatus.Active,
                        PurchaseDate = new DateTime(2022, 11, 20),
                        PurchasePrice = 890000,
                        DepartmentId = departments[0].Id,
                        EquipmentTypeId = equipmentTypes[1].Id
                    },
                    new Equipment {
                        Name = "Рентген Siemens",
                        SerialNumber = "SI-2021-123",
                        Status = EquipmentStatus.Maintenance,
                        PurchaseDate = new DateTime(2021, 5, 10),
                        PurchasePrice = 3500000,
                        DepartmentId = departments[3].Id,
                        EquipmentTypeId = equipmentTypes[2].Id
                    },
                    new Equipment {
                        Name = "Монитор пациента",
                        SerialNumber = "MP-2023-078",
                        Status = EquipmentStatus.Active,
                        PurchaseDate = new DateTime(2023, 3, 5),
                        PurchasePrice = 450000,
                        DepartmentId = departments[1].Id,
                        EquipmentTypeId = equipmentTypes[3].Id
                    },
                    new Equipment {
                        Name = "Инфузомат B. Braun",
                        SerialNumber = "BB-2022-156",
                        Status = EquipmentStatus.Active,
                        PurchaseDate = new DateTime(2022, 8, 30),
                        PurchasePrice = 320000,
                        DepartmentId = departments[4].Id,
                        EquipmentTypeId = equipmentTypes[4].Id
                    }
                };
                context.Equipment.AddRange(equipment);
                context.SaveChanges();

                var maintenanceRecords = new MaintenanceRecord[]
                {
                    new MaintenanceRecord {
                        EquipmentId = equipment[0].Id,
                        MaintenanceDate = new DateTime(2024, 1, 10),
                        MaintenanceType = MaintenanceType.Routine,
                        Description = "Плановое техническое обслуживание",
                        PerformedBy = "Иванов А.С.",
                        Cost = 15000
                    },
                    new MaintenanceRecord {
                        EquipmentId = equipment[1].Id,
                        MaintenanceDate = new DateTime(2024, 2, 5),
                        MaintenanceType = MaintenanceType.Calibration,
                        Description = "Калибровка датчиков",
                        PerformedBy = "Петров В.И.",
                        Cost = 8000
                    },
                    new MaintenanceRecord {
                        EquipmentId = equipment[2].Id,
                        MaintenanceDate = new DateTime(2024, 1, 25),
                        MaintenanceType = MaintenanceType.Repair,
                        Description = "Замена рентгеновской трубки",
                        PerformedBy = "Сидоров П.К.",
                        Cost = 120000
                    },
                    new MaintenanceRecord {
                        EquipmentId = equipment[3].Id,
                        MaintenanceDate = new DateTime(2024, 2, 15),
                        MaintenanceType = MaintenanceType.Inspection,
                        Description = "Профилактический осмотр",
                        PerformedBy = "Козлов М.А.",
                        Cost = 5000
                    },
                    new MaintenanceRecord {
                        EquipmentId = equipment[4].Id,
                        MaintenanceDate = new DateTime(2024, 2, 20),
                        MaintenanceType = MaintenanceType.Routine,
                        Description = "Плановое ТО, замена фильтров",
                        PerformedBy = "Николаев С.В.",
                        Cost = 7000
                    }
                };
                context.MaintenanceRecords.AddRange(maintenanceRecords);
                context.SaveChanges();
            }
        }
    }
}