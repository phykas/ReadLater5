using ReadLater.Mapper;

namespace ReadLater.Bookmarks.Application
{
    public interface IBookmarksMapperService : IMapperService
    {
    }

    public class BookmarksMapper : IBookmarksMapperService
    {
        private readonly IMapperService _mapperService;

        public BookmarksMapper(IMapperService mapperService)
        {
            _mapperService = mapperService;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapperService.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapperService.Map<TSource, TDestination>(source, destination);
        }
    }
}
