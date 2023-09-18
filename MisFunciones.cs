using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using studentCsharp;
using studentCsharp.Entities;
using System.Globalization;
namespace studentCsharp
{
    public class MisFunciones
    {
        public static sbyte MenuPrincipal(){
            Console.Clear();
            Console.WriteLine("MENU PRINCIPAL");
            Console.WriteLine("1. REGISTRAR ESTUDIANTES");
            Console.WriteLine("2. MODIFICAR ESTUDIANTE");
            Console.WriteLine("3. AGREGAR NOTAS");
            Console.WriteLine("4. MODIFICAR NOTAS");
            Console.WriteLine("5. MOSTRAR DEFINITIVAS");
            Console.WriteLine("0. SALIR");
            Console.Write("Opcion: ");
            string[] opciones = {"1","2","3","4","5"};
            string opcionInput = Console.ReadLine();
            return opciones.Contains(opcionInput) ? sbyte.Parse(opcionInput) : (sbyte) -1;
        }
        public static List<Estudiante> RegistrarEstudiante()
        {
            bool ciclo = true;
            string rutaJSON = "JSON/data.json";
            List<Estudiante> ListaEstudiantes = Core.OpenJSON<List<Estudiante>>(rutaJSON);
            while (ciclo){
                Console.Clear();
                Console.WriteLine("REGISTRAR ESTUDIANTE");
                Random rnd = new Random();
                
                Estudiante estudiante = new Estudiante();
                // Codigo
                estudiante.Codigo = Convert.ToString(rnd.Next(10000, 99999));
                // Nombre
                Console.Write("Ingrese el nombre del estudiante: ");
                estudiante.Nombre = Console.ReadLine();

                // Email
                Console.Write("Ingrese el email del estudiante: ");
                estudiante.Email = Console.ReadLine();

                // Edad
                estudiante.Edad = Core.ConvertirEntradaNumerica<byte>("Ingrese la edad del estudiante: ");

                // Direccion
                Console.Write("Ingrese la direccion del estudiante: ");
                estudiante.Direccion = Console.ReadLine();

                // Añadir a la lista
                ListaEstudiantes.Add(estudiante);
                Console.WriteLine("Presione espacio para continuar registrando estudiantes o cualquier otra tecla para salr del registro");
                var key = Console.ReadKey().Key.ToString();
                Console.Clear();
                ciclo =  key.Equals("Spacebar") ? true : false;
            }
            return ListaEstudiantes;
        }
        
        public static List<Estudiante> ModificarEstudiante(){
            bool ciclo = true;
            string rutaJSON = "JSON/data.json";
            List<Estudiante> ListaEstudiantes = Core.OpenJSON<List<Estudiante>>(rutaJSON);
            while (ciclo){
                Console.Clear();
                Console.WriteLine("MODIFICAR ESTUDIANTE");
                Console.WriteLine("{0,17} {1,-40} {2,10} {3,10} {4,10}", "Codigo Estudiante", "Nombre", "Email", "Edad", "Direccion");
                for (int i = 0; i < ListaEstudiantes.Count; i++)
                {
                    Console.WriteLine("{0,-17} {1,-40} {2,10} {3,10} {4,-10}", ListaEstudiantes[i].Codigo, ListaEstudiantes[i].Nombre, ListaEstudiantes[i].Email, ListaEstudiantes[i].Edad, ListaEstudiantes[i].Direccion);
                }
                Console.Write("Codigo de estudiante: ");
                string codigo = Console.ReadLine();
                Console.Clear();
                Estudiante EstudianteElegido = ListaEstudiantes.FirstOrDefault(estudiante => estudiante.Codigo.Equals(codigo));
                Console.WriteLine(EstudianteElegido.Codigo);
                Console.WriteLine($"1. Nombre: {EstudianteElegido.Nombre}");
                Console.WriteLine($"2. Email: {EstudianteElegido.Email}");
                Console.WriteLine($"3. Edad: {EstudianteElegido.Edad}");
                Console.WriteLine($"4. Direccion: {EstudianteElegido.Direccion}");
                Console.Write($"Dato a cambiar (numero): ");
                string[] opcionesSub = {"1","2","3","4"};
                string[] opcionesString = {"Nombre","Email","Edad","Direccion"};
                string opcionInputSub = Console.ReadLine();
                sbyte opcionVerfied = opcionesSub.Contains(opcionInputSub) ? sbyte.Parse(opcionInputSub) : (sbyte) -1;
                Console.Write($"Cambiar {opcionesString[opcionVerfied - 1]} a: ");
                string datoModificado = Console.ReadLine();
                // EstudianteElegido.
                Estudiante estudianteElegido = ListaEstudiantes[ListaEstudiantes.IndexOf(EstudianteElegido)];
                
                switch(opcionVerfied){
                    case 1:
                        estudianteElegido.Nombre = datoModificado;
                        break;
                    case 2:
                        estudianteElegido.Email = datoModificado;
                        break;
                    case 3:
                        estudianteElegido.Edad = byte.Parse(datoModificado);
                        break;
                    case 4:
                        estudianteElegido.Direccion = datoModificado;
                        break;
                }
                ListaEstudiantes[ListaEstudiantes.IndexOf(EstudianteElegido)] = estudianteElegido;
                // Console.Clear();

                Console.ReadKey();
                ciclo = false;
                
                // Random rnd = new Random();
                
                // Estudiante estudiante = new Estudiante();
                // // Codigo
                // estudiante.Codigo = Convert.ToString(rnd.Next(10000, 99999));
                // // Nombre
                // Console.Write("Ingrese el nombre del estudiante: ");
                // estudiante.Nombre = Console.ReadLine();

                // // Email
                // Console.Write("Ingrese el email del estudiante: ");
                // estudiante.Email = Console.ReadLine();

                // // Edad
                // estudiante.Edad = Core.ConvertirEntradaNumerica<byte>("Ingrese la edad del estudiante: ");

                // // Direccion
                // Console.Write("Ingrese la direccion del estudiante: ");
                // estudiante.Direccion = Console.ReadLine();

                // // Añadir a la lista
                // ListaEstudiantes.Add(estudiante);
                // Console.WriteLine("Presione espacio para continuar registrando estudiantes o cualquier otra tecla para salr del registro");
                // var key = Console.ReadKey().Key.ToString();
                // Console.Clear();
                // ciclo =  key.Equals("Spacebar") ? true : false;
            }
            return ListaEstudiantes;
        }
    }
}