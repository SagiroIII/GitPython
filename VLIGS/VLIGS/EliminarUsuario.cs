using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace VLIGS
{
    public partial class EliminarUsuario : Form
    {
        //Instancias
        //Conexion objeto del tipo SqlConnection para conectarnos fisicamente a la base de datos
        SqlConnection Conexion = new SqlConnection();
        //Comando objeto del tipo SqlCommand para representar instrucciones SQL
        SqlCommand Comando;
        //Adaptador objeto del tipo SqlDataAdapter para para intercambiar datos entre una
        // fuente de datos (en este caso Sql Server) y un almacen de datos (DataSet, DataTable,DataReader)
        SqlDataAdapter Adaptador = null;
        //Tabla objeto del tipo DataTable representa una colección de registros en memeria del cliente
        DataTable Tabla = new DataTable();
        //Variables
        string Sql = " "; //Variable de tipo String para almacenar instrucciones SQL
        //Variable de tipo String para almacenar el nombre de la Instancia SQLServer nombre del servidor
        string Servidor = @"DESKTOP-2N301FP";
        //Variable de tipo String para almacenar el nombre de la base de datos
        string Base_Datos = "VLIGS";

        //Metodo Conectar *********************************************************************
        void Conectar()
        {
            try
            {
                //Para establecer la conexion con el servidor debemos usar el objeto Conexion
                //especificando a traves de su propiedad ConnectionString el nombre del servidor, la bases de datos
                //y el tiempo de seguridad
                Conexion.ConnectionString = "Data Source=" + Servidor + ";" +
                "Initial Catalog=" + Base_Datos + ";" +
                "Integrated security=true";
                try
                //Bloque try catch para captura de exepciones en ejecución
                {
                    Conexion.Open(); //Abrimos la conexión

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al establecer la conexion con la base de datos " + ex.Message);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la conexión: " + ex.Message);
            }
        }
        public EliminarUsuario()
        {
            InitializeComponent();
        }

        private void CancelarRegistro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            {
                int codigo = Int32.Parse(txtIde.Text);
                SqlDataReader reader = null;

                Sql = "SELECT * FROM UsuarioAdmin WHERE IdAdmin LIKE '" + codigo + "'";
                try
                {
                    Comando = new SqlCommand(Sql, Conexion);
                    reader = Comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // HABILITAR CAMPOS
                            txtUsuario.Enabled = true;
                            txtNombre.Enabled = true;
                            txtApellido.Enabled = true;
                            txtCorreo.Enabled = true;
                            txtContraseña.Enabled = true;


                            // ASIGNAR TEXTO A LOS TXTBOX
                            txtUsuario.Text = reader.GetString(1);
                            txtNombre.Text = reader.GetString(2);
                            txtApellido.Text = reader.GetString(3);
                            txtCorreo.Text = reader.GetString(4);
                            txtContraseña.Text = reader.GetString(5);

                        }
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ese usuario no existe");
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al buscar usuario" + ex.Message);
                }

            }
        }

        private void EliminarUsuariocs_Load(object sender, EventArgs e)
        {
            Conectar();
            txtUsuario.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtCorreo.Enabled = false;
            txtContraseña.Enabled = false;

        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIde.Text);


            //Instrucción SQL
            Sql = "DELETE  FROM UsuarioAdmin WHERE IdAdmin='" + id + "'";
            //Pasamos al objeto comando la instrucción SQL a ejecutar y el objeto Conexion
            Comando = new SqlCommand(Sql, Conexion);

            try
            {
                Comando.ExecuteNonQuery(); //Ejecutamos la instrucción SQL
                MessageBox.Show("Usuario eliminado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario " + ex.Message);
            }
            finally
            {
                Conexion.Close();
                this.Close();
            }
        }
    }
}
