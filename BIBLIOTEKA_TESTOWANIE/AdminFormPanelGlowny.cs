using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace BIBLIOTEKA_TESTOWANIE
{
    public partial class AdminFormPanelGlowny : Form
    {
        private string connectionString = "Server=LAPTOPIK-K4514\\SQLDEVELOPER;Database=TEST2;Integrated Security=True;TrustServerCertificate=True";
        //private string connectionString = "Server=desktop-7l2t535\\SQLEXPRESS;Database=;Integrated Security=True;TrustServerCertificate=True";
        //private string connectionString = "Server=desktop-7l2t535;Database=;Trusted_Connection=True;TrustServerCertificate=True;";
        //private string connectionString = "Server=localhost;Database=;Trusted_Connection=True;TrustServerCertificate=True;";

        private int edytowanyUzytkownikID = -1;

        public AdminFormPanelGlowny()
        {
            InitializeComponent();
            //dataGridViewUzytkownicy = new DataGridView();
            //this.Controls.Add(dataGridViewUzytkownicy);
            // WyswietlUzytkownikow();
            int idUzytkownika = Session.LoggedInUserId;
            var uprawnienia = Session.UprawnieniaUzytkownika;
            buttonDodajUzytkownika.Visible = uprawnienia.Contains("Dodawanie nowych uzytkowników");
            buttonAktywniUzytkownicy.Visible = uprawnienia.Contains("Wyświetlanie listy użytkowników");
            buttonZapomnieniUzytkownicy.Visible = uprawnienia.Contains("Wyszukiwanie zapomnianych użytkowników");
            buttonListaUprawnien.Visible = uprawnienia.Contains("Przegląd listy dostępnych uprawnień");
            buttonUprawnieniaUzytkownikow.Visible = uprawnienia.Contains("Nadawanie uprawnień użytkownikom");
            buttonWyloguj.Visible= uprawnienia.Contains("Możliwość wylogowania");

        }
        private void buttonDodajUzytkownika_Click(object sender, EventArgs e)
        {
            AdminFormDodajUzytkownika formDodaj = new AdminFormDodajUzytkownika();
            formDodaj.Show();
            this.Hide();
        }

        private void buttonAktywniUzytkownicy_Click(object sender, EventArgs e)
        {
            AdminFormAktywniUzytkownicy formPodglad = new AdminFormAktywniUzytkownicy();
            formPodglad.Show();
            this.Hide();
        }

        private void buttonZapomnieniUzytkownicy_Click(object sender, EventArgs e)
        {
            AdminFormZapomnieniUzytkownicy formZapomnieni = new AdminFormZapomnieniUzytkownicy();
            formZapomnieni.Show();
            this.Hide();
        }

        private void buttonListaUprawnien_Click(object sender, EventArgs e)
        {
            AdminFormListaUprawnien listaUprawnien = new AdminFormListaUprawnien();
            listaUprawnien.Show();
            this.Hide();
        }

        private void buttonUprawnieniaUzytkownikow_Click(object sender, EventArgs e)
        {
            AdminFormPrzeglądUżytkownikówODanymUprawnieniu form = new AdminFormPrzeglądUżytkownikówODanymUprawnieniu();
            form.Show();
            this.Hide();
        }

        private void buttonWyloguj_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Czy na pewno chcesz się wylogować?",
              "Potwierdzenie",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                FormLogin formLogin = new FormLogin();
                formLogin.Show();

                this.Close();
            }
            Session.LoggedInUserId = 0;

            
        }

        private void buttonZmienHasloUzytkownikowi_Click(object sender, EventArgs e)
        {
            FormZmienHaslo formZmienHaslo = new FormZmienHaslo();
            formZmienHaslo.Show();
            this.Hide();
        }
    }

}
