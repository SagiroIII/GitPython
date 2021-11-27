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
    public partial class InicioAdmin : Form
   
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
        public InicioAdmin()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Conectar();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conexion.Close();
            this.Close();
        }


        private void registrarJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarJuego nuevojuego = new RegistrarJuego();
            nuevojuego.Show();
        }

        private void editarJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarJuego edicion = new EditarJuego();
            edicion.Show();
        }

        private void eliminarJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarJuego eliminado = new EliminarJuego();
            eliminado.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void catalogoDeJuegosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogo mostrarCatalogo = new Catalogo();
            mostrarCatalogo.Show();
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
             ModificarUsuario nuevaMod = new ModificarUsuario();
              nuevaMod.Show();
      
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarUsuario nuevoUsuario = new AgregarUsuario();
            nuevoUsuario.Show();
        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarUsuario eliminar = new EliminarUsuario();
            eliminar.Show();
        }
    }
}
