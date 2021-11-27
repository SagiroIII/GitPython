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
    public partial class EliminarJuego : Form
    {
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
        void Conectar()
        {
            try
            {

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
                    MessageBox.Show("Error al conectar con la base de datos VLIGS " + ex.Message);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la conexión: " + ex.Message);
            }
        }
        public EliminarJuego()
        {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            int codigo = Int32.Parse(txtIde.Text);
            SqlDataReader reader = null;

            Sql = "SELECT * FROM videojuegos WHERE Id LIKE '" + codigo + "'";
            try
            {
                Comando = new SqlCommand(Sql, Conexion);
                reader = Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // HABILITAR CAMPOS
                        txtTitulo.Enabled = true;
                        txtGenero.Enabled = true;
                        txtSinopsis.Enabled = true;
                        txtFecha.Enabled = true;
                        txtDescarga.Enabled = true;
                        cboPlataforma.Enabled = true;

                        // ASIGNAR TEXTO A LOS TXTBOX
                        txtTitulo.Text = reader.GetString(1);
                        txtGenero.Text = reader.GetString(2);
                        txtSinopsis.Text = reader.GetString(3);
                        cboPlataforma.Text = reader.GetString(4);
                        txtFecha.Text = reader.GetString(5);
                        txtDescarga.Text = reader.GetString(6);

                        System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])reader["Imagen"]);
                        Bitmap bm = new Bitmap(ms);
                        pImagen.Image = bm;

                    }
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("El id que ingreste no corresponde a un juego existente.");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al buscar." + ex.Message);
            }
        }

        private void EliminarJuego_Load(object sender, EventArgs e)
        {
            Conectar();
            txtTitulo.Enabled = false;
            txtGenero.Enabled = false;
            txtSinopsis.Enabled = false;
            txtFecha.Enabled = false;
            txtDescarga.Enabled = false;
            cboPlataforma.Enabled = false;
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIde.Text);


            //Instrucción SQL
            Sql = "DELETE  FROM videojuegos WHERE Id='" + id + "'";
            //Pasamos al objeto comando la instrucción SQL a ejecutar y el objeto Conexion
            Comando = new SqlCommand(Sql, Conexion);

            try
            {
                Comando.ExecuteNonQuery(); //Ejecutamos la instrucción SQL
                MessageBox.Show("Se elimino correctamente el juego.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar juego: " + ex.Message);
            }
            finally
            {
                Conexion.Close();
                this.Close();
            }
        }
    }
}
