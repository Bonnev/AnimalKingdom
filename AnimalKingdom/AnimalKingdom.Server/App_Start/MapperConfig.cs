namespace AnimalKingdom.Server.App_Start
{
    using AnimalKingdom.Models;
    using Models.BindingModels;
    using AutoMapper;
    using Models.ViewModels;

    public static class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<User, UserConciseViewModel>()
                .ForMember(vm => vm.Username, opt => opt.MapFrom(u => u.UserName));
            Mapper.CreateMap<Breed, BreedConciseViewModel>();
        }
    }
}