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

namespace AT4_EX1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"data source =DESKTOP-7TC9CTO\SQLEXPRESS;database=VolAvion;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader read;

        private void button1_Click(object sender, EventArgs e)
        {
            cmd.Connection = con;
            cmd.CommandText = "SELECT Av, Marque, TypeAvion FROM avion";
            try
            {
                dataGridView1.Rows.Clear();
                con.Open();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    dataGridView1.Rows.Add(read["Av"], read["Marque"], read["TypeAvion"]);
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show("Erreur levée :" +exp.Message);
            }
            finally
            {
                read.Close();
                con.Close();
            }
        }
    }
}
