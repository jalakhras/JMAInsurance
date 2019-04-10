namespace JMAInsurance.Web.ConfigurationMapper
{
    public interface IDataConverter
    {
        T Convert<T>(object source);

        TDestination Convert<TSource, TDestination>(TSource source);
    }

}
