using AutoMapper;
using Vega.Domain;
using Vega.Resources;

namespace Vega.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Feature, FeatureResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Make, MakeResource>();
        }
    }
}