using Microsoft.EntityFrameworkCore;
using PCkatalogi.Models;

namespace PCkatalogi.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (context.Categories.Any())
            {
                Console.WriteLine("База уже содержит данные. Seed не требуется.");
                return;
            }

            Console.WriteLine("Начало заполнения базы тестовыми данными...");

            var categories = new List<Category>
            {
                new Category { Name = "Процессоры", Description = "Центральные процессоры (CPU)" },
                new Category { Name = "Материнские платы", Description = "Основные платы для сборки ПК" },
                new Category { Name = "Оперативная память", Description = "Модули RAM" },
                new Category { Name = "Умные лампы", Description = "Умные осветительные приборы" },
                new Category { Name = "Умные розетки", Description = "Умные электрические розетки" },
                new Category { Name = "Видеокарты", Description = "Графические процессоры (GPU)" },
                new Category { Name = "Блоки питания", Description = "Источники питания" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();
            Console.WriteLine($"Добавлено {categories.Count} категорий");

            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer { Name = "AMD", Country = "USA", Website = "amd.com" },
                new Manufacturer { Name = "Intel", Country = "USA", Website = "intel.com" },
                new Manufacturer { Name = "ASUS", Country = "Taiwan", Website = "asus.com" },
                new Manufacturer { Name = "MSI", Country = "Taiwan", Website = "msi.com" },
                new Manufacturer { Name = "Gigabyte", Country = "Taiwan", Website = "gigabyte.com" },
                new Manufacturer { Name = "Xiaomi", Country = "China", Website = "mi.com" },
                new Manufacturer { Name = "Philips Hue", Country = "Netherlands", Website = "philips-hue.com" },
                new Manufacturer { Name = "TP-Link", Country = "China", Website = "tp-link.com" },
                new Manufacturer { Name = "Samsung", Country = "South Korea", Website = "samsung.com" },
                new Manufacturer { Name = "Corsair", Country = "USA", Website = "corsair.com" }
            };
            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();
            Console.WriteLine($"Добавлено {manufacturers.Count} производителей");

            var protocols = new List<Protocol>
            {
                new Protocol { Name = "Zigbee", Description = "Протокол для умного дома", Version = "3.0" },
                new Protocol { Name = "Wi-Fi", Description = "Беспроводная сеть", Version = "6" },
                new Protocol { Name = "Bluetooth", Description = "Беспроводная связь", Version = "5.2" },
                new Protocol { Name = "Z-Wave", Description = "Протокол для умного дома", Version = "800" },
                new Protocol { Name = "Matter", Description = "Универсальный протокол", Version = "1.0" },
                new Protocol { Name = "Thread", Description = "Протокол для умного дома", Version = "1.3" }
            };
            context.Protocols.AddRange(protocols);
            context.SaveChanges();
            Console.WriteLine($"Добавлено {protocols.Count} протоколов");

            var components = new List<Component>
            {
                new Component {
                    Name = "AMD Ryzen 5 5600X",
                    Description = "6-ядерный процессор, Socket AM4",
                    Price = 15999.99m,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    CpuSocket = "AM4"
                },
                new Component {
                    Name = "Intel Core i5-12400F",
                    Description = "6-ядерный процессор, Socket LGA1700",
                    Price = 14999.99m,
                    CategoryId = 1,
                    ManufacturerId = 2,
                    CpuSocket = "LGA1700"
                },
                new Component {
                    Name = "AMD Ryzen 7 5800X3D",
                    Description = "8-ядерный процессор с 3D V-Cache",
                    Price = 28999.99m,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    CpuSocket = "AM4"
                },
                new Component {
                    Name = "Intel Core i7-13700K",
                    Description = "16-ядерный процессор",
                    Price = 38999.99m,
                    CategoryId = 1,
                    ManufacturerId = 2,
                    CpuSocket = "LGA1700"
                },
                new Component {
                    Name = "AMD Ryzen 9 7950X",
                    Description = "16-ядерный процессор, Socket AM5",
                    Price = 59999.99m,
                    CategoryId = 1,
                    ManufacturerId = 1,
                    CpuSocket = "AM5"
                },

                new Component {
                    Name = "ASUS ROG STRIX B550-F GAMING",
                    Description = "Материнская плата для AM4",
                    Price = 13999.99m,
                    CategoryId = 2,
                    ManufacturerId = 3,
                    MotherboardSocket = "AM4",
                    FormFactor = "ATX",
                    MemoryType = "DDR4"
                },
                new Component {
                    Name = "MSI MAG B660 TOMAHAWK",
                    Description = "Материнская плата для LGA1700",
                    Price = 15999.99m,
                    CategoryId = 2,
                    ManufacturerId = 4,
                    MotherboardSocket = "LGA1700",
                    FormFactor = "ATX",
                    MemoryType = "DDR5"
                },
                new Component {
                    Name = "Gigabyte X670 AORUS ELITE AX",
                    Description = "Материнская плата для AM5",
                    Price = 28999.99m,
                    CategoryId = 2,
                    ManufacturerId = 5,
                    MotherboardSocket = "AM5",
                    FormFactor = "ATX",
                    MemoryType = "DDR5"
                },

                new Component {
                    Name = "Xiaomi Mi Smart LED Bulb",
                    Description = "Умная лампа с поддержкой Wi-Fi",
                    Price = 1499.99m,
                    CategoryId = 4,
                    ManufacturerId = 6
                },
                new Component {
                    Name = "Philips Hue White and Color",
                    Description = "Умная лампа с поддержкой Zigbee",
                    Price = 3499.99m,
                    CategoryId = 4,
                    ManufacturerId = 7
                },

                new Component {
                    Name = "TP-Link Kasa Smart Plug",
                    Description = "Умная розетка с Wi-Fi",
                    Price = 1299.99m,
                    CategoryId = 5,
                    ManufacturerId = 8
                },
                new Component {
                    Name = "Xiaomi Mi Smart Plug",
                    Description = "Умная розетка с поддержкой Zigbee",
                    Price = 999.99m,
                    CategoryId = 5,
                    ManufacturerId = 6
                }
            };

            context.Components.AddRange(components);
            context.SaveChanges();

            var xiaomiLamp = context.Components.First(c => c.Name == "Xiaomi Mi Smart LED Bulb");
            var philipsLamp = context.Components.First(c => c.Name == "Philips Hue White and Color");
            var tplinkPlug = context.Components.First(c => c.Name == "TP-Link Kasa Smart Plug");
            var xiaomiPlug = context.Components.First(c => c.Name == "Xiaomi Mi Smart Plug");

            var zigbeeProtocol = context.Protocols.First(p => p.Name == "Zigbee");
            var wifiProtocol = context.Protocols.First(p => p.Name == "Wi-Fi");

            xiaomiLamp.Protocols.Add(wifiProtocol);
            philipsLamp.Protocols.Add(zigbeeProtocol);
            tplinkPlug.Protocols.Add(wifiProtocol);
            xiaomiPlug.Protocols.Add(zigbeeProtocol);

            context.SaveChanges();
            Console.WriteLine($"Добавлено {components.Count} компонентов");

            var rules = new List<CompatibilityRule>
            {
                new CompatibilityRule
                {
                    RuleName = "Совместимость сокетов AM4",
                    Description = "Процессор с сокетом AM4 совместим только с материнской платой с сокетом AM4",
                    CompatibilityType = "SocketMatch",
                    SourceComponentId = 1, 
                    TargetComponentId = 6, 
                    CategoryId = 1,
                    RequiredValue = "AM4",
                    RequiredTargetValue = "AM4"
                },
                new CompatibilityRule
                {
                    RuleName = "Совместимость сокетов LGA1700",
                    Description = "Процессор с сокетом LGA1700 совместим только с материнской платой с сокетом LGA1700",
                    CompatibilityType = "SocketMatch",
                    SourceComponentId = 2, 
                    TargetComponentId = 7,
                    CategoryId = 1,
                    RequiredValue = "LGA1700",
                    RequiredTargetValue = "LGA1700"
                },
                new CompatibilityRule
                {
                    RuleName = "Совместимость протоколов Zigbee",
                    Description = "Устройства должны поддерживать один протокол Zigbee",
                    CompatibilityType = "ProtocolMatch",
                    SourceComponentId = 10, 
                    TargetComponentId = 12,
                    CategoryId = 4,
                    RequiredValue = "Zigbee",
                    RequiredTargetValue = "Zigbee"
                }
            };

            context.CompatibilityRules.AddRange(rules);
            context.SaveChanges();
            Console.WriteLine($"Добавлено {rules.Count} правил совместимости");

            Console.WriteLine("Заполнение базы тестовыми данными завершено!");
        }
    }
}