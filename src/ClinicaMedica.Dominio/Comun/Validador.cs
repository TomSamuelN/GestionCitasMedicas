namespace ClinicaMedica.Dominio.Comun;

public static class Validador
{
    public static string Requerido(string valor, string nombreCampo)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException($"El campo '{nombreCampo}' es requerido y no puede estar vacío.", nombreCampo);

        return valor.Trim();
    }

    public static DateTime FechaFutura(DateTime fecha, string nombreCampo)
    {
        if (fecha <= DateTime.Now)
            throw new ArgumentException($"El campo '{nombreCampo}' debe corresponder a una fecha y hora futura.", nombreCampo);

        return fecha;
    }
}