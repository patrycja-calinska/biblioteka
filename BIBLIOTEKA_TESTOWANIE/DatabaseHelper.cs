using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BIBLIOTEKA_TESTOWANIE
{
    public static class DatabaseHelper
    {
        // Sprawdza konflikty danych użytkownika
        public static List<string> GetExistingUserConflicts(string connectionString, string login, string pesel, string email)
        {
            List<string> conflicts = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string queryLogin = "SELECT COUNT(*) FROM Uzytkownik WHERE Login_uzytkownika = @login";
                string queryPesel = "SELECT COUNT(*) FROM Uzytkownik WHERE PESEL = @pesel";
                string queryEmail = "SELECT COUNT(*) FROM Uzytkownik WHERE email = @Email";

                using (SqlCommand cmdLogin = new SqlCommand(queryLogin, conn))
                {
                    cmdLogin.Parameters.AddWithValue("@login", login);
                    if ((int)cmdLogin.ExecuteScalar() > 0)
                        conflicts.Add("Użytkownik o podanym loginie już istnieje w systemie. Zapis nie jest możliwy");
                }

                using (SqlCommand cmdPesel = new SqlCommand(queryPesel, conn))
                {
                    cmdPesel.Parameters.AddWithValue("@pesel", pesel);
                    if ((int)cmdPesel.ExecuteScalar() > 0)
                        conflicts.Add("Użytkownik o podanym PESELu już istnieje.");
                }

                using (SqlCommand cmdEmail = new SqlCommand(queryEmail, conn))
                {
                    cmdEmail.Parameters.AddWithValue("@Email", email);
                    if ((int)cmdEmail.ExecuteScalar() > 0)
                        conflicts.Add("Użytkownik o podanym adresie e-mail już istnieje.");
                }
            }

            return conflicts;
        }

        // Dodaje użytkownika i adres w jednej transakcji
        public static bool AddUser(string connectionString,
            string login,
            string imie,
            string nazwisko,
            string pesel,
            string email,
            string telefon,
            string miejscowosc,
            string kodPocztowy,
            string ulica,
            string nrPosesji,
            string nrLokalu,
            DateTime dataUrodzenia,
            int idPlec)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string insertAdresQuery = @"INSERT INTO Adres (Kraj, Miejscowosc, Kod_pocztowy, Ulica, Numer_ulicy, Numer_lokalu)
                                                OUTPUT INSERTED.ID_adres
                                                VALUES (@Kraj, @Miejscowosc, @KodPocztowy, @Ulica, @NrPosesji, @NrLokalu)";
                    int idAdres;

                    using (SqlCommand cmdAdres = new SqlCommand(insertAdresQuery, conn, transaction))
                    {
                        cmdAdres.Parameters.AddWithValue("@Kraj", "Polska");
                        cmdAdres.Parameters.AddWithValue("@Miejscowosc", miejscowosc);
                        cmdAdres.Parameters.AddWithValue("@KodPocztowy", kodPocztowy);
                        cmdAdres.Parameters.AddWithValue("@Ulica", ulica);
                        cmdAdres.Parameters.AddWithValue("@NrPosesji", nrPosesji);
                        cmdAdres.Parameters.AddWithValue("@NrLokalu", nrLokalu);

                        idAdres = (int)cmdAdres.ExecuteScalar();
                    }

                    string insertUserQuery = @"INSERT INTO Uzytkownik (imie, nazwisko, Plec, Data_urodzenia, PESEL,
                                                Numer_telefonu, Login_uzytkownika, Haslo, Email, FK_ID_adres, Czy_zapomniany)
                                               VALUES (@Imie, @Nazwisko, @IDPlec, @DataUrodzenia, @PESEL,
                                                @Telefon, @Login, @Haslo, @Email, @IDAdres, 1)";

                    using (SqlCommand cmdUser = new SqlCommand(insertUserQuery, conn, transaction))
                    {
                        cmdUser.Parameters.AddWithValue("@Imie", imie);
                        cmdUser.Parameters.AddWithValue("@Nazwisko", nazwisko);
                        cmdUser.Parameters.AddWithValue("@IDPlec", idPlec);
                        cmdUser.Parameters.AddWithValue("@DataUrodzenia", dataUrodzenia);
                        cmdUser.Parameters.AddWithValue("@PESEL", pesel);
                        cmdUser.Parameters.AddWithValue("@Telefon", telefon);
                        cmdUser.Parameters.AddWithValue("@Login", login);
                        cmdUser.Parameters.AddWithValue("@Haslo", "HasloDomyslne123");
                        cmdUser.Parameters.AddWithValue("@Email", email);
                        cmdUser.Parameters.AddWithValue("@IDAdres", idAdres);

                        cmdUser.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Błąd SQL:\n" + ex.Message, "Wyjątek SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // Zwraca użytkowników aktywnych (niezapomnianych)
        public static DataTable GetUzytkownicy(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT 
                                    ID_uzytkownik,
                                    imie as Imie,
                                    nazwisko as Nazwisko,
                                    Plec as Płeć,
                                    Data_urodzenia as [Data urodzenia],
                                    PESEL as [Numer PESEL],
                                    Numer_telefonu as [Numer telefonu],
                                    Login_uzytkownika as Login,
                                    email as [Adres E-mail]
                                FROM Uzytkownik
                                WHERE Czy_zapomniany = 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // Aktualizacja danych użytkownika
        public static bool UpdateUser(string connectionString, int id, string imie, string nazwisko, string pesel, string login, string email, string telefon)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE Uzytkownik
                                 SET imie = @Imie,
                                     nazwisko = @Nazwisko,
                                     PESEL = @PESEL,
                                     Login_uzytkownika = @Login,
                                     email = @Email,
                                     Numer_telefonu = @Telefon
                                 WHERE ID_uzytkownik = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Imie", imie);
                    cmd.Parameters.AddWithValue("@Nazwisko", nazwisko);
                    cmd.Parameters.AddWithValue("@PESEL", pesel);
                    cmd.Parameters.AddWithValue("@Login", login);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Telefon", telefon);
                    cmd.Parameters.AddWithValue("@ID", id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public static int GetUserIdByLogin(string connStr, string login)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID_uzytkownik FROM Uzytkownik WHERE Login_uzytkownika = @login", conn);
                cmd.Parameters.AddWithValue("@login", login);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
        public static void PrzypiszUprawnienieUzytkownikowi(string connStr, int userId, int uprawnienieId)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Uzy_upra (FK_ID_uzytkownik, FK_ID_uprawnienie, Czy_dostepne) VALUES (@userId, @upraId, 1)", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@upraId", uprawnienieId);
                cmd.ExecuteNonQuery();
            }
        }


    }
}
