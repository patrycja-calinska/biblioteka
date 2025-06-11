using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BIBLIOTEKA_TESTOWANIE
{
    public partial class FormOdzyskajHaslo : Form
    {
        public FormOdzyskajHaslo()
        {
            InitializeComponent();
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }

        private void buttonZatwierdz_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string tymczasoweHaslo = GenerateTemporaryPassword();
            bool danePoprawne = false;

            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(email))
            {
                string connectionString = "Server=LAPTOPIK-K4514\\SQLDEVELOPER;Database=BibliotekaBaza;Integrated Security=True;TrustServerCertificate=True";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ID_uzytkownik FROM Uzytkownik WHERE Login_uzytkownika = @login", conn);
                    cmd.Parameters.AddWithValue("@login", login);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int userId = Convert.ToInt32(result);

                        SqlCommand updateCmd = new SqlCommand(
                            "UPDATE Uzytkownik SET Tymczasowe_haslo = @haslo, Czy_tymczasowe_haslo = 1 WHERE ID_uzytkownik = @id", conn);
                        updateCmd.Parameters.AddWithValue("@haslo", tymczasoweHaslo);
                        updateCmd.Parameters.AddWithValue("@id", userId);
                        updateCmd.ExecuteNonQuery();

                        danePoprawne = true;
                    }
                }
            }
            if (danePoprawne)
            {
                WyslijEmailZTymczasowymHaslem("testo.biblio@gmail.com", tymczasoweHaslo);
            }


            MessageBox.Show("Tymczasowe hasło zostało wysłane na e-mail.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            new FormLogin().Show();
            this.Hide();
        }

        private string GenerateTemporaryPassword(int length = 10)
        {
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string special = "-_!*#$&";
            Random random = new Random();
            List<char> passwordChars = new List<char>();

            for (int i = 0; i < 3; i++) passwordChars.Add(upper[random.Next(upper.Length)]);
            for (int i = 0; i < 3; i++) passwordChars.Add(lower[random.Next(lower.Length)]);
            for (int i = 0; i < 2; i++) passwordChars.Add(digits[random.Next(digits.Length)]);
            for (int i = 0; i < 2; i++) passwordChars.Add(special[random.Next(special.Length)]);

            return new string(passwordChars.OrderBy(x => random.Next()).ToArray());
        }

        private void WyslijEmailZTymczasowymHaslem(string email, string haslo)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("testo.biblio@gmail.com", "paej xjma iwjm xgpt"),
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("testo.biblio@gmail.com"),
                    Subject = "Tymczasowe hasło do systemu",
                    Body = $"Twoje tymczasowe hasło to: {haslo}",
                    IsBodyHtml = false,
                };

                // Możesz tu zahardkodować adres testowy lub używać dynamicznego:
                mailMessage.To.Add("testo.biblio@gmail.com"); // 

                smtpClient.Send(mailMessage);
                //MessageBox.Show("Tymczasowe hasło zostało wysłane na e-mail.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udało się wysłać e-maila: " + ex.Message, "Błąd SMTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //testo.biblio@gmail.com Oprogramowanie123          paej xjma iwjm xgpt
        }   //mail                   haslo na maila             haslo do aplikacji(trzeba uzywac tego w kodzie)

        private void FormOdzyskajHaslo_Load(object sender, EventArgs e)
        {

        }
    }
}
