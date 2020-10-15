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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox2.PasswordChar = '\0';
            else
                textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select kind from [dbo].[login] where user_name = @a And password = @b";
                cmd.Parameters.Add("@a", SqlDbType.NChar).Value = textBox1.Text;
                cmd.Parameters.Add("@b", SqlDbType.NChar).Value = textBox2.Text;
                Class_DB.dt.Columns.Clear();
                Class_DB.con.Open();
                Class_DB.da.SelectCommand = cmd;
                Class_DB.da.SelectCommand.Connection = Class_DB.con;
                Class_DB.da.Fill(Class_DB.dt);
                Class_DB.con.Close();
                dataGridView1.DataSource = Class_DB.dt;
                Class_DB.user = dataGridView1.CurrentRow.Cells["kind"].Value.ToString();
                Form1 frm = new Form1();
                frm.ShowDialog();
                this.Close();
            }
            catch { MessageBox.Show("نام کاربری یا رمز ورود اشتباه وارد شده است", "اخطار"); };
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
