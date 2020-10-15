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
    public partial class register_kar : Form
    {
        public register_kar()
        {
            InitializeComponent();
        }
        public SqlDataAdapter da = new SqlDataAdapter();
        public DataTable dt = new DataTable();
        public string kname;
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
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
               
                string datte = bPersianCalenderTextBox1.Text;
                int date = int.Parse(Class_DB.Tarikh(datte));

                cmd.CommandText = "INSERT INTO [dbo].[kar] ([kargar_code],[kar],[size],[mablagh],[date],[dates],[k_name]) VALUES (@kgcode,@kar,@ksize,@kmablagh,@kdate,@kdates,@kname)";
                cmd.Parameters.Add("@kgcode", SqlDbType.Int).Value = int.Parse(textBox1.Text);
                cmd.Parameters.Add("@kar", SqlDbType.NVarChar).Value = comboBox1.SelectedItem;
                cmd.Parameters.Add("@ksize", SqlDbType.NVarChar).Value = comboBox2.SelectedItem;
                cmd.Parameters.Add("@kmablagh", SqlDbType.Int).Value = int.Parse(textBox2.Text);
                cmd.Parameters.Add("@kdate", SqlDbType.Int).Value = date;
                cmd.Parameters.Add("@kdates", SqlDbType.NVarChar).Value = datte;
                cmd.Parameters.Add("@kname", SqlDbType.NVarChar).Value = kname;

                cmd.Connection = Class_DB.con;
                Class_DB.con.Open();
                cmd.ExecuteNonQuery();
                Class_DB.con.Close();
                Class_DB.refresh("kar");
                dataGridView1.DataSource = Class_DB.dt;


                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                bPersianCalenderTextBox1.Text = "";
                comboBox1.SelectedText = "";
                comboBox2.Text = "";
        }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };
            Class_DB.con.Close();
        }            

        private void button9_Click(object sender, EventArgs e)
        {
            try {
                //delete button
                SqlCommand cmd = new SqlCommand();
                
                int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                cmd.CommandText = "DELETE FROM [dbo].[kar] where ID = @idd";
                cmd.Parameters.Add("@idd", SqlDbType.Int).Value = id;

                cmd.Connection = Class_DB.con;
                Class_DB.con.Open();
                cmd.ExecuteNonQuery();
                Class_DB.con.Close();
                Class_DB.refresh("kar");
                dataGridView1.DataSource = Class_DB.dt;

            }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };
            Class_DB.con.Close();
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
                int date = int.Parse(Class_DB.Tarikh(datte));
                cmd.CommandText = "UPDATE [dbo].[kar] set kargar_code=@kgcode,kar=@kar,size=@ksize,mablagh=@kmablagh,date=@kdate,dates=@kdates,kname=@kname where id=@id";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@kgcode", SqlDbType.Int).Value = int.Parse(textBox1.Text);
                cmd.Parameters.Add("@kar", SqlDbType.NVarChar).Value = comboBox1.SelectedItem;
                cmd.Parameters.Add("@ksize", SqlDbType.NVarChar).Value = comboBox2.SelectedItem;
                cmd.Parameters.Add("@kmablagh", SqlDbType.Int).Value = int.Parse(textBox2.Text);
                cmd.Parameters.Add("@kdate", SqlDbType.Int).Value = date;
                cmd.Parameters.Add("@kdates", SqlDbType.NVarChar).Value = datte;
                cmd.Parameters.Add("@kname", SqlDbType.NVarChar).Value = kname;

                cmd.Connection = Class_DB.con;
                Class_DB.con.Open();
                cmd.ExecuteNonQuery();
                Class_DB.con.Close();
                Class_DB.refresh("kar");
                dataGridView1.DataSource = Class_DB.dt;

                textBox1.Text = "";
                textBox2.Text = "";
                bPersianCalenderTextBox1.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };
            Class_DB.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kargar code
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "SELECT id FROM [dbo].[search_kargar] where namefname=@namee ";
                cmd.Parameters.Add("@namee", SqlDbType.NVarChar).Value = textBox3.Text;
                dt.Columns.Clear();
                Class_DB.con.Open();
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = Class_DB.con;
                da.Fill(dt);
                Class_DB.con.Close();
            }
            catch { MessageBox.Show("wrong"); }
            dataGridView2.DataSource = dt;

            if (dataGridView2[0, 0].Value == null)
                MessageBox.Show("این شخص ثبت نشده است", "خطا");
            else
            {
                textBox1.Text = dataGridView2.CurrentRow.Cells["id"].Value.ToString();
                kname = textBox3.Text;
                dt.Clear();
                dataGridView2[0, 0].Value = null;
            }
        }
        private void register_kar_Load(object sender, EventArgs e)
        {
            Class_DB.dt.Columns.Clear();
            Class_DB.refresh("kar");
            dataGridView1.DataSource = Class_DB.dt;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["kargar_code"].HeaderText = "کد کارگر";
            dataGridView1.Columns["kar"].HeaderText = "کار";
            dataGridView1.Columns["size"].HeaderText = "اندازه";
            dataGridView1.Columns["mablagh"].HeaderText = "مبلغ";
            dataGridView1.Columns["dates"].HeaderText = "تاریخ";
            dataGridView1.Columns["k_name"].HeaderText = "نام کارگر";
            dataGridView1.Columns["date"].Visible=false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["kargar_code"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["mablagh"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["k_name"].Value.ToString();
            comboBox1.SelectedText = dataGridView1.CurrentRow.Cells["kar"].Value.ToString();
            comboBox2.SelectedText = dataGridView1.CurrentRow.Cells["size"].Value.ToString();
        }
    }
}
