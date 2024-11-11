using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_5._2
{
    public class Alumno
    {
        public int Legajo {  get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNac {  get; set; }
        public string Sexo { get; set; }
        public int TipoDoc { get; set; }
        public int Doc {  get; set; }
        public string Calle {  get; set; }
        public int NroCalle { get; set; }
        public bool Actividad { get; set; }
        public bool Casado { get; set; }
        public bool Hijos { get; set; }
        public int Cantidad { get; set; }
        public int Carrera {  get; set; }

        public Alumno()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            FechaNac = DateTime.Now;
            Sexo = string.Empty;
            TipoDoc = 0;
            Doc = 0;
            Calle = string.Empty;
            NroCalle = 0;
            Actividad = false;
            Casado = false;
            Hijos = false;
            Cantidad = 0;
            Carrera = 0;
        }

        public Alumno(string nombre, string apellido, DateTime fechaNac, string sexo, int tipoDoc, int doc, string calle, int nroCalle, bool actividad, bool casado, bool hijos, int cantidad, int carrera)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaNac = fechaNac;
            Sexo = sexo;
            TipoDoc = tipoDoc;
            Doc = doc;
            Calle = calle;      
            NroCalle = nroCalle;
            Actividad = actividad;
            Casado = casado;
            Hijos = hijos;
            Cantidad = cantidad;
            Carrera = carrera;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} |Apellido: {Apellido} |Fecha Nacimiento: {FechaNac} |Sexo: {Sexo} |Tipo Documento: {TipoDoc} " +
                $"|Documento: {Doc} |Calle: {Calle} |Numero: {NroCalle} |Actividad: {Actividad} |Casado: {Casado} |Hijos: {Hijos} " +
                $"|Cantidad Hijos: {Cantidad} |Carrera: {Carrera}";
        }
    }
}
