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
    public partial class register_sefaresh : Form
    {
        public register_sefaresh()
        {
            InitializeComponent();
        }
        public SqlDataAdapter da = new SqlDataAdapter();
        public DataTable dt = new DataTable();
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //submit button
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                string datte = bPersianCalenderTextBox1.Text;
        
                cmd.CommandText = "INSERT INTO [dbo].[sefaresh] ([name],[date],[pardakhti],[cost]) VALUES (@name,@datte,@pardakhti,@cost)";
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@pardakhti", SqlDbType.Int).Value =int.Parse( textBox2.Text);
                cmd.Parameters.Add("@cost", SqlDbType.Int).Value = int.Parse(textBox3.Text);
                cmd.Parameters.Add("@datte", SqlDbType.NVarChar).Value = datte;

                cmd.Connection = Class_DB.con;
                Class_DB.con.Open();
                cmd.ExecuteNonQuery();
                Class_DB.con.Close();
                Class_DB.refresh("sefaresh");
                dataGridView1.DataSource = Class_DB.dt;
                textBox1.Text = "";
                textBox3.Text = "";
                bPersianCalenderTextBox1.Text = "";

            }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                //delete button
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                cmd.CommandText = "DELETE FROM [dbo].[sefaresh] where ID = @idd";
                cmd.Parameters.Add("@idd", SqlDbType.Int).Value = id;

                cmd.Connection = Class_DB.con;
                Class_DB.con.Open();
                cmd.ExecuteNonQuery();
                Class_DB.con.Close();
                Class_DB.refresh("sefaresh");
                dataGridView1.DataSource = Class_DB.dt;

            }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //edit button 
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                string datte = bPersianCalenderTextBox1.Text;
                
                cmd.CommandText = "UPDATE [dbo].[sefaresh] set name=@name,date=@datte,pardakhti=@pardakhti,cost=@cost where id=@id";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@datte", SqlDbType.NVarChar).Value = datte;
                cmd.Parameters.Add("@pardakhti", SqlDbType.Int).Value = int.Parse(textBox2.Text);
                cmd.Parameters.Add("@cost", SqlDbType.Int).Value = int.Parse(textBox3.Text);

                cmd.Connection = Class_DB.con;
                Class_DB.con.Open();
                cmd.ExecuteNonQuery();
                Class_DB.con.Close();
                Class_DB.refresh("sefaresh");
                dataGridView1.DataSource = Class_DB.dt;
                textBox1.Text = "";
                textBox3.Text = "";
            bPersianCalenderTextBox1.Text = "";

            }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };
        }

        private void register_sefaresh_Load(object sender, EventArgs e)
        {
            Class_DB.dt.Columns.Clear();
            Class_DB.refresh("sefaresh");
            dataGridView1.DataSource = Class_DB.dt;
            dataGridView1.Columns["id"].HeaderText = "ردیف";
            dataGridView1.Columns["name"].HeaderText = "نام و نام خانوادگی";
            dataGridView1.Columns["date"].HeaderText = "تاریخ";
            dataGridView1.Columns["pardakhti"].HeaderText = "پرداختی";
            dataGridView1.Columns["cost"].HeaderText = "مبلغ";
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["name"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["pardakhti"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["cost"].Value.ToString();
            bPersianCalenderTextBox1.Text= dataGridView1.CurrentRow.Cells["date"].Value.ToString();
        }
    }
}
