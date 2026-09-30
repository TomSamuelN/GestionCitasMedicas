using ClinicaMedica.Dominio.Comun;

namespace ClinicaMedica.Dominio.Modelos;

public class Especialidad
{
    public Guid Id { get; }
    public string Nombre { get; private set; }

    public Especialidad(string nombre)
    {
        Id = Guid.NewGuid();
        Nombre = Validador.Requerido(nombre, nameof(nombre));
    }
}