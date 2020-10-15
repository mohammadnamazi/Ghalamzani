using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kargah_e_ghalam_zani
{
    class Class_DB                                            
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ghalamzani.mdf;Integrated Security=True;Connect Timeout=30");
        public static SqlCommand cmd = new SqlCommand();           
        public static SqlDataAdapter da = new SqlDataAdapter();
        public static DataTable dt = new DataTable();
        public static string user=" ";
        public static void refresh(string Sselect)
        {
            Class_DB.cmd.CommandText ="SELECT * FROM " + Sselect;
            Class_DB.dt.Clear();
            Class_DB.cmd.Connection = con;
            Class_DB.con.Open();
            Class_DB.da.SelectCommand = cmd;
            Class_DB.da.SelectCommand.Connection = con;
            Class_DB.da.Fill(dt);
            Class_DB.con.Close();
        }
        public static string Tarikh (string a )
        {
            string b = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != '/')
                    b += a[i].ToString();
            }
            return b;
        }
       
    }
}
