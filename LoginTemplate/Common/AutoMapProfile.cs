using System.Linq;
using AutoMapper;

namespace LoginTemplate.Common
{
    internal class AutoMapProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.AddGlobalIgnore("Select");

        }

        /*public override string ProfileName
        {
            get { return GetType().Name; }
        }*/
    }
}

public static class AutoMapperExtensions
{
    public static IMappingExpression<TSource, TDestination>
      IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
    {
        var sourceType = typeof(TSource);
        var destinationType = typeof(TDestination);
        var existingMaps = Mapper.GetAllTypeMaps().First(x => x.SourceType.Equals(sourceType) && x.DestinationType.Equals(destinationType));
        foreach (var property in existingMaps.GetUnmappedPropertyNames())
        {
            expression.ForMember(property, opt => opt.Ignore());
        }
        return expression;
    }
}