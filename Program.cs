using System.Collections.Generic;
using studentCsharp;
using studentCsharp.Entities;
string rutaJSON = "JSON/data.json";
List<Estudiante> ListaEstudiantes;
while (true) {
Console.Clear();
sbyte opcionPrincipal = MisFunciones.MenuPrincipal();
switch (opcionPrincipal)
{
    case 0:
        return;
    case 1:
        Console.Clear(); 
        ListaEstudiantes = MisFunciones.RegistrarEstudiante();
        Core.ExportJSON<List<Estudiante>>(ListaEstudiantes, rutaJSON);
        break;
    case 2:
        ListaEstudiantes = MisFunciones.ModificarEstudiante();
        Core.ExportJSON<List<Estudiante>>(ListaEstudiantes, rutaJSON);
        break;
    case 3:
        
        break;
}
}