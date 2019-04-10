using AutoMapper;

namespace JMAInsurance.Web.ConfigurationMapper
{
    public class DataConverter : IDataConverter
    {
        public T Convert<T>(object source)
        {
            return Mapper.Map<T>(source);
        }

        public TDestination Convert<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
    }
}
