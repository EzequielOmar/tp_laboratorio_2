using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum Eclases { Programacion , Laboratorio , Legislación , SPD}

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region "Constructores"
        #endregion

        #region "Propiedades"
        #endregion

        #region "Mètodos Estàticos"
        #endregion

        #region "Mètodos"
        #endregion

        #region "Sobrecargas"
        #endregion
    }
}

/*
 * Atributos Alumnos (lista de inscriptos), Profesores (lista de quienes pueden dar clases) y Jornadas.
• Se accederá a una Jornada específica a través de un indexador.
• Un Universidad será igual a un Alumno si el mismo está inscripto en él.
• Un Universidad será igual a un Profesor si el mismo está dando clases en él.
• Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase,
un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman (todos los que
coincidan en su campo ClaseQueToma).
• Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
• La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. Sino,
lanzará la Excepción SinProfesorException. El distinto retornará el primer Profesor que no pueda dar la clase.
• Si al querer agregar alumnos este ya figura en la lista, lanzar la excepción AlumnoRepetidoException.
• MostrarDatos será privado y de clase. Los datos del Universidad se harán públicos mediante ToString.
• Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
• Leer de clase retornará un Universidad con todos los datos previamente serializados.
 * */
