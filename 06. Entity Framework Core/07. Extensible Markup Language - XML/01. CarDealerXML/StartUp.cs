using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            var inputXml = String.Empty;
            var output = String.Empty;

            // 09. Import Suppliers
            //inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //Print(ImportSuppliers(db, inputXml));

            // 10. Import Parts
            //inputXml = File.ReadAllText("../../../Datasets/parts.xml");
            //Print(ImportParts(db, inputXml));

            // 11. Import Cars
            //inputXml = File.ReadAllText("../../../Datasets/cars.xml");
            //Print(ImportCars(db, inputXml));

            // 12. Import Customers
            //inputXml = File.ReadAllText("../../../Datasets/customers.xml");
            //Print(ImportCustomers(db, inputXml));

            // 13. Import Sales
            //inputXml = File.ReadAllText("../../../Datasets/Sales.xml");
            //Print(ImportSales(db, inputXml));

            // 14. Export Cars With Distance
            //Print(GetCarsWithDistance(db));

            // 15. Export Cars from Make BMW
            //Print(GetCarsFromMakeBmw(db));

            // 16. Export Local Suppliers
            //Print(GetLocalSuppliers(db));

            // 17. Export Cars with Their List of Parts
            //Print(GetCarsWithTheirListOfParts(db));

            // 18. Export Total Sales by Customer
            //Print(GetTotalSalesByCustomer(db));

            // 19. Export Sales with Applied Discount
            Print(GetSalesWithAppliedDiscount(db));

        }

        // 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            ImportSupplierDto[] suppliersDto;

            using (var reader = new StringReader(inputXml)) 
            {
                suppliersDto = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);
            }

            Supplier[] suppliers = suppliersDto.Select(dto => new Supplier() 
            {
                Name = dto.Name,
                IsImporter = dto.IsImporter
            }).ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            
            return $"Successfully imported {suppliers.Count()}";
        }

        // 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            using StringReader reader = new StringReader(inputXml);
            ImportPartDto[] partsDto = (ImportPartDto[])xmlSerializer.Deserialize(reader);

            var validSuppliersId = new HashSet<int>(context.Suppliers.Select(x => x.Id));

            Part[] parts = partsDto
                .Where(x => validSuppliersId.Contains(x.SupplierId))
                .Select(dto => new Part()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId
                }).ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        // 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            using StringReader reader = new StringReader(inputXml);
            ImportCarDto[] importCarsDtos = (ImportCarDto[])xmlSerializer.Deserialize(reader);

            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            foreach (var carDto in importCarsDtos)
            {

                Car currentCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance,
                };

                cars.Add(currentCar);

                int[] partIds = carDto.PartId.Select(x => x.PartId)
                    .Distinct()
                    .ToArray();

                foreach (var partId in partIds)
                {
                    partCars.Add( new PartCar
                    {
                        Car = currentCar,
                        PartId = partId
                    });
                }

            }

            context.AddRange(cars);
            context.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        // 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            using StringReader reader = new StringReader(inputXml);

            ImportCustomerDto[] customerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);

            var customers = customerDtos.Select(dto => new Customer
            {
                Name = dto.Name,
                BirthDate = dto.BirthDate,
                IsYoungDriver = dto.IsYoungDriver
            }).ToArray();

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        // 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));

            using StringReader reader = new StringReader(inputXml);
            ImportSaleDto[] saleDtos = (ImportSaleDto[])xmlSerializer.Deserialize(reader);

            var validCarsId = context.Cars.Select(x => x.Id).ToArray();

            ICollection<Sale> sales = saleDtos
                .Where(x => validCarsId.Contains(x.CarId))
                .Select(dto => new Sale
            {
                Discount = dto.Discount,
                CarId = dto.CarId,
                CustomerId = dto.CustomerId
            }).ToList();

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        // 14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarDto[] carsWithDistanceMore2M = context.Cars
                .AsNoTracking()
                .Where(x => x.TraveledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .Select(x => new ExportCarDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance
                }).ToArray();
            
            return ExportXml(carsWithDistanceMore2M, "cars");
        }

        // 15. Export Cars from Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportCarMakeDto[] bmwCarDtos = context.Cars
                .AsNoTracking()
                .Where(x => x.Make.ToUpper() == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .Select(x => new ExportCarMakeDto
                {
                    Id = x.Id,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance
                })
                .ToArray();

            return ExportXml(bmwCarDtos, "cars");
        }

        // 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportSupplierNumberOfPartsDto[] localSupplierDtos = context.Suppliers
                .AsNoTracking()
                .Where(x => !x.IsImporter)
                .Select(x => new ExportSupplierNumberOfPartsDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToArray();

            return ExportXml(localSupplierDtos, "suppliers");
        }

        // 17. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            ExportCarWithPartsDto[] top5CarsWithParts = context.Cars
                .AsNoTracking()
                .OrderByDescending(x => x.TraveledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .Select(x => new ExportCarWithPartsDto()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance,
                    CarParts = x.PartsCars
                        .OrderByDescending(pc => pc.Part.Price)
                        .Select(p => new CarPartsDto()
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        }).ToArray()
                })
                .ToArray();

            return ExportXml(top5CarsWithParts, "cars");
        }

        // 18. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var tempCustomers = context.Customers
                .AsNoTracking()
                .Where(x => x.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales.Select(s => new
                    {
                        Prices = Math.Round((double)s.Car.PartsCars.Sum(x => x.Part.Price) * (c.IsYoungDriver ? 0.95 : 1), 2)
                    }).ToArray()
                })
                .ToArray();

            ExportCustomersSalesInfo[] customersSalesInfoDtos = tempCustomers
                .OrderByDescending(x => x.SpentMoney.Sum(s => s.Prices))
                .Select(x => new ExportCustomersSalesInfo()
            {
                FullName = x.FullName,
                BoughtCars = x.BoughtCars,
                SpentMoney = x.SpentMoney.Sum(s => (decimal)s.Prices).ToString("f3")
            }).ToArray();

            return ExportXml(customersSalesInfoDtos, "customers");
        }

        // 19. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSalesDiscountDto[] SalesWithAppliedDiscount = context.Sales
                .AsNoTracking()
                .Select(x => new ExportSalesDiscountDto()
                {
                    Car = new CarDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TraveledDistance = x.Car.TraveledDistance
                    },
                    Discount = (int)x.Discount,
                    Customer = x.Customer.Name,
                    Price = x.Car.PartsCars.Sum(x => x.Part.Price),
                    DiscountPrice = Math.Round((double)(x.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (x.Discount / 100))), 4)

                }).ToArray();

            return ExportXml(SalesWithAppliedDiscount, "sales");
        }

        // Print method to print result
        public static void Print(string printText)
        {
            Console.WriteLine(printText);
        }

        // Export dto to XML string
        public static string ExportXml<T>(T dtoArray, string xmlRootAttribute, bool ommitDeclaration = false)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = ommitDeclaration,
                Indent = true
            };

            StringBuilder stringBuilder = new StringBuilder();
            using XmlWriter writer = XmlWriter.Create(stringBuilder, settings);

            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize(writer, dtoArray, xmlSerializerNamespaces);

            return stringBuilder.ToString();
        }
    }
}