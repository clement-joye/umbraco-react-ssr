using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Umbraco.React.Ssr.Application.Models;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace Umbraco.React.Ssr.Application.Mappings;

public static class MappingExtensions
{
    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration) where TDestination : class
        => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
}
