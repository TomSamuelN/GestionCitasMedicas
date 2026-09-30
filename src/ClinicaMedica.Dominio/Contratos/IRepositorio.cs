namespace ClinicaMedica.Dominio.Contratos;

public interface IRepositorio<T>
{
    void Guardar(T entidad);
    T? ObtenerPorId(Guid id);
    IEnumerable<T> ListarTodos();
}