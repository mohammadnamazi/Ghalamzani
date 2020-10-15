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
    public partial class register_badahkari : Form
    {
        public register_badahkari()
        {
            InitializeComponent();
        }
       public SqlDataAdapter da = new SqlDataAdapter();
       public DataTable dt = new DataTable(); 
       public string kname;
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void register_badahkari_Load(object sender, EventArgs e)
        {
            Class_DB.dt.Columns.Clear();
            Class_DB.refresh("bedehkari");
            dataGridView1.DataSource = Class_DB.dt;
            dataGridView1.Columns["id"].HeaderText = "ردیف";
            dataGridView1.Columns["kargar_id"].HeaderText = "کد کارگر";
            dataGridView1.Columns["sharh"].HeaderText = "شرح";
            dataGridView1.Columns["dates"].HeaderText = "تاریخ";
            dataGridView1.Columns["date"].Visible = false;
            dataGridView1.Columns["cost"].HeaderText = "مبلغ";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //submit button
            try
            {
                SqlCommand cmd = new SqlCommand();

                string datte = bPersianCalenderTextBox1.Text;
                int date = int.Parse(Class_DB.Tarikh(datte));

                cmd.CommandText = "INSERT INTO [dbo].[bedehkari] ([kargar_id],[cost],[date],[dates],[sharh]) VALUES (@kgcode,@sharh,@date,@dates,@sharh)";
                cmd.Parameters.Add("@kgcode", SqlDbType.Int).Value = int.Parse(textBox1.Text);
                cmd.Parameters.Add("@cost", SqlDbType.NVarChar).Value = comboBox1.SelectedItem;
                cmd.Parameters.Add("@date", SqlDbType.Int).Value = date;
                cmd.Parameters.Add("@dates", SqlDbType.NVarChar).Value = datte;
                cmd.Parameters.Add("@sharh", SqlDbType.Int).Value = int.Parse(textBox2.Text);

                cmd.Connection = Class_DB.con;
                Class_DB.con.Open();
                cmd.ExecuteNonQuery();
                Class_DB.con.Close();
                Class_DB.refresh("bedehkari");
                dataGridView1.DataSource = Class_DB.dt;

                textBox1.Text = "";
                bPersianCalenderTextBox1.Text = "";
                comboBox1.SelectedText = "";
            }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                //delete button
                SqlCommand cmd = new SqlCommand();
                int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                cmd.CommandText = "DELETE FROM [dbo].[bedehkari] where ID = @idd";
                cmd.Parameters.Add("@idd", SqlDbType.Int).Value = id;
                cmd.Connection = Class_DB.con;
                Class_DB.con.Open();
                cmd.ExecuteNonQuery();
                Class_DB.con.Close();
                Class_DB.refresh("bedehkari");
                dataGridView1.DataSource = Class_DB.dt;
            }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };
            Class_DB.con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
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
                cmd.CommandText = "UPDATE [dbo].[bedehkari] set kargar_id=@kgcode,cost=@cost,date=@date,dates=@dates,sharh=@sharh where id=@id";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@kgcode", SqlDbType.Int).Value = int.Parse(textBox1.Text);
                cmd.Parameters.Add("@cost", SqlDbType.NVarChar).Value = int.Parse(textBox2.Text) ;
                cmd.Parameters.Add("@date", SqlDbType.Int).Value = date;
                cmd.Parameters.Add("@dates", SqlDbType.NVarChar).Value = datte;
                cmd.Parameters.Add("@sharh", SqlDbType.NVarChar).Value = comboBox1.SelectedItem; 
                dt.Columns.Clear();
                dt.Clear();
                cmd.Connection = Class_DB.con;
                Class_DB.con.Open();
                da.SelectCommand = cmd;
                da.SelectCommand.Connection = Class_DB.con;
                da.Fill(dt);
                Class_DB.con.Close();
                Class_DB.refresh("bedehkari");
                dataGridView1.DataSource = Class_DB.dt;
                textBox1.Text = "";
                textBox2.Text = "";
                bPersianCalenderTextBox1.Text = "";
                comboBox1.Text = "";

        }
            catch { MessageBox.Show("مقادیر را صحیح وارد کنید", "خاطا"); };
}

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["kargar_id"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["cost"].Value.ToString();
            bPersianCalenderTextBox1.Text= dataGridView1.CurrentRow.Cells["dates"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
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
    }
}
