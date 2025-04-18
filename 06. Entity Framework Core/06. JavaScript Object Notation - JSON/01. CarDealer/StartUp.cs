﻿using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;

namespace CarDealer
{
    //Microsoft.EntityFrameworkCore.Tools
    //Add-Migration Initial
    //Update-Database
    public class StartUp
    {
        public StartUp()
        {
        }

        public static void Main()
        {
            var db = new CarDealerContext();

            // 09. Import Suppliers
            //var suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(db, suppliersJson));

            // 10. Import Parts
            //var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(db, partsJson));

            // 11. Import Cars
            //var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(db, carsJson));

            // 12. Import Customers
            //var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(db, customersJson));

            // 13. Import Sales
            //var salesJson = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(db, salesJson));

            // 14. Export Ordered Customers
            //Console.WriteLine(GetOrderedCustomers(db));

            // 15. Export Cars from Make Toyota
            //Console.WriteLine(GetCarsFromMakeToyota(db));

            // 16. Export Local Suppliers
            //Console.WriteLine(GetLocalSuppliers(db));

            // 17. Export Cars with Their List of Parts
            //Console.WriteLine(GetCarsWithTheirListOfParts(db));

            // 18. Export Total Sales by Customer
            //Console.WriteLine(GetTotalSalesByCustomer(db));

            // 19. Export Sales with Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(db));

        }

        // 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        // 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

            var validSupplierIds = context.Suppliers.Select(x => x.Id);

            var partsWithValidSuppliers = parts.Where(x => validSupplierIds.Contains(x.SupplierId));

            context.Parts.AddRange(partsWithValidSuppliers);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        // 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var importCars = JsonConvert.DeserializeObject<List<ImportCarsDto>>(inputJson);

            var cars = new HashSet<Car>();
            var partsCars = new HashSet<PartCar>();

            foreach (ImportCarsDto importCar in importCars)
            {
                var newCar = new Car()
                {
                    Make = importCar.Make,
                    Model = importCar.Model,
                    TraveledDistance = importCar.TraveledDistance,
                };

                cars.Add(newCar);

                foreach (var partId in importCar.PartsId.Distinct())
                {
                    partsCars.Add(new PartCar
                    {
                        Car = newCar,
                        PartId = partId,
                    });
                }
            }
            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partsCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        // 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        // 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var salesDtos = JsonConvert.DeserializeObject<List<ImportSalesDto>>(inputJson);

            var sales = salesDtos.Select(dto => new Sale
            {
                CarId = dto.CarId,
                CustomerId = dto.CustomerId,
                Discount = dto.Discount
            }).ToList();
            
            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        // 14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers = context.Customers
                .AsNoTracking()
                .OrderBy(c => c.BirthDate)
                .Select(x => new
                {
                    x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    x.IsYoungDriver
                })
                .ToArray();

            var orderedCustomersJson = JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);

            return orderedCustomersJson;
        }

        // 15. Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsFromMakeToyota = context.Cars
                .AsNoTracking()
                .Where(c => c.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TraveledDistance
                })
                .ToArray();

            var carsFromMakeToyotaJson = JsonConvert.SerializeObject(carsFromMakeToyota, Formatting.Indented);

            return carsFromMakeToyotaJson;
        }

        // 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .AsNoTracking()
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            var localSuppliersJson = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);

            return localSuppliersJson;
        }

        // 17. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithTheirListOfParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance,
                    },
                    parts = c.PartsCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("f2"),
                    }).ToArray()
                }).ToArray();

            var carsWithTheirListOfPartsJson = JsonConvert.SerializeObject(carsWithTheirListOfParts, Formatting.Indented);

            return carsWithTheirListOfPartsJson;
        }

        // 18. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var totalSalesByCustomer = context.Customers
                .AsNoTracking()
                .Where(x => x.Sales.Any())
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count(),
                    spentMoney = x.Sales
                        .SelectMany(s => s.Car.PartsCars)
                        .Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            return JsonConvert.SerializeObject(totalSalesByCustomer, JsonSettings());
        }

        // 19. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new
                    {
                        x.Car.Make,
                        x.Car.Model,
                        x.Car.TraveledDistance
                    },
                    customerName = x.Customer.Name,
                    discount = x.Discount.ToString("f2"),
                    price = x.Car.PartsCars.Sum(x => x.Part.Price).ToString("f2"),
                    priceWithDiscount = (x.Car.PartsCars.Sum(x => x.Part.Price) * ( 1 - x.Discount / 100)).ToString("f2")
                });

            var salesWithAppliedDiscount = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return salesWithAppliedDiscount;
        }

        // Json Settings
        public static JsonSerializerSettings JsonSettings()
        {
            var jsonSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };

            return jsonSettings;
        }
    }
}