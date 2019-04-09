namespace JMAInsurance.Entity
{
    public interface IAuditable { }
    public interface IAuditable<T> : IAuditable
    {
        T ReferenceId { get; set; }
    }
}
