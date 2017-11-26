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
    public partial class Rejestracja : Form
    {
        public Rejestracja()
        {
            InitializeComponent();
            this.Text = "Komunikator PKI - Rejestracja";
        }
        public void Resetuj_formularz()
        {
            tb_login.Clear();
            tb_haslo.Clear();
            tb_haslo2.Clear();
            tb_imie.Clear();
            tb_nazwisko.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String loginn = tb_login.Text;
            String imiee = tb_imie.Text;
            String nazwiskoo = tb_nazwisko.Text;
            String nowe_haslo = tb_haslo.Text;
            String nowe_haslo2 = tb_haslo2.Text;

            if ((loginn != "") && (imiee != "") && (nazwiskoo != "") && (nowe_haslo != "") && (nowe_haslo2 != ""))
            {
                if (nowe_haslo == nowe_haslo2)
                {     
                        String hashcode = "";
                        byte[] bytes = Encoding.UTF8.GetBytes(tb_haslo.Text);
                        SHA256Managed crypt = new SHA256Managed();
                        byte[] hash = crypt.ComputeHash(bytes);
                        foreach (byte x in hash)
                        {
                            hashcode += x.ToString("x2");
                        }

                        using (var we = new VoipEntities())
                        {
                            var uzytkownik = we.Set<Uzytkownicy>();
                            uzytkownik.Add(new Uzytkownicy { haslo = hashcode, imie = imiee, nazwisko = nazwiskoo, login = loginn, klucz_publiczny = "1" });

                            we.SaveChanges();

                            MessageBox.Show("Dodano nowego użytkownika do bazy");

                            Resetuj_formularz();
                        }                 
                }
                else
                {
                    MessageBox.Show("Wprowadzone hasla różnią się od siebie!");
                    Resetuj_formularz();
                }
            }
            else
            {
                MessageBox.Show("Nie wprowadzono wszystkich wymaganych danych!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
