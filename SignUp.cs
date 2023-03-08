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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1K3D7U7\\ABDELRHMAN;Initial Catalog=Hospital;Integrated Security=True");

            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[employeeInfo]
           ([Emp_ID]
           ,[Emp_pass])
     VALUES
         ('" + txtid.Text + "','" + txtpass.Text + "')", conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(".تم ادخال بيانات الموظف");
            txtid.Text = "";
            txtpass.Text = "";
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            Visible = false;
        }
    }
}
