// See https://aka.ms/new-console-template for more information
public class DatosArchivos{
    private string Nombre, Formato;
    private int Id;

    public DatosArchivos()
    {
    }

    public DatosArchivos(string nombre, string formato, int id)
    {
        Nombre = nombre;
        Formato = formato;
        Id = id;
    }

    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public string Formato1 { get => Formato; set => Formato = value; }
    public int Id1 { get => Id; set => Id = value; }
}
