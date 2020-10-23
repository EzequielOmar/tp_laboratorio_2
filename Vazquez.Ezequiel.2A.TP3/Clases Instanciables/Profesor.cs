﻿using Clases_Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.Eclases> clasesDelDia;
        private static Random random;

        #region "Constructor"
        static Profesor()
        {
            random = new Random();
        }
        public Profesor()
        {
            //si se llama este contructor automaticamente llama primero a Universitario(), y este a Persona()
            //inicializar atributos?
            //pasa al otro constructor inicializando por defecto?
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            _randomClases();
        }
        #endregion

        #region "Mètodos"
        private void _randomClases()
        {
            for(int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.Eclases)random.Next(0,Enum.GetValues(typeof(Universidad.Eclases)).Length));
            }
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASES DEL DÍA:\n");
            foreach(Universidad.Eclases clase in this.clasesDelDia)
            {
                sb.AppendFormat("{0}\n", clase);
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region "Sobrecargas"
        public static bool operator ==(Profesor i, Universidad.Eclases clase)
        {
            bool respuesta = false;
            foreach(Universidad.Eclases claseAux in i.clasesDelDia)
            {
                if (claseAux.Equals(clase))
                {
                    respuesta = true;
                }
            }
            return respuesta;
        }
        public static bool operator !=(Profesor i, Universidad.Eclases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}

/*
• Se inicializará a Random sólo en un constructor.
• En el constructor de instancia se inicializará ClasesDelDia y se asignarán dos clases al azar al Profesor mediante el método randomClases. 
Las dos clases pueden o no ser la misma.
 */
