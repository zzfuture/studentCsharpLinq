using System.Collections.Generic;
using studentCsharp;
using studentCsharp.Entities;
string rutaJSON = "JSON/data.json";
while (true) {
Console.Clear();
sbyte opcionPrincipal = MisFunciones.MenuPrincipal();
switch (opcionPrincipal)
{
    case 0:
        return;
    case 1:
        Console.Clear(); 
        List<Estudiante> ListaEstudiantes = MisFunciones.RegistrarEstudiante();
        Core.ExportJSON<List<Estudiante>>(ListaEstudiantes, rutaJSON);
        break;
    case 2:
        MisFunciones.ModificarEstudiante();
        break;
}
}