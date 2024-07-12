using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.Pets.Commands.CreatePet;
using CleanArchitecture.Core.Features.Pets.Commands.CreatePetCategory;
using CleanArchitecture.Core.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Core.Features.Products.Queries.GetAllProducts;

using CleanArchitecture.Core.Features.CaretakerInfos.Queries;
using CleanArchitecture.Core.Features.CaretakerInfos.Queries.GetAllCaretakerInfos;
using CleanArchitecture.Core.Features.PetOwnerInfos.Queries.GetAllPetOwnerInfos;
using CleanArchitecture.Core.Features.PetOwnerInfos.Queries;
using CleanArchitecture.Core.Features.PetAdoptions.Queries.GetAllPetAdoptions;
using CleanArchitecture.Core.Features.PetAdoptions.Commands.CreatePetAdoption;
using CleanArchitecture.Core.Features.PetAdoptions.Queries;

namespace CleanArchitecture.Core.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();

            CreateMap<CreatePetCommand, Pet>();
            CreateMap<CreatePetCategoryCommand, PetCategory>();



            CreateMap<CaretakerInfo, GetAllCaretakerInfosViewModel>().ReverseMap();
            CreateMap<CreateCaretakerInfoCommand, CaretakerInfo>();
            CreateMap<GetAllCaretakerInfosQuery, GetAllCaretakerInfosParameter>();



            CreateMap<PetOwnerInfo, GetAllPetOwnerInfosViewModel>().ReverseMap();
            CreateMap<CreatePetOwnerInfoCommand, PetOwnerInfo>();
            CreateMap<GetAllPetOwnerInfosQuery, GetAllPetOwnerInfosParameter>();

            CreateMap<PetAdoption, GetAllPetAdoptionsViewModel>().ReverseMap();
            CreateMap<CreatePetAdoptionCommand, PetAdoption>();
            CreateMap<GetAllPetAdoptionsQuery, GetAllPetAdoptionsParameter>();











        }
    }
}
