using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
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

            // 15. Export Cars from Make BMW


            // 14. Export Cars With Distance
            //Print(GetCarsWithDistance(db));

            // 15. Export Cars from Make BMW
            Print(GetCarsFromMakeBmw(db));

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

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarDto[]), new XmlRootAttribute("cars"));

            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = false,
                Indent = true
            };

            StringBuilder stringBuilder = new StringBuilder();

            using XmlWriter writer = XmlWriter.Create(stringBuilder, settings);
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize(writer, carsWithDistanceMore2M, xmlSerializerNamespaces);
            
            return stringBuilder.ToString();
        }

        // 15. Export Cars from Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportCarMakeDto[] bmwCarDtos = context.Cars
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

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarMakeDto[]), new XmlRootAttribute("cars"));

            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = false,
                Indent = true
            };

            StringBuilder stringBuilder = new StringBuilder();
            using XmlWriter writer = XmlWriter.Create(stringBuilder, settings);
            
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize(writer, bmwCarDtos, xmlSerializerNamespaces);

            return stringBuilder.ToString();
        }

        // Print method to print result
        public static void Print(string printText)
        {
            Console.WriteLine(printText);
        }
    }
}