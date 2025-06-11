using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BIBLIOTEKA_TESTOWANIE
{
    public static class Validator
    {
        private static readonly string connectionString = "Server=LAPTOPIK-K4514\\SQLDEVELOPER;Database=TEST2;Integrated Security=True;TrustServerCertificate=True";
        public static bool IsNotEmpty(string value) =>
            !string.IsNullOrWhiteSpace(value);

        public static bool IsValidPESEL(string pesel)
        {
            if (!Regex.IsMatch(pesel, @"^\d{11}$"))
                return false;

            int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int suma = 0;
            for (int i = 0; i < 10; i++)
                suma += wagi[i] * (pesel[i] - '0');

            int kontrolna = (10 - (suma % 10)) % 10;
            return kontrolna == (pesel[10] - '0');
        }

        public static bool IsValidEmail(string email) =>
            Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") && email.Length <= 255;

        public static bool IsValidPhoneNumber(string number) =>
            Regex.IsMatch(number, @"^\d{9}$");

        public static bool IsValidPostalCode(string postalCode) =>
            Regex.IsMatch(postalCode, @"^\d{2}-\d{3}$");

        public static bool IsValidDate(DateTime date)
        {
            DateTime minDate = new DateTime(1900, 1, 1);
            DateTime maxDate = DateTime.Today;
            return date >= minDate && date <= maxDate;
        }
        public static bool IsValidPassword(string haslo, int userId, out string komunikat)
        {
            komunikat = "";

            if (haslo.Length < 8 || haslo.Length > 15)
            {
                komunikat = "Hasło musi mieć od 8 do 15 znaków.";
                return false;
            }

            if (!Regex.IsMatch(haslo, "[A-Z]"))
            {
                komunikat = "Hasło musi zawierać co najmniej jedną wielką literę.";
                return false;
            }

            if (!Regex.IsMatch(haslo, "[a-z]"))
            {
                komunikat = "Hasło musi zawierać co najmniej jedną małą literę.";
                return false;
            }

            if (!Regex.IsMatch(haslo, "[0-9]"))
            {
                komunikat = "Hasło musi zawierać co najmniej jedną cyfrę.";
                return false;
            }

            if (!Regex.IsMatch(haslo, "[-_!*#$&]"))
            {
                komunikat = "Hasło musi zawierać co najmniej jeden znak specjalny: -, _, !, *, #, $, &.";
                return false;
            }
            if (IsPasswordInHistory(haslo, userId))
            {
                komunikat = "Nowe hasło nie może być takie samo jak jedno z 3 ostatnich.";
                return false;
            }

            return true;
        }
        private static bool IsPasswordInHistory(string password, int userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                SELECT TOP 3 Phaslo
                FROM Poprzednie_hasla
                WHERE FK_ID_uzytkownik = @userId
                ORDER BY data_zmiany DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["Phaslo"].ToString() == password)
                        return true;
                }
            }
            return false;
        }
        public static bool IsLoginAllowed(int userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT COUNT(*) 
            FROM ProbyLogowania 
            WHERE FK_ID_uzytkownik = @userId 
                AND Czy_poprawna = 0 
                AND Data_proby >= DATEADD(MINUTE, -15, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                int failedAttempts = (int)cmd.ExecuteScalar();

                return failedAttempts < 3;
            }
        }

        public static bool ValidateUserDataDetailed(
            string login,
            string imie,
            string nazwisko,
            string pesel,
            string plec,
            string email,
            string phone,
            string miejscowosc,
            string kodPocztowy,
            string ulica,
            string nrPosesji,
            out string errorMessage)
        {
            if (!IsNotEmpty(login))
            {
                errorMessage = "Błąd! Proszę wprowadzić poprawny login";
                return false;
            }

            if (!IsNotEmpty(imie))
            {
                errorMessage = "Błąd! Proszę wprowadzić poprawne imię";
                return false;
            }

            if (!IsNotEmpty(nazwisko))
            {
                errorMessage = "Błąd! Proszę wprowadzić poprawne nazwisko";
                return false;
            }

            if (!IsValidPESEL(pesel))
            {
                errorMessage = "Błąd! Proszę wprowadzić poprawny numer PESEL";
                return false;
            }

            if (!IsNotEmpty(plec))
            {
                errorMessage = "Błąd! Proszę wprowadzić płeć";
                return false;
            }

            if (!IsValidEmail(email))
            {
                errorMessage = "Błąd! Proszę wprowadzić poprawny adres e-mail";
                return false;
            }

            if (!IsValidPhoneNumber(phone))
            {
                errorMessage = "Błąd! Proszę wprowadzić poprawny numer telefonu";
                return false;
            }

            if (!IsNotEmpty(miejscowosc))
            {
                errorMessage = "Błąd! Proszę wprowadzić poprawną nazwę miejscowości";
                return false;
            }

            if (!IsValidPostalCode(kodPocztowy))
            {
                errorMessage = "Błąd! Proszę wprowadzić poprawny kod pocztowy (format XX-XXX)";
                return false;
            }

            if (!IsNotEmpty(ulica))
            {
                errorMessage = "Błąd! Proszę wprowadzić poprawną nazwę ulicy";
                return false;
            }

            if (!IsNotEmpty(nrPosesji))
            {
                errorMessage = "Błąd! Proszę wprowadzić poprawny numer posesji";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
