using AutoMapper;
using AzadiSoft.OnlineStore.DomainClasses;
using AzadiSoft.OnlineStore.ViewModels;
using AzadiSoft.OnlineStore.ViewModels;

namespace AzadiSoft.OnlineStore.Framework
{
    public class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<Product, ProductViewModel>();
                mapper.CreateMap<ProductViewModel, Product>();

                mapper.CreateMap<Photo, PhotoViewModel>();
                mapper.CreateMap<PhotoViewModel, Photo>();

            });
        }
    }
}