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
    public partial class InicioSesion : Form
    {
        //Instancias
        //Conexion objeto del tipo SqlConnection para conectarnos fisicamente a la base de datos
        SqlConnection Conexion = new SqlConnection();
        //Comando objeto del tipo SqlCommand para representar instrucciones SQL
        SqlCommand Comando;
        //Adaptador objeto del tipo SqlDataAdapter para para intercambiar datos entre una
        // fuente de datos (en este caso Sql Server) y un almacen de datos (DataSet, DataTable,DataReader)
        //Tabla objeto del tipo DataTable representa una colección de registros en memeria del cliente
        DataTable Tabla = new DataTable();
        //Variables
        string Sql = " "; //Variable de tipo String para almacenar instrucciones SQL
        //Variable de tipo String para almacenar el nombre de la Instancia SQLServer nombre del servidor
        string Servidor = @"DESKTOP-2N301FP";
        //Variable de tipo String para almacenar el nombre de la base de datos
        string Base_Datos = "VLIGS";

        public void Conectar()
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
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conectar();

        }

        public void IniciarSesion_Click(object sender, EventArgs e)
        {
            String user = txtUsuario.Text;
            String contra = txtContraseña.Text;

            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Ingresa tu usuario.");
            }
            else
            {
                if (txtContraseña.Text == "")
                {
                    MessageBox.Show("Ingresa tu contraseña.");
                }
                else
                {
                    Sql = "SELECT Usuario, Contraseña FROM UsuarioAdmin WHERE Usuario='" + user + "'AND Contraseña='" + contra + "'";

                    Comando = new SqlCommand(Sql, Conexion);
                   SqlDataReader reader = Comando.ExecuteReader();
                    if (reader.Read()){
                        MessageBox.Show("Inicio correcto");
                        InicioAdmin sesion = new InicioAdmin();
                        sesion.Show();

                    }
                    else
                    {
                        MessageBox.Show("Datos incorrectos, intenta de nuevo.");
                        this.Close();
                    }


                }
            }

        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
