// See https://aka.ms/new-console-template for more information
public class Producto{
    private string nombre, tamanio;
    private DateTime fechavencimiento;
    private float precio;

    public Producto()
    {
    }

    public Producto(string nombre, string tamanio, DateTime fechavencimiento, float precio)
    {
        this.nombre = nombre;
        this.tamanio = tamanio;
        this.fechavencimiento = fechavencimiento;
        this.precio = precio;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Tamanio { get => tamanio; set => tamanio = value; }
    public DateTime Fechavencimiento { get => fechavencimiento; set => fechavencimiento = value; }
    public float Precio { get => precio; set => precio = value; }
}