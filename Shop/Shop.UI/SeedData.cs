using System.Collections.Generic;
using System.Linq;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.UI
{
    public static class SeedData
    {
        public static void Seed(ApplicationDbContext context)
        {
            SeedProducts(context);
            SeedPosts(context);
        }

        private static string Body(string lead) =>
            "{\"ops\":[{\"attributes\":{\"bold\":true},\"insert\":\"" + lead + "\"}," +
            "{\"insert\":\". Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
            "Donec euismod, nisi vel consectetur euismod, nunc nisl aliquam nunc, " +
            "vitae aliquam nisl nunc eu nisl. Sed euismod, nisl vel consectetur euismod.\\n\"}]}";

        private static Specification BaseSpec() => new Specification
        {
            AccumCapacity = " ", Screen = " ", BuiltInAccum = " ", MaxVoltage = " ", VoltageChange = " ",
            BakValue = " ", PuffCol = " ", Flavour = " ", Vgpg = " ", Nic = " ", NicProp = " ", LiqValue = " ",
            MTL = " ", Spiral = " ", Obduv = " ", Type = " ", Amper = " ", Length = " ", Size = " ",
            Width = " ", Weigth = " ", CharghingTime = " ",
        };

        private static Stock S(string description, decimal value, int qty, string color, int sale, string image) =>
            new Stock
            {
                Description = description,
                Value = value,
                Qty = qty,
                Color = color,
                IsOnSale = sale,
                IsActive = true,
                PropImage = image,
            };

        private static void SeedProducts(ApplicationDbContext context)
        {
            if (context.Products.Any())
                return;

            const string date = "10/05/2024";
            var products = new List<Product>();

            void Add(string name, string category, decimal value, string shortDesc,
                bool isNew, bool isTrending, Specification spec, List<Stock> stocks)
            {
                products.Add(new Product
                {
                    Name = name,
                    Category = category,
                    Value = value,
                    Description = shortDesc,
                    FullDescription = Body(name),
                    Image = stocks[0].PropImage,
                    DateTime = date,
                    IsActive = true,
                    IsNew = isNew,
                    IsTrending = isTrending,
                    AvRating = 0,
                    Specification = new List<Specification> { spec },
                    Stock = stocks,
                    Review = new List<Review>(),
                });
            }

            // ---- POD-системы (с вариациями/цветами) ----
            var podSpec1 = BaseSpec();
            podSpec1.AccumCapacity = "1000 mAh"; podSpec1.BakValue = "2 мл"; podSpec1.Type = "POD-система";
            podSpec1.MaxVoltage = "16 Вт"; podSpec1.Weigth = "52 г"; podSpec1.CharghingTime = "45 мин";
            Add("Vaporesso XROS 3", "POD", 59.90m, "Компактная POD-система с регулировкой воздуха", true, true, podSpec1,
                new List<Stock>
                {
                    S("Чёрный", 59.90m, 25, "#222222", 0, "img_09-03-2022-23-13-34.jpg"),
                    S("Голубой", 59.90m, 18, "#4a90d9", 0, "img_09-03-2022-23-13-38.jpg"),
                    S("Серебристый", 59.90m, 12, "#c0c0c0", 10, "img_09-03-2022-23-16-30.jpg"),
                });

            var podSpec2 = BaseSpec();
            podSpec2.AccumCapacity = "750 mAh"; podSpec2.BakValue = "2 мл"; podSpec2.Type = "POD-система";
            podSpec2.MaxVoltage = "18 Вт"; podSpec2.Weigth = "38 г";
            Add("Uwell Caliburn G2", "POD", 54.50m, "Лёгкая система с затяжкой MTL", true, false, podSpec2,
                new List<Stock>
                {
                    S("Чёрный", 54.50m, 30, "#1a1a1a", 0, "img_09-03-2022-23-16-48.jpg"),
                    S("Серый", 54.50m, 20, "#7d7d7d", 0, "img_09-03-2022-23-29-49.jpg"),
                    S("Красный", 54.50m, 10, "#b32424", 0, "img_09-03-2022-23-30-17.jpg"),
                });

            var podSpec3 = BaseSpec();
            podSpec3.AccumCapacity = "2000 mAh"; podSpec3.BakValue = "4.5 мл"; podSpec3.Type = "POD-система";
            podSpec3.MaxVoltage = "80 Вт"; podSpec3.Screen = "OLED"; podSpec3.Weigth = "98 г";
            Add("SMOK Nord 4", "POD", 69.00m, "Мощная POD-система со сменными испарителями", false, true, podSpec3,
                new List<Stock>
                {
                    S("Чёрный", 69.00m, 22, "#161616", 0, "img_09-03-2022-23-30-46.jpg"),
                    S("Серебристый", 69.00m, 14, "#cfcfcf", 0, "img_09-03-2022-23-31-14.jpg"),
                });

            var podSpec4 = BaseSpec();
            podSpec4.AccumCapacity = "1500 mAh"; podSpec4.BakValue = "3.7 мл"; podSpec4.Type = "POD-система";
            podSpec4.MaxVoltage = "40 Вт"; podSpec4.Screen = "Цветной TFT"; podSpec4.Weigth = "120 г";
            Add("GeekVape Aegis Boost Plus", "POD", 89.90m, "Защищённая POD-система IP67", false, true, podSpec4,
                new List<Stock>
                {
                    S("Чёрный", 89.90m, 16, "#0f0f0f", 0, "img_09-03-2022-23-31-42.jpg"),
                    S("Тёмно-серый", 89.90m, 11, "#4d4d4d", 0, "img_09-03-2022-23-31-46.jpg"),
                    S("Камуфляж", 89.90m, 7, "#5b6e4a", 15, "img_13-03-2022-15-56-31.jpg"),
                });

            // ---- MOD (с вариациями/цветами) ----
            var modSpec1 = BaseSpec();
            modSpec1.MaxVoltage = "177 Вт"; modSpec1.Screen = "Цветной 0.96\""; modSpec1.Type = "Бокс-мод";
            modSpec1.VoltageChange = "Есть"; modSpec1.Weigth = "135 г";
            Add("Voopoo Drag 3", "MOD", 139.00m, "Бокс-мод на чипе GENE.FAN 2.0", true, true, modSpec1,
                new List<Stock>
                {
                    S("Чёрный", 139.00m, 14, "#111111", 0, "img_13-03-2022-16-20-43.jpg"),
                    S("Марсала", 139.00m, 9, "#7a2e2e", 0, "img_13-03-2022-16-28-49.jpg"),
                    S("Серебристый", 139.00m, 6, "#bdbdbd", 10, "img_13-03-2022-16-28-54.jpg"),
                });

            var modSpec2 = BaseSpec();
            modSpec2.MaxVoltage = "200 Вт"; modSpec2.Screen = "Цветной 1.08\""; modSpec2.Type = "Бокс-мод";
            modSpec2.VoltageChange = "Есть"; modSpec2.Weigth = "168 г";
            Add("GeekVape Aegis Legend 2", "MOD", 159.90m, "Ударопрочный мод с защитой от воды и пыли", false, true, modSpec2,
                new List<Stock>
                {
                    S("Чёрный", 159.90m, 13, "#101010", 0, "img_17-03-2022-12-44-00.jpg"),
                    S("Камуфляж", 159.90m, 8, "#586a45", 0, "img_17-03-2022-12-44-01.jpg"),
                });

            var modSpec3 = BaseSpec();
            modSpec3.MaxVoltage = "220 Вт"; modSpec3.Screen = "Цветной TFT"; modSpec3.Type = "Бокс-мод";
            modSpec3.VoltageChange = "Есть"; modSpec3.Weigth = "150 г";
            Add("Vaporesso Gen 200", "MOD", 149.00m, "Двухаккумуляторный мод на чипе AXON", true, false, modSpec3,
                new List<Stock>
                {
                    S("Чёрный", 149.00m, 12, "#161616", 0, "img_19-03-2022-17-07-43.jpg"),
                    S("Серый", 149.00m, 9, "#808080", 0, "img_19-03-2022-17-07-44.jpg"),
                });

            // ---- Vape (готовые наборы, с вариациями) ----
            var vapeSpec1 = BaseSpec();
            vapeSpec1.AccumCapacity = "2000 mAh"; vapeSpec1.BakValue = "4 мл"; vapeSpec1.MaxVoltage = "80 Вт";
            vapeSpec1.Screen = "OLED"; vapeSpec1.Type = "Pod-mod набор"; vapeSpec1.Weigth = "112 г";
            Add("SMOK RPM 5", "Vape", 84.00m, "Универсальный набор со сменными испарителями", true, false, vapeSpec1,
                new List<Stock>
                {
                    S("Чёрный", 84.00m, 18, "#131313", 0, "img_19-03-2022-17-08-40.jpg"),
                    S("Синий", 84.00m, 12, "#2e4a8a", 0, "img_19-03-2022-17-09-04.jpg"),
                    S("Красный", 84.00m, 8, "#a82828", 0, "img_19-03-2022-17-09-24.jpg"),
                });

            var vapeSpec2 = BaseSpec();
            vapeSpec2.AccumCapacity = "1500 mAh"; vapeSpec2.BakValue = "3.5 мл"; vapeSpec2.MaxVoltage = "40 Вт";
            vapeSpec2.Type = "Pod-mod набор"; vapeSpec2.Weigth = "95 г";
            Add("Voopoo Argus GT 2", "Vape", 129.00m, "Лёгкий набор с быстрой зарядкой Type-C", false, true, vapeSpec2,
                new List<Stock>
                {
                    S("Чёрный", 129.00m, 15, "#181818", 0, "img_19-03-2022-17-34-55.jpg"),
                    S("Серебристый", 129.00m, 10, "#c8c8c8", 0, "img_19-03-2022-17-10-17.jpg"),
                });

            // ---- Одноразки (одна вариация) ----
            var dispSpec1 = BaseSpec();
            dispSpec1.PuffCol = "5000 затяжек"; dispSpec1.Flavour = "Микс"; dispSpec1.Nic = "Солевой";
            dispSpec1.NicProp = "20 мг/мл"; dispSpec1.LiqValue = "13 мл"; dispSpec1.Type = "Одноразовая";
            Add("Elf Bar BC5000", "Одноразка", 22.90m, "Одноразовая система на 5000 затяжек", true, true, dispSpec1,
                new List<Stock> { S("Стандартный", 22.90m, 60, "#000000", 0, "img_19-03-2022-17-13-01.jpg") });

            var dispSpec2 = BaseSpec();
            dispSpec2.PuffCol = "5000 затяжек"; dispSpec2.Flavour = "Микс"; dispSpec2.Nic = "Солевой";
            dispSpec2.NicProp = "20 мг/мл"; dispSpec2.LiqValue = "13 мл"; dispSpec2.Type = "Одноразовая";
            Add("Lost Mary OS5000", "Одноразка", 24.50m, "Одноразовая система с двойной спиралью", true, false, dispSpec2,
                new List<Stock> { S("Стандартный", 24.50m, 45, "#000000", 0, "img_19-03-2022-17-13-20.jpg") });

            var dispSpec3 = BaseSpec();
            dispSpec3.PuffCol = "1200 затяжек"; dispSpec3.Flavour = "Микс"; dispSpec3.Nic = "Солевой";
            dispSpec3.NicProp = "20 мг/мл"; dispSpec3.LiqValue = "4 мл"; dispSpec3.Type = "Одноразовая";
            Add("HQD Cuvie Plus", "Одноразка", 15.90m, "Лёгкая одноразка для начинающих", false, false, dispSpec3,
                new List<Stock> { S("Стандартный", 15.90m, 70, "#000000", 10, "img_19-03-2022-17-14-33.jpg") });

            // ---- Жидкости ----
            var liqSpec1 = BaseSpec();
            liqSpec1.Flavour = "Мята"; liqSpec1.Vgpg = "50/50"; liqSpec1.Nic = "Солевой";
            liqSpec1.NicProp = "20 мг/мл"; liqSpec1.LiqValue = "30 мл";
            Add("Husky Mint Series", "Жидкость", 19.90m, "Освежающая жидкость со вкусом мяты", false, false, liqSpec1,
                new List<Stock> { S("Стандартный", 19.90m, 40, "#3aa76d", 0, "img_19-03-2022-17-16-36.jpg") });

            var liqSpec2 = BaseSpec();
            liqSpec2.Flavour = "Клубника"; liqSpec2.Vgpg = "70/30"; liqSpec2.Nic = "Без никотина";
            liqSpec2.NicProp = "0 мг/мл"; liqSpec2.LiqValue = "100 мл";
            Add("Jam Monster Strawberry", "Жидкость", 27.50m, "Десертная жидкость с клубничным джемом", false, true, liqSpec2,
                new List<Stock> { S("Стандартный", 27.50m, 28, "#c0392b", 0, "img_19-03-2022-17-17-21.jpg") });

            var liqSpec3 = BaseSpec();
            liqSpec3.Flavour = "Лимон"; liqSpec3.Vgpg = "70/30"; liqSpec3.Nic = "Без никотина";
            liqSpec3.NicProp = "0 мг/мл"; liqSpec3.LiqValue = "60 мл";
            Add("Bad Drip Dead Lemon", "Жидкость", 29.00m, "Кисло-сладкая лимонная жидкость", false, false, liqSpec3,
                new List<Stock> { S("Стандартный", 29.00m, 22, "#e0c020", 0, "img_19-03-2022-17-17-47.jpg") });

            // ---- Испарители ----
            var coilSpec1 = BaseSpec();
            coilSpec1.Spiral = "Mesh 0.6 Ω"; coilSpec1.Type = "Сменный испаритель"; coilSpec1.MTL = "Нет";
            Add("Vaporesso GTX Coil 0.6Ω", "Испаритель", 13.50m, "Сетчатый испаритель для серии GTX", false, false, coilSpec1,
                new List<Stock> { S("Стандартный", 13.50m, 80, "#777777", 0, "img_19-03-2022-17-18-35.jpg") });

            var coilSpec2 = BaseSpec();
            coilSpec2.Spiral = "Mesh 0.4 Ω"; coilSpec2.Type = "Сменный испаритель"; coilSpec2.MTL = "Нет";
            Add("SMOK RPM Mesh Coil 0.4Ω", "Испаритель", 14.90m, "Сетчатый испаритель для серии RPM", false, false, coilSpec2,
                new List<Stock> { S("Стандартный", 14.90m, 75, "#777777", 0, "img_19-03-2022-17-34-10.jpg") });

            // ---- Атомайзеры ----
            var atomSpec1 = BaseSpec();
            atomSpec1.BakValue = "4.5 мл"; atomSpec1.Spiral = "Двойная"; atomSpec1.Obduv = "Боковой";
            atomSpec1.Type = "RTA"; atomSpec1.MTL = "Нет";
            Add("GeekVape Zeus X RTA", "Атомайзер", 49.90m, "Обслуживаемый бак с защитой от протечек", false, true, atomSpec1,
                new List<Stock> { S("Стандартный", 49.90m, 20, "#999999", 0, "img_09-03-2022-23-13-34.jpg") });

            // ---- Аккумуляторы ----
            var battSpec1 = BaseSpec();
            battSpec1.AccumCapacity = "2600 mAh"; battSpec1.Amper = "35 A"; battSpec1.Type = "18650";
            Add("Molicel P26A 18650", "Аккумулятор", 12.90m, "Высокотоковый аккумулятор 18650", false, false, battSpec1,
                new List<Stock> { S("Стандартный", 12.90m, 100, "#444444", 0, "img_09-03-2022-23-13-38.jpg") });

            var battSpec2 = BaseSpec();
            battSpec2.AccumCapacity = "2500 mAh"; battSpec2.Amper = "20 A"; battSpec2.Type = "18650";
            Add("Samsung 25R 18650", "Аккумулятор", 11.50m, "Надёжный аккумулятор 18650", false, false, battSpec2,
                new List<Stock> { S("Стандартный", 11.50m, 100, "#444444", 0, "img_09-03-2022-23-16-30.jpg") });

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void SeedPosts(ApplicationDbContext context)
        {
            if (context.Posts.Any())
                return;

            var posts = new List<Post>
            {
                new Post
                {
                    Title = "Новинка: Vaporesso XROS 3 уже в продаже",
                    Description = "Разбираем компактную POD-систему нового поколения.",
                    Category = "news", Tags = "новинки, pod", Created = "10/05/2024", IsActive = true,
                    Image = "img_20-03-2022-00-51-50.jpg", Body = Body("Vaporesso XROS 3"),
                },
                new Post
                {
                    Title = "Скидки недели: успей купить выгодно",
                    Description = "Подборка товаров со скидкой до 15%.",
                    Category = "sales", Tags = "скидки, акции", Created = "08/05/2024", IsActive = true,
                    Image = "img_20-03-2022-00-54-02.jpg", Body = Body("Скидки недели"),
                },
                new Post
                {
                    Title = "Свежие вкусы жидкостей этого сезона",
                    Description = "Что попробовать любителям десертных и фруктовых вкусов.",
                    Category = "fresh", Tags = "жидкости, вкусы", Created = "05/05/2024", IsActive = true,
                    Image = "img_20-03-2022-00-55-41.jpg", Body = Body("Свежие вкусы сезона"),
                },
                new Post
                {
                    Title = "Подборка лучших POD-систем 2024 года",
                    Description = "Сравниваем популярные модели для повседневного использования.",
                    Category = "compil", Tags = "подборка, pod", Created = "02/05/2024", IsActive = true,
                    Image = "img_20-03-2022-00-56-46.jpg", Body = Body("Лучшие POD-системы 2024"),
                },
                new Post
                {
                    Title = "Обзор GeekVape Aegis Legend 2",
                    Description = "Тестируем защищённый мод в реальных условиях.",
                    Category = "reviews", Tags = "обзор, mod", Created = "28/04/2024", IsActive = true,
                    Image = "img_20-03-2022-00-58-18.jpg", Body = Body("Обзор GeekVape Aegis Legend 2"),
                },
                new Post
                {
                    Title = "Как выбрать первую вейп-систему",
                    Description = "Простой гид для тех, кто только начинает.",
                    Category = "news", Tags = "гид, новичкам", Created = "25/04/2024", IsActive = true,
                    Image = "img_20-03-2022-01-00-41.jpg", Body = Body("Как выбрать первую вейп-систему"),
                },
            };

            context.Posts.AddRange(posts);
            context.SaveChanges();
        }
    }
}
