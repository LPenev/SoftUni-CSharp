namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
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

            CreateMap<Employee, EmployeesAllViewModel>();
        }
    }
}
