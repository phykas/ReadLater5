using AutoMapper;
using ReadLater.Mapper;
using System.Collections.Generic;

namespace ReadLater.Automapper
{
    public class AutomapperService : IMapperService
    {
        private readonly IMapper _mapper;

        public AutomapperService(IEnumerable<Profile> profiles)
        {
            _mapper = new MapperConfiguration(expression =>
            {
                expression.AddProfiles(profiles);
            }).CreateMapper();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map<TSource, TDestination>(source, destination);
        }
    }
}
