namespace TestClient.WebApi.Models
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
