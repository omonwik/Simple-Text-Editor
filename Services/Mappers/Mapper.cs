namespace TextEditor.Services.Mappers
{
    public interface IMapper<T, U>
    {
        T Map(U obj);
        U Map(T obj);
    }
}
