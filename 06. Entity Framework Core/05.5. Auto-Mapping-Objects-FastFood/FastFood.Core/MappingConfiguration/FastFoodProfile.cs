namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
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

        }
    }
}
