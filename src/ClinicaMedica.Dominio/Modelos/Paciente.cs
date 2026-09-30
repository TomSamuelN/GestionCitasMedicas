using ClinicaMedica.Dominio.Comun;

namespace ClinicaMedica.Dominio.Modelos;

public class Paciente
{
    public Guid Id { get; }
    public string NombreCompleto { get; private set; }
    public string CorreoElectronico { get; private set; }
    public string Telefono { get; private set; }

    public Paciente(string nombreCompleto, string correoElectronico, string telefono)
    {
        Id = Guid.NewGuid();
        NombreCompleto = Validador.Requerido(nombreCompleto, nameof(nombreCompleto));
        CorreoElectronico = Validador.Requerido(correoElectronico, nameof(correoElectronico));
        Telefono = Validador.Requerido(telefono, nameof(telefono));
    }
}