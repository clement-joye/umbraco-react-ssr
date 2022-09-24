using AutoMapper;

namespace Umbraco.React.Ssr.Application.Mappings;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
