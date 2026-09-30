using ClinicaMedica.Dominio.Comun;

namespace ClinicaMedica.Dominio.Modelos;

public class Medico
{
    public Guid Id { get; }
    public string NombreCompleto { get; private set; }
    public Especialidad Especialidad { get; private set; }

    public Medico(string nombreCompleto, Especialidad especialidad)
    {
        Id = Guid.NewGuid();
        NombreCompleto = Validador.Requerido(nombreCompleto, nameof(nombreCompleto));
        Especialidad = especialidad ?? throw new ArgumentNullException(nameof(especialidad));
    }

    public void AsignarEspecialidad(Especialidad nuevaEspecialidad)
    {
        Especialidad = nuevaEspecialidad ?? throw new ArgumentNullException(nameof(nuevaEspecialidad));
    }
}