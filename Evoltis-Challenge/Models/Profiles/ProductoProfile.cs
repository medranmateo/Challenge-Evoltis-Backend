using AutoMapper;
using Evoltis_Challenge.Models.DataObjects;

namespace Evoltis_Challenge.Models.Profiles
{
    public class ProductoProfile: Profile
    {
        public ProductoProfile() 
        {
            CreateMap<Producto, ProductoDTO>();
            CreateMap<ProductoDTO, Producto>();

        }

    }
}
