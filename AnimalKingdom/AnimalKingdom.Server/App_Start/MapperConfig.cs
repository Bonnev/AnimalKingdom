namespace AnimalKingdom.Server.App_Start
{
    using AnimalKingdom.Models;
    using Models.BindingModels;
    using AutoMapper;
    using Models.ViewModels;
    using System.Linq;
    using System.Data.Entity.Spatial;

    public static class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<User, UserConciseViewModel>()
                .ForMember(vm => vm.Username, opt => opt.MapFrom(u => u.UserName));
            Mapper.CreateMap<Breed, BreedConciseViewModel>();
            Mapper.CreateMap<Animal, AnimalDetailsViewModel>()
                .ForMember(vm => vm.Type, opt => opt.MapFrom(a => a.Type.Name))
                .ForMember(vm => vm.Breed, opt => opt.MapFrom(a => a.Breed == null ? null : a.Breed.Name))
                .ForMember(vm => vm.Gender, opt => opt.MapFrom(a => a.Gender.Name))
                .ForMember(vm => vm.FinderNames, opt => opt.MapFrom(a => a.Finders.Select(f => f.Name + " (" + f.UserName + ")")))
                .ForMember(vm => vm.AdopterName, opt => opt.MapFrom(a => a.Adopter == null ? null : a.Adopter.Name + " (" + a.Adopter.UserName + ")"));
            Mapper.CreateMap<Animal, AnimalLocationViewModel>()
                .ForMember(vm => vm.Latitude, opt => opt.MapFrom(a => a.Location.Latitude))
                .ForMember(vm => vm.Longitude, opt => opt.MapFrom(a => a.Location.Longitude));
        }
    }
}