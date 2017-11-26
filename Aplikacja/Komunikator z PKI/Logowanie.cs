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

namespace Komunikator_z_PKI
{
    public partial class Logowanie : Form
    {
        public Logowanie()
        {
            InitializeComponent();
            this.Text = "Komunikator PKI - Logowanie";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool polaczenie = true;
            string uzytkownik = tb_login.Text;

            // HASHOWANIE HASŁA PRZY POMOCY FUNKCJI SKRÓTU SHA256
            String hashcode = "";
            byte[] bytes = Encoding.UTF8.GetBytes(tb_haslo.Text);
            SHA256Managed crypt = new SHA256Managed();
            byte[] hash = crypt.ComputeHash(bytes);
            foreach (byte x in hash)
            {
                hashcode += x.ToString("x2");
            }

            // NAWIĄZYWANIE POŁĄCZENIA Z BAZĄ DANYCH
            using (VoipEntities voip = new VoipEntities())
            {
                try
                {
                    voip.Database.Connection.Open();
                    voip.Database.Connection.Close();
                }

                catch (Exception blad_sieci)
                {
                    polaczenie = false;
                };
                bool dostep = true;

                if (polaczenie == true)
                {
                    voip.Database.Connection.Open();

                    if (voip.Database.Connection.State != ConnectionState.Open)
                    {
                        MessageBox.Show("Problem z nawiązaniem połączenia z bazą danych.", "Błąd systemu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // SPRAWDZENIE LOGINU I HASLA JEDNOCZEŚNIE

                    // SPRAWDZENIE CZY LOGIN I HASLO ISTNIEJA W BAZIE
                    using (var wh = new VoipEntities())
                    {
                        var result = (from k in wh.Uzytkownicy
                                      where k.login == tb_login.Text && k.haslo == hashcode
                                      select new
                                      {
                                          k.id_uzytkownika

                                      }).Count();
                        if (result < 1)
                        {
                            MessageBox.Show("Podano błędne dane logowania.", "Błąd systemu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dostep = false;
                            tb_login.Clear();
                            tb_haslo.Clear();
                        }
                        else
                        {
                            this.Hide();
                            Glowna main = new Glowna(tb_login.Text);
                            main.Show();
                        }
                    }
                }
            }

                        /*
                        if (tb_login.Text == "user" && tb_haslo.Text == "1234")
                        {
                            Form2 f2 = new Form2(tb_login.Text);
                            f2.Show();
                        }
                        else
                            label3.Text = "BŁĘDNE DANE LOGOWANIA";
                            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rejestracja f3 = new Rejestracja();
            f3.Show();
        }
    }
}
