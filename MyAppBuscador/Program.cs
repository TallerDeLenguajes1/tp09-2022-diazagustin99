// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
var ListaDeArchivos = new List<DatosArchivos>();
var ListaDeArchivosJson = new List<string>();
int aux = 0;
int opc = 0;
Console.WriteLine("Hello, World!");
string DirecArchivo = @"C:\Users\Alumno\Desktop\tp9\tp09-2022-diazagustin99\MyAppBuscador\index.json";
do
{
    System.Console.WriteLine("----------MENU----------");
    System.Console.WriteLine("1-Ver contenido del archivo JSON");
    System.Console.WriteLine("2- Buscar y alistar los archivos de un directorio");
    System.Console.WriteLine("3-Salir");
    string auxS = Console.ReadLine();
    opc = Convert.ToInt32(auxS);
    switch (opc)
    {
        case 1:
            string jsonString = File.ReadAllText(DirecArchivo);
            System.Console.WriteLine("-Mostrar el string jsonString-");
            System.Console.WriteLine(jsonString);
            System.Console.WriteLine("-Mostrar la lista de Objetos-");
            ListaDeArchivos = JsonSerializer.Deserialize<List<DatosArchivos>>(jsonString);
             foreach (var item in ListaDeArchivos)
             {
                System.Console.WriteLine("Nombre del archivo: " + item.Nombre1 + " Formato: " + item.Formato1 + " Orden en la lista: " + item.Id1);
             }
            break;
        case 2:
            System.Console.WriteLine("Ingrese el path que desea enumerar: ");
            string path = Console.ReadLine();
            if (Directory.Exists(path))
            {
                var Archivos = Directory.GetFiles(path);

                for (int i = 0; i < Archivos.Count(); i++)
                {
                    ListaDeArchivos.Add(new DatosArchivos(Path.GetFileNameWithoutExtension(Archivos[i]), Path.GetExtension(Archivos[i]), i));
                }

                File.WriteAllText(DirecArchivo, JsonSerializer.Serialize(ListaDeArchivos));
            }
            else
            {
                System.Console.WriteLine("La ruta especificada no existe.");
            }
            break;
        default:
            break;
    }
} while (opc != 3);



