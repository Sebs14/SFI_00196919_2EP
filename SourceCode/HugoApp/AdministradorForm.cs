using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace HugoApp
{
    public partial class AdministradorForm : Form
    {
        public AdministradorForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if (textBox2.Text.Equals("") ||
                textBox1.Text.Equals("") ||
                comboBox1.Text.Equals(""))
            {
                MessageBox.Show($"¡Hay casillas sin rellenar!",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool encontrado = false;
                foreach (Usuario u in UsuarioDAO.getLista())
                {
                    if (u.username.Equals(textBox2.Text))
                    {
                        encontrado = true;
                    }
                }

                if (!encontrado)
                {
                    try
                    {
                        Conexion.realizarAccion($"INSERT INTO APPUSER(fullname, username, password, usertype) " +
                                                $"VALUES('{textBox1.Text}', '{textBox2.Text}', '{textBox2.Text}', " +
                                                $"{comboBox1.Text})");

                        MessageBox.Show($"Usuario añadido a la base de datos...",
                            "HUGO APP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        frmAdmin_Load(sender, e);

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"OOPS! Eso no debería pasar...");
                    }
                }
                else
                {
                    MessageBox.Show($"Nombre de usuario ya existente...",
                        "HUGO APP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        private void frmAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                var dt = Conexion.realizarConsulta("SELECT * FROM APPUSER");

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            { 
                MessageBox.Show("OOPS! Eso no debería pasar...");  
            }
            
            try
            {
                var dt = Conexion.realizarConsulta("SELECT * FROM BUSINESS");

                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("OOPS! Eso no debería suceder...");
            }

            try
            {
                var dt = Conexion.realizarConsulta("SELECT * FROM PRODUCT");

                dataGridView3.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("OOPS! Eso no debería suceder...");
            }
            
            try
            {
                var dt = Conexion.realizarConsulta("SELECT * FROM APPORDER");

                dataGridView4.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo no anda bien...");
            }
            
            var usu = Conexion.realizarConsulta("SELECT username FROM APPUSER ");
            var usuCombo = new List<string>();

            foreach (DataRow dr in usu.Rows)
            {
                usuCombo.Add(dr[0].ToString());
            }
            
            comboBox2.DataSource = usuCombo;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            if (comboBox2.Text.Equals(""))
            {
                MessageBox.Show("¡Hay casillas sin rellenar!",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    string nonQuery = $"delete from APPUSER "+
                                      $"where username='{comboBox2.Text}';";
                
                
                    Conexion.realizarAccion(nonQuery);
                
                
                
                    MessageBox.Show("Se ha eliminado el usuario...",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);   
                
                    frmAdmin_Load(sender,e);

                }
                catch (Exception exception)
                {
                    MessageBox.Show($"OOPS!",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                }
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
            
            if (textBox5.Text.Equals(""))
            {
                MessageBox.Show("¡Hay casillas sin rellenar!",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    string nonQuery = $"delete from BUSINESS "+
                                      $"where idbusiness='{textBox5.Text}';";
                
                
                    Conexion.realizarAccion(nonQuery);
                
                
                
                    MessageBox.Show("Se ha eliminado el negocio...",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);   
                
                    frmAdmin_Load(sender,e);

                }
                catch (Exception exception)
                {
                    MessageBox.Show($"OOPS!",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
            
            if (textBox3.Text.Equals("") ||
                textBox4.Text.Equals(""))
            {
                MessageBox.Show($"¡Hay casillas sin rellenar!",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                    try
                    {
                        Conexion.realizarAccion($"INSERT INTO BUSINESS(name, description) " +
                                                $"VALUES('{textBox4.Text}', '{textBox3.Text}')");

                        MessageBox.Show($"Se ha añadido el negocio...",
                            "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmAdmin_Load(sender, e);

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"OOPS! Eso no debería de estar pasando...");
                    }
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Equals("") ||
                textBox6.Text.Equals(""))
            {
                MessageBox.Show($"¡Hay casillas sin rellenar!",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                try
                {
                    Conexion.realizarAccion($"INSERT INTO PRODUCT(idbusiness, name) " +
                                            $"VALUES('{textBox7.Text}', '{textBox6.Text}')");

                    MessageBox.Show($"Se ha añadido el producto...",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmAdmin_Load(sender, e);

                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Esto no debería suceder...");
                }
            }   
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Equals(""))
            {
                MessageBox.Show("¡Hay casillas sin rellenar!",
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    string nonQuery = $"delete from PRODUCT "+
                                      $"where idproduct='{textBox8.Text}';";
                
                
                    Conexion.realizarAccion(nonQuery);
                
                
                
                    MessageBox.Show("Se ha eliminado el producto...",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);   
                
                    frmAdmin_Load(sender,e);

                }
                catch (Exception exception)
                {
                    MessageBox.Show($"OOPS!",
                        "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                }
                
            }        
        }
       


        private void frmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}