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
    public partial class register_rizkarkerd : Form
    {
        public register_rizkarkerd()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string firstd, secondd, cmdtext,cmdtext2;
            int fird,secd;
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand();
            if (bPersianCalenderTextBox1.Text == "" && bPersianCalenderTextBox2.Text == "")
            {
                dataGridView1.Columns.Clear();
                dataGridView2.Columns.Clear();
                cmdtext = "SELECT * FROM [dbo].[riz_karkerd] where namefname = @b";
                cmdtext2 = "SELECT sum(cpadash) as cp,sum(mablagh) as mp , sum(cbedehi) as cb , sum([mablagh] +[cpadash] -[cbedehi]) as hogh FROM[dbo].[riz_karkerd] where namefname = @b" ;
            }
            else
            {
                dataGridView1.Columns.Clear();
                dataGridView2.Columns.Clear();
                firstd = bPersianCalenderTextBox1.Text;
                secondd = bPersianCalenderTextBox2.Text;
                fird = int.Parse(Class_DB.Tarikh(firstd));
                secd = int.Parse(Class_DB.Tarikh(secondd));
                cmd.Parameters.Add("@a", SqlDbType.Int).Value = secd;
                cmd.Parameters.Add("@c", SqlDbType.Int).Value = fird;
                cmd1.Parameters.Add("@a", SqlDbType.Int).Value = secd;
                cmd1.Parameters.Add("@c", SqlDbType.Int).Value = fird;
                cmdtext = "SELECT * FROM [dbo].[riz_karkerd] where namefname = @b And date<=@a And date>=@c Or date1<=@a And date1>=@c Or dat<=@a And dat>=@c";
                cmdtext2 = "SELECT sum(cpadash) as cp,sum(mablagh) as mp , sum(cbedehi) as cb , sum([mablagh] +[cpadash] -[cbedehi]) as hogh FROM[dbo].[riz_karkerd] where namefname = @b And date<=@a And date>=@c Or date1<=@a And date1>=@c Or dat<=@a And dat>=@c";
            }
            try
            {

                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    cmd.CommandText = cmdtext;
                    cmd.Parameters.Add("@b", SqlDbType.NVarChar).Value = textBox1.Text;
                    cmd.Connection = Class_DB.con;
                    Class_DB.con.Open();
                    da.SelectCommand = cmd;
                    da.SelectCommand.Connection = Class_DB.con;
                    da.Fill(dt);
                    Class_DB.con.Close();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["date"].Visible = false;
                    dataGridView1.Columns["kid"].HeaderText = "کد کارگر";
                    dataGridView1.Columns["namefname"].HeaderText = "نام و نام خانوادگی";
                    dataGridView1.Columns["mellicode"].HeaderText = "کدملی";
                    dataGridView1.Columns["cpadash"].HeaderText = "مبلغ پاداش";
                    dataGridView1.Columns["padash"].HeaderText = "شرح پاداش";
                    dataGridView1.Columns["pdate"].HeaderText = "تاریخ پاداش";
                    dataGridView1.Columns["mablagh"].HeaderText = "مبلغ کار";
                    dataGridView1.Columns["kdate"].HeaderText = "تاریخ کار";
                    dataGridView1.Columns["cbedehi"].HeaderText = "مبلغ بدهی";
                    dataGridView1.Columns["dbedehi"].HeaderText = "تاریخ بدهکاری";
                    dataGridView1.Columns["shbedehi"].HeaderText = "شرح بدهکاری";
            //sum               
                    SqlDataAdapter da1 = new SqlDataAdapter();
                    DataTable dt1 = new DataTable();
                    cmd1.CommandText = cmdtext2;
                    cmd1.Parameters.Add("@b", SqlDbType.NVarChar).Value = textBox1.Text;
                    cmd1.Connection = Class_DB.con;
                    Class_DB.con.Open();
                    da1.SelectCommand = cmd1;
                    da1.SelectCommand.Connection = Class_DB.con;
                    da1.Fill(dt1);
                    Class_DB.con.Close();
                    dataGridView2.DataSource = dt1;
                    dataGridView2.Columns["cp"].HeaderText = "مجموع پاداش";
                    dataGridView2.Columns["mp"].HeaderText = "مجموع دستمزد";
                    dataGridView2.Columns["cb"].HeaderText = "مجموع بدهی";
                    dataGridView2.Columns["hogh"].HeaderText = "حقوق";
        }
                catch { MessageBox.Show("اخطار", "نام وارد شده موجود نیست"); };

}

        private void register_rizkarkerd_Load(object sender, EventArgs e)
        {
         
        }

        
    }
}
