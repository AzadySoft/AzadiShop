using System.Linq;
using AutoMapper;
using AzadiSoft.OnlineStore.DomainClasses;
using AzadiSoft.OnlineStore.ViewModels;

namespace AzadiSoft.OnlineStore.Framework
{
    public static class MappingExtension
    {
        public static ProductViewModel ToModel(this Product entity)
        {
            var model = Mapper.Map<Product, ProductViewModel>(entity);

            if (entity.Product_Spec_Mapping.Any())
            {
                model.ProductSpecMappings = entity.Product_Spec_Mapping.Select(x => x.ToModel()).ToList();
            }

            if (entity.Photos.Any())
            {
                model.Photos = entity.Photos.Select(x => x.ToModel()).ToList();
            }

            return model;
        }

        public static Product ToEntity(this ProductViewModel model)
        {
            var entity = Mapper.Map<ProductViewModel, Product>(model);

            return entity;
        }

        public static PhotoViewModel ToModel(this Photo entity)
        {
            var model = Mapper.Map<Photo, PhotoViewModel>(entity);

            return model;
        }

        public static Photo ToEntity(this PhotoViewModel model)
        {
            var entity = Mapper.Map<PhotoViewModel, Photo>(model);

            return entity;
        }


        public static Product_Spec_MappingViewModel ToModel(this Product_Spec_Mapping entity)
        {
            var model = Mapper.Map<Product_Spec_Mapping, Product_Spec_MappingViewModel>(entity);

            model.Product_Title = entity.Product?.Title;
            model.Spec_Title = entity.Spec?.Title;
            model.SpecOption_Title = entity.SpecOption?.Title;

            return model;
        }

        public static Product_Spec_Mapping ToEntity(this Product_Spec_MappingViewModel model)
        {
            var entity = Mapper.Map<Product_Spec_MappingViewModel, Product_Spec_Mapping>(model);

            return entity;
        }

    }
}