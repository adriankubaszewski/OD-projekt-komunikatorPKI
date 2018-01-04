using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

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
            // szyfrowanie
            string zaszyfrowany = DoZaszyfrowania(textBox2.Text);

            // konwertowanie na ascii
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            byte[] msg = new byte[1500];
            msg = enc.GetBytes(zaszyfrowany);

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

                    System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                    string msg = enc.GetString(bufor);
                    label8.Text = msg;

                    ///// odszyfrowanie
                    string rozszyfrowany = DoRozszyfrowania(label8.Text);

                    listBox1.Items.Add("Znajomy: " + rozszyfrowany);
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

        //////////////////////////////////////////////
        //// SZYFROWANIE
        //////////////////////////////////////////////

        private static string IV = "hdfehf739f82sie3";  // musi mie 16 charów 
        private static string Key = "sjgutkgirpfjenitvjeig94i3mkfm39g";   // musi mieć 32 czary

        public static string DoZaszyfrowania(string podany)
        {
            return Zaszyfruj(podany);
        }
        public static string DoRozszyfrowania(string podany)
        {
            return Rozszyfruj(podany);
        }

        private static string Zaszyfruj(string dozaszyfrowania)
        {
            byte[] textbytes = ASCIIEncoding.ASCII.GetBytes(dozaszyfrowania);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            aes.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = aes.CreateEncryptor(aes.Key, aes.IV);

            byte[] dane = icrypt.TransformFinalBlock(textbytes, 0, textbytes.Length);
            icrypt.Dispose();

            return Convert.ToBase64String(dane);
        }

        private static string Rozszyfruj(string dorozszyfrowania)
        {

            byte[] encbytes = Convert.FromBase64String(dorozszyfrowania);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            aes.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = aes.CreateDecryptor(aes.Key, aes.IV);

            byte[] dane = icrypt.TransformFinalBlock(encbytes, 0, encbytes.Length);
            icrypt.Dispose();

            return ASCIIEncoding.ASCII.GetString(dane);
        }

        
    }
}
