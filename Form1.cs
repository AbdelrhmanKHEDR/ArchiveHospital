using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace __Hospital__
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1K3D7U7\\ABDELRHMAN;Initial Catalog=Hospital;Integrated Security=True");

            try
            {
                if (txtidsign.Text == "" && txtpasssign.Text == "")
                {
                    MessageBox.Show("Please enter ID and Password");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[employeeInfo] WHERE Emp_ID=@Emp_ID and Emp_pass=@Emp_pass", conn);
                    cmd.Parameters.AddWithValue("@Emp_ID", txtidsign.Text);
                    cmd.Parameters.AddWithValue("@Emp_pass", txtpasssign.Text);

                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();

                    int count = ds.Tables[0].Rows.Count;

                    if (count == 1)
                    {
                        Patient P = new Patient();
                        this.Hide();
                        P.Show();

                    }
                    else
                    {
                        MessageBox.Show("Invalid id and password");

                    }
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp SI = new SignUp();
            SI.Show();
            Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtpasssign.UseSystemPasswordChar = false;
            }
            else
            {
                txtpasssign.UseSystemPasswordChar = true;
            }
        }
    }
}
