namespace Application.Infastructure.Interfaces.Base
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
    }
}
