namespace AspNetCoreSpa.Domain.Enities.Base
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
