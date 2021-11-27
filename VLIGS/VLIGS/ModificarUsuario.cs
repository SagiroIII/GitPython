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
    public partial class ModificarUsuario : Form
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


        public ModificarUsuario()
        {
            this.Cerrar = new System.Windows.Forms.Button();
            this.Modificar = new System.Windows.Forms.Button();
            this.txtIde = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.Label();
            this.Buscar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.Link = new System.Windows.Forms.Label();
            this.Plataforma = new System.Windows.Forms.Label();
            this.Sinopsis = new System.Windows.Forms.Label();
            this.Genero = new System.Windows.Forms.Label();
            this.Titulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cerrar
            // 
            this.Cerrar.BackColor = System.Drawing.Color.Teal;
            this.Cerrar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Cerrar.FlatAppearance.BorderSize = 3;
            this.Cerrar.Font = new System.Drawing.Font("Playbill", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cerrar.ForeColor = System.Drawing.Color.Azure;
            this.Cerrar.Location = new System.Drawing.Point(258, 463);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(161, 43);
            this.Cerrar.TabIndex = 51;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = false;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // Modificar
            // 
            this.Modificar.BackColor = System.Drawing.Color.Teal;
            this.Modificar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Modificar.FlatAppearance.BorderSize = 3;
            this.Modificar.Font = new System.Drawing.Font("Playbill", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modificar.ForeColor = System.Drawing.Color.Azure;
            this.Modificar.Location = new System.Drawing.Point(592, 463);
            this.Modificar.Name = "Modificar";
            this.Modificar.Size = new System.Drawing.Size(161, 43);
            this.Modificar.TabIndex = 50;
            this.Modificar.Text = "Modificar";
            this.Modificar.UseVisualStyleBackColor = false;
            this.Modificar.Click += new System.EventHandler(this.Modificar_Click);
            // 
            // txtIde
            // 
            this.txtIde.BackColor = System.Drawing.Color.Thistle;
            this.txtIde.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIde.ForeColor = System.Drawing.Color.Black;
            this.txtIde.Location = new System.Drawing.Point(483, 69);
            this.txtIde.Name = "txtIde";
            this.txtIde.Size = new System.Drawing.Size(157, 31);
            this.txtIde.TabIndex = 49;
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.BackColor = System.Drawing.Color.Transparent;
            this.txtId.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.Color.Cyan;
            this.txtId.Location = new System.Drawing.Point(292, 68);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(165, 26);
            this.txtId.TabIndex = 48;
            this.txtId.Text = "id de usuario: ";
            // 
            // Buscar
            // 
            this.Buscar.BackColor = System.Drawing.Color.Teal;
            this.Buscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Buscar.FlatAppearance.BorderSize = 3;
            this.Buscar.Font = new System.Drawing.Font("Playbill", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscar.ForeColor = System.Drawing.Color.Azure;
            this.Buscar.Location = new System.Drawing.Point(425, 463);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(161, 43);
            this.Buscar.TabIndex = 47;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = false;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.Thistle;
            this.txtNombre.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(483, 199);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(205, 31);
            this.txtNombre.TabIndex = 46;
            // 
            // txtContraseña
            // 
            this.txtContraseña.BackColor = System.Drawing.Color.Thistle;
            this.txtContraseña.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.ForeColor = System.Drawing.Color.Black;
            this.txtContraseña.Location = new System.Drawing.Point(483, 385);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(157, 31);
            this.txtContraseña.TabIndex = 44;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.Thistle;
            this.txtCorreo.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.Color.Black;
            this.txtCorreo.Location = new System.Drawing.Point(483, 318);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(192, 31);
            this.txtCorreo.TabIndex = 43;
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.Thistle;
            this.txtApellido.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.ForeColor = System.Drawing.Color.Black;
            this.txtApellido.Location = new System.Drawing.Point(483, 250);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(169, 31);
            this.txtApellido.TabIndex = 42;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.Thistle;
            this.txtUsuario.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtUsuario.Location = new System.Drawing.Point(483, 146);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(157, 31);
            this.txtUsuario.TabIndex = 41;
            // 
            // Link
            // 
            this.Link.AutoSize = true;
            this.Link.BackColor = System.Drawing.Color.Transparent;
            this.Link.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Link.ForeColor = System.Drawing.Color.Cyan;
            this.Link.Location = new System.Drawing.Point(253, 384);
            this.Link.Name = "Link";
            this.Link.Size = new System.Drawing.Size(137, 26);
            this.Link.TabIndex = 40;
            this.Link.Text = "Contraseña";
            // 
            // Plataforma
            // 
            this.Plataforma.AutoSize = true;
            this.Plataforma.BackColor = System.Drawing.Color.Transparent;
            this.Plataforma.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Plataforma.ForeColor = System.Drawing.Color.Cyan;
            this.Plataforma.Location = new System.Drawing.Point(253, 318);
            this.Plataforma.Name = "Plataforma";
            this.Plataforma.Size = new System.Drawing.Size(104, 26);
            this.Plataforma.TabIndex = 38;
            this.Plataforma.Text = "Correo: ";
            // 
            // Sinopsis
            // 
            this.Sinopsis.AutoSize = true;
            this.Sinopsis.BackColor = System.Drawing.Color.Transparent;
            this.Sinopsis.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sinopsis.ForeColor = System.Drawing.Color.Cyan;
            this.Sinopsis.Location = new System.Drawing.Point(251, 249);
            this.Sinopsis.Name = "Sinopsis";
            this.Sinopsis.Size = new System.Drawing.Size(118, 26);
            this.Sinopsis.TabIndex = 37;
            this.Sinopsis.Text = "Apellido: ";
            // 
            // Genero
            // 
            this.Genero.AutoSize = true;
            this.Genero.BackColor = System.Drawing.Color.Transparent;
            this.Genero.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Genero.ForeColor = System.Drawing.Color.Cyan;
            this.Genero.Location = new System.Drawing.Point(251, 198);
            this.Genero.Name = "Genero";
            this.Genero.Size = new System.Drawing.Size(106, 26);
            this.Genero.TabIndex = 36;
            this.Genero.Text = "NOmbre: ";
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.BackColor = System.Drawing.Color.Transparent;
            this.Titulo.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.ForeColor = System.Drawing.Color.Cyan;
            this.Titulo.Location = new System.Drawing.Point(242, 146);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(215, 26);
            this.Titulo.TabIndex = 35;
            this.Titulo.Text = "Nombre de usuario";
            // 
            // ModificarUsuario
            // 
            this.BackgroundImage = global::VLIGS.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(942, 537);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.Modificar);
            this.Controls.Add(this.txtIde);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.Link);
            this.Controls.Add(this.Plataforma);
            this.Controls.Add(this.Sinopsis);
            this.Controls.Add(this.Genero);
            this.Controls.Add(this.Titulo);
            this.Name = "ModificarUsuario";
            this.Load += new System.EventHandler(this.ModificarUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void Modificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIde.Text);
            String usuario = txtUsuario.Text;
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            String correo = txtCorreo.Text;
            String contraseña = txtContraseña.Text;

            //Instrucción SQ
            Sql = "UPDATE UsuarioAdmin SET IdAdmin='" + id + "',Usuario='" + usuario + "',Nombre='" + nombre + "',Apellido='" + apellido + "',Correo='" + correo + "',Contraseña='" + contraseña + "'WHERE IdAdmin='" + id + "'";
            //Pasamos al objeto comando la instrucción SQL a ejecutar y el objeto Conexion
            Comando = new SqlCommand(Sql, Conexion);

            try
            {
                Comando.ExecuteNonQuery(); //Ejecutamos la instrucción SQL
                MessageBox.Show("Se actualizaron los datos del usuario");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar usuario: " + ex.Message);
            }
            finally
            {
                Conexion.Close();
                this.Close();
            }
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

        private void ModificarUsuario_Load(object sender, EventArgs e)
        {
            Conectar();
            txtUsuario.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtCorreo.Enabled = false;
            txtContraseña.Enabled = false;

        }

        private void InitializeComponent()
        {
        
           
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "ModificarUsuario";
            this.Load += new System.EventHandler(this.ModificarUsuario_Load);
            this.ResumeLayout(false);

        }

    }
}
