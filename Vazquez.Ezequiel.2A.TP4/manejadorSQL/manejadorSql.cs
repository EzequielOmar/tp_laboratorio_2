using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace manejadorSQL
{
    public class manejadorSql
    {
        #region Atributos
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        private Carrito<Texto> libreria;
        #endregion

        #region Propiedades
        public Carrito<Texto> Libreria
        {
            get 
            { 
                if(this.ObtenerDatos() > 0)
                {
                    return this.libreria;
                }
                else
                {
                    throw new Exception("No hay ningun libro a la venta en nuestra base de datos.");
                }
            }
        }
        #endregion

        #region Constructor
        public manejadorSql()
        {
            this.conexion = new SqlConnection(Properties.Settings.Default.textos);
            this.libreria = new Carrito<Texto>();
        }
        #endregion

        #region Métodos publicos
        /// <summary>
        /// Ejecuta el comando SQL-> "SELECT * FROM textos"
        /// carga los datos en this.libreria (insancia privada de Carrito<Texto>
        /// retorna int de items agregados
        /// </summary>
        /// <returns></returns>
        private int ObtenerDatos()
        {
            int contador = 0;
            try
            {
                this.libreria.Items.Clear();
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM textos";
                this.comando.Connection = this.conexion;
                this.conexion.Open();
                this.lector = this.comando.ExecuteReader();
                while (this.lector.Read())
                {
                    Texto tx = null;
                    switch (this.lector["tipo"])
                    {
                        case "Libro":
                            tx = new Libro();
                            break;
                        case "Revista":
                            tx = new Revista();
                            break;
                        case "Enciclopedia":
                            tx = new Enciclopedia();
                            break;
                    }
                    tx.Codigo = (Int32)this.lector["codigo"];
                    tx.Titulo = this.lector["titulo"].ToString();
                    tx.Genero = this.lector["genero"].ToString();
                    tx.Precio = double.Parse(this.lector["precio"].ToString());
                    tx.Stock = (Int32)this.lector["stock"];
                    this.libreria.Agregar(tx);
                    contador++;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return contador;
        }
        /// <summary>
        /// Agrega una unidad de un tipo Texto a la lista libreria
        /// refleja los datos en la base (modificando o agregando segun corresponda)
        /// </summary>
        /// <param name="tx">instancia de tipo Texto</param>
        /// <returns></returns>
        public bool AgregarBD(Texto tx)
        {
            bool rta = false;
            try
            {
                if(this.libreria.Items.Exists(x => x == tx)){
                    this.libreria.Agregar(tx);
                    if (this.ModificarTexto(this.libreria.Items.Find(x=> x == tx)))
                    {
                        rta = true;
                    }
                }
                else
                {
                    this.libreria.Agregar(tx);
                    if (this.AgregarTexto(this.libreria.Items.Find(x => x == tx)))
                    {
                        rta = true;
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return rta;
        }
        /// <summary>
        /// Sustrae una unidad de un tipo Texto de la lista libreria
        /// refleja los datos en la base (modificando o eliminando segun corresponda)
        /// </summary>
        /// <param name="tx">instancia de tipo Texto</param>
        /// <returns></returns>
        public bool SustraerBD(Texto tx)
        {
            bool rta = false;
            try
            {
                this.libreria.Sustraer(tx);
                if (this.libreria.Items.Exists(x => x == tx))
                {
                    if (this.ModificarTexto(this.libreria.Items.Find(x => x == tx)))
                    {
                        rta = true;
                    }
                }
                else
                {
                    if (this.EliminarTexto(tx))
                    {
                        rta = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return rta;
        }
        /// <summary>
        /// ejecuta el comando SQL-> INSERT INTO textos (titulo,tipo,genero,precio,stock) VALUES(@titulo,@tipo,@genero,@precio,@stock)
        /// la agrega a la base de datos la instancia recibida por parametro
        /// </summary>
        /// <param name="t">instancia de tipo texto</param>
        /// <returns></returns>
        public bool AgregarTexto(Texto t)
        {
            bool rta = true;
            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@titulo", t.Titulo);
                this.comando.Parameters.AddWithValue("@tipo", t.GetType().ToString().Replace("Entidades.", ""));
                this.comando.Parameters.AddWithValue("@genero", t.Genero.ToString());
                this.comando.Parameters.AddWithValue("@precio", t.Precio.ToString().Replace(",", "."));
                this.comando.Parameters.AddWithValue("@stock", t.Stock.ToString());
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "INSERT INTO textos (titulo,tipo,genero,precio,stock) VALUES(@titulo,@tipo,@genero,@precio,@stock)";
                this.comando.Connection = this.conexion;
                this.conexion.Open();
                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return rta;
        }
        /// <summary>
        /// ejecuta el comando SQL-> UPDATE textos SET titulo=@titulo,tipo=@tipo,genero=@genero,precio=@precio,stock=@stock WHERE codigo=@codigo
        /// Recibe el parametro modificado y refleja los datos en la base
        /// </summary>
        /// <param name="t">instancia de tipo Texto</param>
        /// <returns></returns>
        public bool ModificarTexto(Texto t)
        {
            bool rta = true;
            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@codigo", t.Codigo.ToString());
                this.comando.Parameters.AddWithValue("@titulo", t.Titulo);
                this.comando.Parameters.AddWithValue("@tipo", t.GetType().ToString().Replace("Entidades.",""));
                this.comando.Parameters.AddWithValue("@genero", t.Genero.ToString());
                this.comando.Parameters.AddWithValue("@precio", t.Precio.ToString().Replace(",", "."));
                this.comando.Parameters.AddWithValue("@stock", t.Stock.ToString());
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "UPDATE textos SET titulo=@titulo,tipo=@tipo,genero=@genero,precio=@precio,stock=@stock WHERE codigo=@codigo";
                this.comando.Connection = this.conexion;
                this.conexion.Open();
                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return rta;
        }
        /// <summary>
        /// ejecuta el comando SQL-> DELETE FROM textos WHERE codigo=@codigo
        /// Recibe el parametro y lo elimina de la base de datos 
        /// </summary>
        /// <param name="t">instancia de tipo Texto</param>
        /// <returns></returns>
        public bool EliminarTexto(Texto t)
        {
            bool rta = true;
            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@codigo", t.Codigo.ToString());
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "DELETE FROM textos WHERE codigo=@codigo";
                this.comando.Connection = this.conexion;
                this.conexion.Open();
                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return rta;
        }

        #endregion
    }
}
