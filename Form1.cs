using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kargah_e_ghalam_zani
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int timer = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = Class_DB.user;
            if (Class_DB.user != "مدیر سیستم")
                button8.Visible = false;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            register_kargar frm = new register_kargar();
            frm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            register_kar frm = new register_kar();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            register_padash frm = new register_padash();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            register_sefaresh frm = new register_sefaresh();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            register_rizkarkerd frm = new register_rizkarkerd();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            register_badahkari frm = new register_badahkari();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            if (timer <= 3)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
            }
            else if (timer <= 6 && timer > 3)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
            }
            else if (timer <= 9 && timer > 6)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
            }
            else if (timer <= 12 && timer > 9)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
                pictureBox5.Visible = false;
            }
            else if (timer <= 15 && timer > 12)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
            }
            else if (timer >= 15)
            {
                timer = 0;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            users frm = new users();
            frm.ShowDialog();
        }
    }
}
