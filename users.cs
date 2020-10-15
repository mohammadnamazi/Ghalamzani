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
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //submit button
            try
            {
                SqlCommand cmd = new SqlCommand();
                
                cmd.CommandText = "INSERT INTO [dbo].[login] ([user_name],[password],[kind]) VALUES (@usern,@pass,@kind)";
                cmd.Parameters.Add("@usern", SqlDbType.NVarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = textBox2.Text;
                cmd.Parameters.Add("@kind", SqlDbType.NVarChar).Value = comboBox1.SelectedItem;
                cmd.Connection = Class_DB.con;
                Class_DB.con.Open();
                cmd.ExecuteNonQuery();
                Class_DB.con.Close();
                Class_DB.refresh("login");
                dataGridView1.DataSource = Class_DB.dt;
                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };
            Class_DB.con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete button
            try
            {
                SqlCommand cmd = new SqlCommand();

                int id = int.Parse(dataGridView1.CurrentRow.Cells["user_name"].Value.ToString());
                cmd.CommandText = "DELETE FROM [dbo].[login] where user_name = @UN";
                cmd.Parameters.Add("@UN", SqlDbType.Int).Value = id;
                cmd.Connection = Class_DB.con;
                Class_DB.con.Open();
                cmd.ExecuteNonQuery();
                Class_DB.con.Close();
                Class_DB.refresh("login");
                dataGridView1.DataSource = Class_DB.dt;
                textBox1.Text = "";
                textBox2.Text = "";
               
            }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };
            Class_DB.con.Close();
        }

        private void users_Load(object sender, EventArgs e)
        {
            Class_DB.dt.Columns.Clear();
            Class_DB.refresh("login");
            dataGridView1.DataSource = Class_DB.dt;
            dataGridView1.Columns["user_name"].HeaderText="نام کاربری";
            dataGridView1.Columns["password"].HeaderText = "رمز ورود";
            dataGridView1.Columns["kind"].HeaderText = "نوع کاربر";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
