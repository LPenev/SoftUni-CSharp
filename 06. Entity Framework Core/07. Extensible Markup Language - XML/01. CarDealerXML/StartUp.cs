﻿using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;

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
            inputXml = File.ReadAllText("../../../Datasets/cars.xml");
            Print(ImportCars(db, inputXml));

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

        

        // Print method to print result
        public static void Print(string printText)
        {
            Console.WriteLine(printText);
        }
    }
}