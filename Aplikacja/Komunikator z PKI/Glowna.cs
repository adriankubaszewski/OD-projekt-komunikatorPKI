using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

namespace Komunikator_z_PKI
{
    public partial class Glowna : Form
    {
     

        Socket sockets;
        EndPoint ipLokalne, ipZnajomego;

        byte[] buffer;

        public Glowna(string login)
        {
            InitializeComponent();
            this.Text = "Komunikator PKI";
            label2.Text = login;

            sockets = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sockets.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            label4.Text = GetLocalIP();
            textBox1.Text = GetLocalIP();

        }

        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            /*foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }*/
            return "127.0.0.1";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // konwertowanie na ascii
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            byte[] msg = new byte[1500];
            msg = enc.GetBytes(textBox2.Text);

            // wysylanie wiadomosci
            sockets.Send(msg);
            listBox1.Items.Add("Ty: " + textBox2.Text);
            textBox2.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {                     
            ipLokalne = new IPEndPoint(IPAddress.Parse(label4.Text), Convert.ToInt32(textBox3.Text));
            sockets.Bind(ipLokalne);

            ipZnajomego = new IPEndPoint(IPAddress.Parse(textBox1.Text), Convert.ToInt32(textBox4.Text));
            sockets.Connect(ipZnajomego);

            buffer = new byte[1500];
            sockets.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref ipZnajomego, new AsyncCallback(OperatorCallBack), buffer);

            button1.Enabled = true;

        }

        private void OperatorCallBack(IAsyncResult asyRes)
        {
            try
            {
                int size = sockets.EndReceiveFrom(asyRes, ref ipZnajomego);

                // sprawdzanie czy jest jakas informacja
                if (size > 0)
                {
                    byte[] bufor = new byte[1500];

                    // pobieranie danych
                    bufor = (byte[])asyRes.AsyncState;

                    System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                    string msg = enc.GetString(bufor);

                    listBox1.Items.Add("Znajomy: " + msg);
                }

                // ponowne nasluchiwanie
                buffer = new byte[1500];
                sockets.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref ipZnajomego, new AsyncCallback(OperatorCallBack), buffer);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        
    }
}
