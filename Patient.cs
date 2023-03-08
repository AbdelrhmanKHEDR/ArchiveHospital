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
using System.Diagnostics;

namespace __Hospital__
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1K3D7U7\\ABDELRHMAN;Initial Catalog=Hospital;Integrated Security=True");

            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Patient_info]
           ([P_no]
           ,[P_name]
           ,[P_add]
           ,[P_gender]
           ,[P_BD]
           ,[P_age]
           ,[P_mobile]
           ,[P_telno]
           ,[P_religion]
           ,[P_file]
           ,[P_standno]
           ,[P_raf])
     VALUES
         ('" + txtpatientno.Text + "','" + txtpatientname.Text + "','" + txtpatientadd.Text + "','" + cmbgender.Text + "','" + txtpatientBD.Text + "','" + txtpatientage.Text + "','" + txtpatientmob.Text + "','" + txtpatienttelno.Text + "','" + txtpatientrel.Text + "','" + txtpatientfileno.Text + "','" + txtpatientstandno.Text + "','" + txtpatientrafno.Text + "')", conn);
            //           ('"+txtpatientno.Text+"','"+txtpatientname.Text+"','"+txtpatientadd.Text+"','"+cmbgender.SelectedItem.ToString()+"','"+txtpatientBD.Text+"','"+txtpatientage.Text+"','"+txtpatientmob.Text+"','"+txtpatienttelno.Text+"','"+txtpatientrel.Text+"','"+txtpatientfileno.Text+"','"+txtpatientstandno.Text+"','"+txtpatientrafno.Text+"')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            display_data();
            MessageBox.Show(".تم ادخال بيانات المريض");
            txtpatientno.Text = "";
            txtpatientname.Text = "";
            txtpatientadd.Text = "";
            cmbgender.Text = "";
            txtpatientBD.Text = "";
            txtpatientage.Text = "";
            txtpatientmob.Text = "";
            txtpatienttelno.Text = "";
            txtpatientrel.Text = "";
            txtpatientfileno.Text = "";
            txtpatientstandno.Text = "";
            txtpatientrafno.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1K3D7U7\\ABDELRHMAN;Initial Catalog=Hospital;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Patient_info] set P_name=@P_name, P_add=@P_add, P_gender=@P_gender, P_BD=@P_BD, P_age=@P_age, P_mobile=@P_mobile, P_telno=@P_telno, P_religion=@P_religion, P_file=@P_file, P_standno=@P_standno, P_raf=@P_raf WHERE P_no=@P_no", conn);

            cmd.Parameters.AddWithValue("@P_no", int.Parse(txtpatientno.Text));
            cmd.Parameters.AddWithValue("@P_name", txtpatientname.Text);
            cmd.Parameters.AddWithValue("@P_add", txtpatientadd.Text);
            cmd.Parameters.AddWithValue("@P_gender", cmbgender.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@P_BD", txtpatientBD.Text);
            cmd.Parameters.AddWithValue("@P_age", txtpatientage.Text);
            cmd.Parameters.AddWithValue("@P_mobile", txtpatientmob.Text);
            cmd.Parameters.AddWithValue("@P_telno", txtpatienttelno.Text);
            cmd.Parameters.AddWithValue("@P_religion", txtpatientrel.Text);
            cmd.Parameters.AddWithValue("@P_file", txtpatientfileno.Text);
            cmd.Parameters.AddWithValue("@P_standno", txtpatientstandno.Text);
            cmd.Parameters.AddWithValue("@P_raf", txtpatientrafno.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            display_data();
            MessageBox.Show(".تم تعديل بيانات المريض");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1K3D7U7\\ABDELRHMAN;Initial Catalog=Hospital;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE [dbo].[Patient_info] WHERE P_no=@P_no", conn);
            cmd.Parameters.AddWithValue("@P_no", int.Parse(txtpatientno.Text));
            cmd.ExecuteNonQuery();
            display_data();
            MessageBox.Show(".تم حذف بيانات المريض");
            txtpatientno.Text = "";
            txtpatientname.Text = "";
            txtpatientadd.Text = "";
            cmbgender.Text = "";
            txtpatientBD.Text = "";
            txtpatientage.Text = "";
            txtpatientmob.Text = "";
            txtpatienttelno.Text = "";
            txtpatientrel.Text = "";
            txtpatientfileno.Text = "";
            txtpatientstandno.Text = "";
            txtpatientrafno.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            patientinfoBindingSource.AddNew();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1K3D7U7\\ABDELRHMAN;Initial Catalog=Hospital;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Patient_info]", conn);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            conn.Close();


            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1K3D7U7\\ABDELRHMAN;Initial Catalog=Hospital;Integrated Security=True");
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Patient_info]",conn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1K3D7U7\\ABDELRHMAN;Initial Catalog=Hospital;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [dbo].[Patient_info] WHERE P_no='" + txtpatientno.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            // txtpatientno.Text = "";
        }

        public void display_data()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1K3D7U7\\ABDELRHMAN;Initial Catalog=Hospital;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [dbo].[Patient_info]";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            string x, y, z;
            string strcmd1, strcmd2;
            x = txtpatientstandno.Text;
            y = txtpatientrafno.Text;

            if (x != "-1" || y != "-1")
            {


                string A = x.Substring(0, 1);
                string B = x.Substring(1, 1);
                string C = y.Substring(0, 1);
                string D = y.Substring(1, 1);


                //Console.WriteLine("X" + first1 + "x" + first2 + "Y" + second1 + "y" + second2 + "e");
                strcmd1 = "/c mode.com com3: 2400,n,8,1";
                z = "/c echo X" + A + "x" + B + "Y" + C + "y" + D + "e > COM3";
                System.Diagnostics.Process.Start("cmd.exe", strcmd1);
                System.Diagnostics.Process.Start("cmd.exe", z);

                //"/c echo X1x4Y0y5e > COM3 ";

            }
            else
            {
                z = "/c echo X0x0Y0y0e > COM3 ";
                System.Diagnostics.Process.Start("cmd.exe", z);
                MessageBox.Show("!!تم ادخال ارقام خاطئة");
            }


        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1K3D7U7\\ABDELRHMAN;Initial Catalog=Hospital;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Patient_info] WHERE P_name='" + txtpatientname.Text + "'", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Patient_info] WHERE P_no='" + txtpatientno.Text + "',P_name='" + txtpatientname.Text + "',P_add='" + txtpatientadd.Text + "',P_gender='" + cmbgender.SelectedItem.ToString() + "',P_BD='" + txtpatientBD.Text + "',P_age='" + txtpatientage.Text + "',P_mob='" + txtpatientmob.Text + "',P_telno='" + txtpatienttelno.Text + "',P_rel='" + txtpatientrel.Text + "',P_file='" + txtpatientfileno.Text + "',P_standno='" + txtpatientstandno.Text + "',P_raf='" + txtpatientrafno.Text + "' ", conn);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void Patient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet.Patient_info' table. You can move, or remove it, as needed.
            this.patient_infoTableAdapter.Fill(this.hospitalDataSet.Patient_info);
            // TODO: This line of code loads data into the 'hospitalDataSet.employeeInfo' table. You can move, or remove it, as needed.
            this.employeeInfoTableAdapter.Fill(this.hospitalDataSet.employeeInfo);

            //display_data();

            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtpatientno.Text = row.Cells[0].Value.ToString();
                txtpatientname.Text = row.Cells[1].Value.ToString();
                txtpatientadd.Text = row.Cells[2].Value.ToString();
                cmbgender.Text = row.Cells[3].Value.ToString();
                txtpatientBD.Text = row.Cells[4].Value.ToString();
                txtpatientage.Text = row.Cells[5].Value.ToString();
                txtpatientmob.Text = row.Cells[6].Value.ToString();
                txtpatienttelno.Text = row.Cells[7].Value.ToString();
                txtpatientrel.Text = row.Cells[8].Value.ToString();
                txtpatientfileno.Text = row.Cells[9].Value.ToString();
                txtpatientstandno.Text = row.Cells[10].Value.ToString();
                txtpatientrafno.Text = row.Cells[11].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            this.Hide();
            F1.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string x = txtpatientfileno.Text;
            
            string strcmd3;

            if (x != "0")
            {
                this.Hide();
                strcmd3 = @"E:\Boody\files\" + x + ".pdf";
                System.Diagnostics.Process.Start("cmd.exe", strcmd3);

            }
            else 
            {
                MessageBox.Show("!!رقم الملف غير موجود");
            }

        }

    }
}
