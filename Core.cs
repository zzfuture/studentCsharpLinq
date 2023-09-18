using Newtonsoft.Json;
using System.Globalization;

namespace studentCsharp
{
    public class Core
    {
        public static T OpenJSON<T>(string filepath) // Funcion recursiva
        {
            if (File.Exists(filepath))
        {
            // Leer el JSON desde el archivo y convertirlo a un objeto del tipo T
            string json = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<T>(json);
        }
        else
        {
            List<char> emptyList = new List<char>();
            ExportJSON<List<char>>(emptyList, "JSON/data.json");
            return Core.OpenJSON<T>(filepath); // Una vez se ha creado el archivo recurrimos a la misma funcion
        }
        }
        public static void ExportJSON<T>(T lista,string filepath)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings{Formatting = Formatting.Indented};
            string json = JsonConvert.SerializeObject(lista, settings);
            
            File.WriteAllText(filepath, json);
        }
        public static T ConvertirEntradaNumerica<T>(string mensaje)
        {
            while (true)
            {
                try
                {
                    Console.Write(mensaje);
                    string entrada = Console.ReadLine();
                    return (T)Convert.ChangeType(entrada, typeof(T), CultureInfo.InvariantCulture); // Culture info permite el reconocer correctamnente cuando se ingresa un decimal por string, creo.
                }
                catch (FormatException)
                {
                    Console.WriteLine("La entrada no es un número válido.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("El valor ingresado está fuera del rango válido.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Se produjo un error inesperado: {e.Message}");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}