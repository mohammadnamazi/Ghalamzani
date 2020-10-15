using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kargah_e_ghalam_zani
{
    public partial class register_kargar : Form
    {

        public register_kargar()
        {
            InitializeComponent();
        }
      
       
        
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //edit button 
            try {
                SqlCommand cmd = new SqlCommand();
                int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                string datte = bPersianCalenderTextBox1.Text;
                cmd.CommandText = "UPDATE [dbo].[kargar] set name=@namee,family=@familyy,tarikh_tavalod=@ttavalod,father_name=@fname,mellicode=@mecode,address=@addres where id=@id";
                cmd.Parameters.Add("@namee", SqlDbType.NVarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@familyy", SqlDbType.NVarChar).Value = textBox2.Text;
                cmd.Parameters.Add("@ttavalod", SqlDbType.NVarChar).Value = datte;
                cmd.Parameters.Add("@fname", SqlDbType.NVarChar).Value = textBox3.Text;
                cmd.Parameters.Add("@mecode", SqlDbType.Int).Value = textBox4.Text;
                cmd.Parameters.Add("@addres", SqlDbType.NVarChar).Value = textBox5.Text;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Connection = Class_DB.con;
                Class_DB.con.Open();
                cmd.ExecuteNonQuery();
                Class_DB.con.Close();
                Class_DB.refresh("kargar");
                dataGridView1.DataSource = Class_DB.dt;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                bPersianCalenderTextBox1.Text = "";
            }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };
            Class_DB.con.Close();

        }

        private void register_kargar_Load(object sender, EventArgs e)
        {
            Class_DB.dt.Columns.Clear();
            Class_DB.refresh("kargar");
            dataGridView1.DataSource = Class_DB.dt;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["name"].HeaderText = "نام";
            dataGridView1.Columns["family"].HeaderText = "نام خانوادگی";
            dataGridView1.Columns["tarikh_tavalod"].HeaderText = "تاریخ نولد";
            dataGridView1.Columns["father_name"].HeaderText = "نام پدر";
            dataGridView1.Columns["mellicode"].HeaderText = "کد ملی";
            dataGridView1.Columns["address"].HeaderText = "آدرس";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //submit button
            try { 
                SqlCommand cmd = new SqlCommand();
                string datte = bPersianCalenderTextBox1.Text;
                cmd.CommandText = "INSERT INTO [dbo].[kargar] ([name],[family],[tarikh_tavalod],[father_name],[mellicode],[address]) VALUES (@namee,@familyy,@ttavalod,@fname,@mecode,@addres)";
                cmd.Parameters.Add("@namee", SqlDbType.NVarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@familyy", SqlDbType.NVarChar).Value = textBox2.Text;
                cmd.Parameters.Add("@ttavalod", SqlDbType.NVarChar).Value = datte;
                cmd.Parameters.Add("@fname", SqlDbType.NVarChar).Value = textBox3.Text;
                cmd.Parameters.Add("@mecode", SqlDbType.Int).Value = textBox4.Text;
                cmd.Parameters.Add("@addres", SqlDbType.NVarChar).Value = textBox5.Text;
                cmd.Connection = Class_DB.con;
                Class_DB.con.Open();
                cmd.ExecuteNonQuery();
                Class_DB.con.Close();
                Class_DB.refresh("kargar");
                dataGridView1.DataSource = Class_DB.dt;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                bPersianCalenderTextBox1.Text="";
            }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };
            Class_DB.con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //delete button
            try { 
            SqlCommand cmd = new SqlCommand();
           
            int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            cmd.CommandText = "DELETE FROM [dbo].[kargar] where ID = @idd";
            cmd.Parameters.Add("@idd", SqlDbType.Int).Value = id;
            cmd.Connection = Class_DB.con;
            Class_DB.con.Open();
            cmd.ExecuteNonQuery();
            Class_DB.con.Close();
            Class_DB.refresh("kargar");
            dataGridView1.DataSource = Class_DB.dt;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                bPersianCalenderTextBox1.Text = "";
            }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };
            Class_DB.con.Close();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["name"].Value.ToString(); 
            textBox2.Text = dataGridView1.CurrentRow.Cells["family"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["father_name"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["mellicode"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["address"].Value.ToString();
            bPersianCalenderTextBox1.Text = dataGridView1.CurrentRow.Cells["tarikh_tavalod"].Value.ToString();
        }
    }
}
