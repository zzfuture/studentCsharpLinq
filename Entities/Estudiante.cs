using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace studentCsharp.Entities
{
    public class Estudiante
    {
        private string codigo;
        private string nombre;
        private string email;
        private byte edad;
        private string direccion;
        public Estudiante(){
        
        }
        public Estudiante(string codigo, string nombre, string email, byte edad, string direccion)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Email = email;
            this.Edad = edad;
            this.Direccion = direccion;
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public byte Edad { get => edad; set => edad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
    }
}