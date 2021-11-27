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
    public partial class AgregarUsuario : Form
    {
        //Conexion objeto del tipo SqlConnection para conectarnos fisicamente a la base de datos
        SqlConnection Conexion = new SqlConnection();
        //Comando objeto del tipo SqlCommand para representar instrucciones SQL
        SqlCommand Comando;
        //Variables
        string Sql = " "; //Variable de tipo String para almacenar instrucciones SQL
        string Servidor = @"DESKTOP-2N301FP";
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
                    MessageBox.Show("Error al conectarse con BDD VLIGS" + ex.Message);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la conexión: " + ex.Message);
            }
        }

        private void AgregarUsuario_Load(object sender, EventArgs e)
        {
            Conectar();
        }
        public AgregarUsuario()
        {
            InitializeComponent();
        }

        private void Registrar_Click(object sender, EventArgs e)
        {

            //Instrucción SQL
            Sql = "insert into UsuarioAdmin(IdAdmin,Usuario,Nombre,Apellido,Correo,Contraseña)values(@IdAdmin,@Usuario,@Nombre,@Apellido,@Correo,@Contraseña)";
            //Pasamos al objeto comando la instrucción SQL a ejecutar y el objeto Conexion
            Comando = new SqlCommand(Sql, Conexion);
            Comando.Parameters.AddWithValue("@IdAdmin", txtIde.Text);
            Comando.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
            Comando.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            Comando.Parameters.AddWithValue("@Apellido", txtApellido.Text);
            Comando.Parameters.AddWithValue("@Correo", txtCorreo.Text);
            Comando.Parameters.AddWithValue("@Contraseña", txtContraseña.Text);


            try //Bloque try catch para captura de exepciones en ejecución
            {
                Comando.ExecuteNonQuery(); //Ejecutamos la instrucción SQL
                MessageBox.Show("Usuario creado");
                Conexion.Close();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
            finally
            {
                Conexion.Close();
            }
        }
    }
}
