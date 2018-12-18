namespace TestClient.Domain.Enities.Base
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
