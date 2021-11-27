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
    public partial class RegistrarJuego : Form
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
        public RegistrarJuego()
        {
            InitializeComponent();
        }


        private void RegistrarJuego_Load(object sender, EventArgs e)
        {
            Conectar();
        }

        private void CancelarRegistro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            // CARGAR Y GUARDAR LA IMAGEN
            System.IO.MemoryStream ms = new System.IO.MemoryStream();//guardar en memoria la imagen
            pImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] aByte = ms.ToArray();


            //Instrucción SQL
            Sql = "insert into videojuegos(Id,Nombre,Genero,Sinopsis,Plataforma,FechaLanzamiento,Link,Imagen)values(@Id,@Nombre,@Genero,@Sinopsis,@Plataforma,@FechaLanzamiento,@Link,@Imagen)";
            //Pasamos al objeto comando la instrucción SQL a ejecutar y el objeto Conexion
            Comando = new SqlCommand(Sql, Conexion);
            Comando.Parameters.AddWithValue("@Id", txtIde.Text);
            Comando.Parameters.AddWithValue("@Nombre", txtTitulo.Text);
            Comando.Parameters.AddWithValue("@Genero", txtGenero.Text);
            Comando.Parameters.AddWithValue("@Sinopsis",txtSinopsis.Text);
            Comando.Parameters.AddWithValue("@Plataforma",cboPlataforma.Text);
            Comando.Parameters.AddWithValue("@FechaLanzamiento", txtFecha.Text);
            Comando.Parameters.AddWithValue("@Link", txtDescarga.Text);
            Comando.Parameters.AddWithValue("Imagen",aByte);
           

            try //Bloque try catch para captura de exepciones en ejecución
            {
                Comando.ExecuteNonQuery(); //Ejecutamos la instrucción SQL
                MessageBox.Show("Registro insertado");
                pImagen.Image = null;

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

        private void CargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog imagen = new OpenFileDialog(); //Abrir ventana para seleccion archivo
            DialogResult rs = imagen.ShowDialog();
            if (rs == DialogResult.OK)
            {
                pImagen.Image = Image.FromFile(imagen.FileName);
            }
        }
    }
}
