namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Categories
            CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(c => c.Name, ci => ci.MapFrom(s => s.CategoryName));

            CreateMap<Category, CategoryAllViewModel>()
                .ForMember(c => c.Name, ci => ci.MapFrom(s => s.Name));

            //Positions
            CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(rvm => rvm.PositionId, p => p.MapFrom(x => x.Id));

            //Employee
            CreateMap<RegisterEmployeeInputModel, Employee>();

            CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(evm => evm.Position, e => e.MapFrom(x => x.Position.Name));

            //Items
            CreateMap<Category, CreateItemViewModel>()
                .ForMember(cvm => cvm.CategoryId, c => c.MapFrom(x => x.Id));

            CreateMap<CreateItemInputModel, Item>();

            CreateMap<Item, ItemsAllViewModels>()
                .ForMember(ivm => ivm.Category, i => i.MapFrom(x => x.Category.Name));

            //Orders
            CreateMap<CreateOrderInputModel, Order>()
                .ForMember(o => o.DateTime, cim => cim.MapFrom(x => DateTime.Now));

            CreateMap<Order, OrderAllViewModel>()
                .ForMember(ovm => ovm.Employee, o => o.MapFrom(x => x.Employee.Name))
                .ForMember(ovm => ovm.OrderId, o => o.MapFrom(x => x.Id))
                .ForMember(ovm => ovm.DateTime, o => o.MapFrom(x => x.DateTime.ToString("HH:MM:ss dd/MM/yyyy")));


        }
    }
}
