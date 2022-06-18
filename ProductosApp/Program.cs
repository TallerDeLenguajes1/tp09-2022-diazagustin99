// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
Console.WriteLine("Hello, World!");
int opcion = 0;
string aux;
var ListaDeProductos = new List<Producto>();
Random rnd = new Random();
int cantidadProductos = rnd.Next(10, 30);
int dia, mes, anio;
DateTime FvAux = new DateTime();
do
{
    System.Console.WriteLine("1- Generar productos aleatoriamente");
    System.Console.WriteLine("2- ver los productos registrados en el archivo JSON");
    System.Console.WriteLine("3- Crear un nuevo producto");
    System.Console.WriteLine("4- Salir");
    aux = System.Console.ReadLine();
    opcion = Convert.ToInt32(aux);
    switch (opcion)
    {
        case 1:
            for (int i = 0; i < cantidadProductos; i++)
            {
                ListaDeProductos.Add(new Producto("Nombre" + i, "Tamanio" + i, (DateTime.Now).AddDays(365 + i * rnd.Next(20, 30)), rnd.Next(1000, 5000)));
            }
            System.Console.WriteLine("Se crearon " + cantidadProductos + " Productos con exito...");
            File.WriteAllText("Productos.Json", JsonSerializer.Serialize(ListaDeProductos));
            System.Console.WriteLine("Todos los productos fueron guardados en el archivo JSON con exito...");
            break;
        case 2:
            string jsonString = File.ReadAllText("Productos.Json");
            ListaDeProductos = JsonSerializer.Deserialize<List<Producto>>(jsonString);
            foreach (var item in ListaDeProductos)
            {
                MostrarProducto(item);
            }
            break;
        case 3:
            string nombre, tamanio, auxF;
            float precio;
            bool bandera = false;
            System.Console.WriteLine("Ingrese el nombre del producto: ");
            nombre = System.Console.ReadLine();
            System.Console.WriteLine("Ingrese el tamaño del producto: ");
            tamanio = System.Console.ReadLine();
            do
            {
                System.Console.WriteLine("Ingrese la fecha de vencimiento del producto (dd/mm/nnnn): ");
                auxF = System.Console.ReadLine();
                if (auxF.Length != 10)
                {
                    bandera = false;
                    System.Console.WriteLine("Ingreso mal el formato de la fecha... respete el formato (dd/mm/nnnn)");
                }
                else
                {
                    bandera = true;
                    var ArrayAux = auxF.Split('/').ToArray();
                    dia = Convert.ToInt32(ArrayAux[0]);
                    mes = Convert.ToInt32(ArrayAux[1]);
                    anio = Convert.ToInt32(ArrayAux[2]);
                    FvAux = new DateTime(anio, mes, dia);
                }
            } while (bandera != true);
            System.Console.WriteLine("Ingrese el precio del producto: ");
            auxF = System.Console.ReadLine();
            precio = Convert.ToInt64(auxF);
            jsonString = File.ReadAllText("Productos.Json");
            ListaDeProductos = JsonSerializer.Deserialize<List<Producto>>(jsonString);
            var auxP = new Producto(nombre, tamanio, FvAux, precio);
            ListaDeProductos.Add(auxP);
            System.Console.WriteLine(("----------------EL PRODUCTO FUE CREADO CON EXITO----------------"));
            MostrarProducto(auxP);
            File.WriteAllText("Productos.Json", JsonSerializer.Serialize(ListaDeProductos));
            System.Console.WriteLine("Todos los productos fueron guardados en el archivo JSON con exito...");
            break;
        default:
            break;
    }
} while (opcion != 4);









static void MostrarProducto(Producto item)
{
    System.Console.WriteLine("---------------PRODUCTO " + item.Nombre + " ---------------");
    System.Console.WriteLine("Precio: " + item.Precio);
    System.Console.WriteLine("Tamaño: " + item.Tamanio);
    System.Console.WriteLine("Fecha de vencimiento: " + item.Fechavencimiento.ToShortDateString());
    System.Console.WriteLine("------------------------------");
}