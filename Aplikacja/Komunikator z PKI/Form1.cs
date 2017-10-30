using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komunikator_z_PKI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_login.Text == "user" && tb_haslo.Text == "1234")
            {
                Form2 f2 = new Form2(tb_login.Text);
                f2.Show();
            }
            else
                label3.Text = "BŁĘDNE DANE LOGOWANIA";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
