using ClinicaMedica.Dominio.Contratos;

namespace ClinicaMedica.Infraestructura.Persistencia;

public class RepositorioEnMemoria<T> : IRepositorio<T> where T : class
{
    protected readonly List<T> _datos = new();

    public virtual void Guardar(T entidad) => _datos.Add(entidad);

    public virtual T? ObtenerPorId(Guid id)
    {
        var propiedadId = typeof(T).GetProperty("Id");
        return _datos.FirstOrDefault(e => (Guid)(propiedadId?.GetValue(e) ?? Guid.Empty) == id);
    }

    public virtual IEnumerable<T> ListarTodos() => _datos.AsReadOnly();
}