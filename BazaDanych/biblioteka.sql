Create database BibliotekaBaza
USE [BibliotekaBaza]

CREATE TABLE Wydawnictwo(
ID_wydawnictwo INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Nazwa VARCHAR(255) NOT NULL,
Data_zalozenia DATE NOT NULL);

INSERT INTO Wydawnictwo(Nazwa, Data_zalozenia) VALUES
('Wydawnictwo1', '01-01-2020');

CREATE TABLE Gatunek(
ID_gatunek INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Nazwa VARCHAR(255) NOT NULL);

INSERT INTO Gatunek(Nazwa) VALUES
('Science fiction');

CREATE TABLE Status_ksiazki(
ID_status INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Info_status VARCHAR(20) NOT NULL);

INSERT INTO Status_ksiazki(Info_status) VALUES
('Dostêpna'),
('Niedostêpna');

CREATE TABLE Plec(
  ID_plec INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Nazwa NVARCHAR(1) NOT NULL) ;

  INSERT INTO PLEC(Nazwa) VALUES
  ('K'),
  ('M');

CREATE TABLE Autor(
ID_autor INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Imie_autor VARCHAR(50) NOT NULL,
Nazwisko_autor VARCHAR(100) NOT NULL,
Kraj_pochodzenia VARCHAR(200));

INSERT INTO Autor(Imie_autor, Nazwisko_autor, Kraj_pochodzenia) VALUES
('Jan', 'Brzechwa', 'Polska');

CREATE TABLE Uprawnienia(
ID_uprawnienia INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Nazwa NVARCHAR(255) NOT NULL UNIQUE);

INSERT INTO Uprawnienia(Nazwa) VALUES
('Dodawanie nowych uzytkowników'),
('Edycja danych u¿ytkownika'),
('Zapominanie u¿ytkownika'),
('Wyœwietlanie listy u¿ytkowników'),
('Wyszukiwanie u¿ytkowników'),
('Wyszukiwanie zapomnianych u¿ytkowników'),
('Podgl¹d danych u¿ytkownika'),
('Przegl¹d listy dostêpnych uprawnieñ'),
('Nadawanie uprawnieñ u¿ytkownikom'),
('Przegl¹d u¿ytkowników o danym uprawnieniu'),
('Zmiana has³a u¿ytkownika'),
('Automatyczne generowanie has³a'),
('Mo¿liwoœæ logowania do systemu'),
('Mo¿liwoœæ wylogowania'),
('Rejestrowanie nowych ksi¹¿ek'),
('Przegl¹danie listy ksi¹¿ek'),
('Podgl¹d szczegó³owych informacji o ksi¹¿ce'),
('Rejestrowanie wypo¿yczenia ksi¹¿ki'),
('Przed³u¿anie wypo¿yczenia'),
('Rejestrowanie zwrotu ksi¹¿ki'),
('Przegl¹d listy rejestracji ksi¹¿ek'),
('Przegl¹danie listy dostêpnych ksi¹¿ek'),
('Przegl¹d listy wypo¿yczeñ'),
('Odzyskiwanie has³a'),
('Ustawienie nowego has³a po odzyskaniu');



CREATE TABLE Adres(
ID_adres INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Kraj VARCHAR(255) NOT NULL,
Miejscowosc VARCHAR(255) NOT NULL,
Kod_pocztowy VARCHAR(6) NOT NULL,
Ulica VARCHAR(255) NOT NULL,
Numer_ulicy Varchar(10) NOT NULL,
Numer_lokalu VARCHAR(10));

INSERT INTO Adres(Kraj,Miejscowosc,Kod_pocztowy,Ulica,Numer_ulicy,Numer_lokalu) VALUES
('Polska', '£ódŸ', '91-344','Mackiewicza', '44', null),
('Polska', '£ódŸ', '91-434','Adama', '2', '43'),
('Polska', '£ódŸ', '91-566','Kryszta³owa', '42', '11'),
('Polska', '£ódŸ', '91-666','£ódzka', '14', null),
('Polska', '£ódŸ', '91-377','Mazurkiewicza', '9', null),
('Polska', '£ódŸ', '91-986','Inflacka', '4', '5');














CREATE TABLE Ksiazka(
ID_ksiazka INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Tytul VARCHAR(255) NOT NULL,
Rok_wydania DATE NOT NULL,
FK_ID_wydawnictwo INT NOT NULL FOREIGN KEY REFERENCES Wydawnictwo(ID_wydawnictwo),
Data_zakupu DATE NOT NULL,
Gatunek INT NOT NULL FOREIGN KEY REFERENCES Gatunek(ID_gatunek),
Liczba_stron INT NOT NULL,
Liczba_sztuk INT NOT NULL,
Cena MONEY NOT NULL,
Opis TEXT NOT NULL,
FK_ID_status INT NOT NULL FOREIGN KEY REFERENCES Status_ksiazki(ID_status));

INSERT INTO Ksiazka(Tytul,Rok_wydania,FK_ID_wydawnictwo,Data_zakupu,Gatunek, Liczba_stron, Liczba_sztuk,Cena, Opis, FK_ID_status) values
('Tytul123', '1908', '1', '01-01-2020', '1','100','5','50','fajna','1');

CREATE TABLE Ksiazka_autor(
ID_ksiazka_autor INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
FK_ID_autor INT NOT NULL FOREIGN KEY REFERENCES Autor(ID_autor),
FK_ID_ksiazka INT NOT NULL FOREIGN KEY REFERENCES Ksiazka(ID_ksiazka));

insert into Ksiazka_autor(FK_ID_ksiazka,FK_ID_autor) values
('1','1');




CREATE TABLE Uzytkownik(
ID_uzytkownik INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Imie VARCHAR(100) NOT NULL,
Nazwisko VARCHAR(200) NOT NULL,
Plec INT Not NULL FOREIGN KEY REFERENCES Plec(ID_Plec),
Data_urodzenia DATE NOT NULL,
PESEL VARCHAR(11) UNIQUE NOT NULL,
Numer_telefonu VARCHAR(9) NOT NULL,
Login_uzytkownika VARCHAR(100) UNIQUE NOT NULL,
Haslo VARCHAR(100) NOT NULL,
Email VARCHAR(255) NOT NULL UNIQUE CHECK (email LIKE '%_@_%._%'),
FK_ID_adres INT NOT NULL FOREIGN KEY REFERENCES Adres(ID_Adres),
Czy_zapomniany BIT NOT NULL DEFAULT 0 -- Domy?lnie uzytkownik jest nieaktywny (0).
);

AlTER TABLE Uzytkownik ADD Zablokowany BIT DEFAULT 0;

ALTER TABLE Uzytkownik ADD KoniecBlokady DATETIME NULL;

insert into Uzytkownik (Imie,Nazwisko,Plec, Data_urodzenia,PESEL,Numer_telefonu, Login_uzytkownika,Haslo, Email ,FK_ID_adres,Czy_zapomniany) Values
('Admin','Admin','2', '01-01-2000', '00210127618', '234567890','Admin1','Admin!23','admin@gmail.com', '1','1'),
('Adam','JuŸkowiak','2', '02-09-1992', '92020999358', '392000456','Adam1','Adam!23','adam1@gmail.com', '2','1'),
('Marianna','Ci¹ga³a','1', '06-10-1999', '99061066423', '221693418','Marianna1','Marianna!23','marianna1@gmail.com', '3','1'),
('Lech','Malinowski','2', '08-17-2004', '04281892952', '929696112','Lech1','Lech!23','Lech1@gmail.com', '4','1'),
('Jakub','Fr¹czewski','2', '03-21-2003', '03232192516', '908742854','Jakub1','Jakub!23','Jakub1@gmail.com', '5','1'),
('Marta','Agawa','1', '07-05-1995', '95070527889', '131356998','Marta1','Marta!23','Marta1@gmail.com', '6','1');

CREATE TABLE Poprzednie_hasla (
ID_phaslo INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
FK_ID_uzytkownik INT NOT NULL FOREIGN KEY REFERENCES Uzytkownik(ID_uzytkownik),
Phaslo Varchar(255) NOT NULL,
data_zmiany DATETIME NOT NULL DEFAULT GETDATE());

CREATE TABLE ProbyLogowania(
ID_proba INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
FK_ID_uzytkownik INT NOT NULL FOREIGN KEY REFERENCES Uzytkownik(ID_uzytkownik),
Data_proby DATETIME NOT NULL,
Czy_poprawna BIT);









CREATE TABLE Rejestracja(
ID_Rejestr INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
FK_ID_ksiazka INT NOT NULL FOREIGN KEY REFERENCES Ksiazka(ID_ksiazka),
FK_ID_uzytkownik INT NOT NULL FOREIGN KEY REFERENCES Uzytkownik(ID_Uzytkownik),
Data_Rejestracji DATETIME NOT NULL DEFAULT GETDATE());
insert into Rejestracja(FK_ID_ksiazka,FK_ID_uzytkownik) values
('1','1');


CREATE TABLE Zapominany(
ID_zapominany INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
FK_ID_uzytkownik INT NOT NULL FOREIGN KEY REFERENCES Uzytkownik(ID_Uzytkownik),
Data_zapomnienia DATETIME NOT NULL DEFAULT GETDATE(),
Zglaszacz INT NOT NULL FOREIGN KEY REFERENCES Uzytkownik(ID_Uzytkownik));


CREATE TABLE Uzy_upra(
ID_uzy_upra INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
FK_ID_uzytkownik INT NOT NULL FOREIGN KEY REFERENCES Uzytkownik(ID_uzytkownik),
FK_ID_uprawnienie INT NOT NULL FOREIGN KEY REFERENCES Uprawnienia(ID_uprawnienia),
Czy_dostepne BIT NOT NULL DEFAULT 0);

INSERT INTO Uzy_upra(FK_ID_uzytkownik,FK_ID_uprawnienie, Czy_dostepne) VALUES
('1','1','1'),
('1','2','1'),
('1','3','1'),
('1','4','1'),
('1','5','1'),
('1','6','1'),
('1','7','1'),
('1','8','1'),
('1','9','1'),
('1','10','1'),
('1','11','1'),
('1','12','1'),
('1','13','1'),
('1','14','1'),
('1','15','1'),
('1','16','1'),
('1','17','1'),
('1','18','1'),
('1','19','1'),
('1','20','1'),
('1','21','1'),
('1','22','1'),
('1','23','1'),
('1','24','1'),
('1','25','1'),
('2','1','1'),
('2','2','1'),
('2','3','1'),
('2','4','1'),
('2','5','1'),
('2','6','1'),
('2','7','1'),
('2','8','1'),
('2','9','1'),
('2','10','1'),
('2','11','1'),
('2','12','1'),
('2','13','1'),
('2','14','1'),
('2','15','0'),
('2','16','0'),
('2','17','0'),
('2','18','0'),
('2','19','0'),
('2','20','0'),
('2','21','0'),
('2','22','0'),
('2','23','0'),
('2','24','0'),
('2','25','0'),
('3','1','0'),
('3','2','0'),
('3','3','0'),
('3','4','0'),
('3','5','0'),
('3','6','0'),
('3','7','0'),
('3','8','0'),
('3','9','0'),
('3','10','0'),
('3','11','0'),
('3','12','0'),
('3','13','1'),
('3','14','1'),
('3','15','1'),
('3','16','1'),
('3','17','1'),
('3','18','1'),
('3','19','1'),
('3','20','1'),
('3','21','0'),
('3','22','0'),
('3','23','0'),
('3','24','0'),
('3','25','0'),
('4','1','0'),
('4','2','0'),
('4','3','0'),
('4','4','0'),
('4','5','0'),
('4','6','0'),
('4','7','0'),
('4','8','0'),
('4','9','0'),
('4','10','0'),
('4','11','0'),
('4','12','0'),
('4','13','1'),
('4','14','1'),
('4','15','0'),
('4','16','0'),
('4','17','0'),
('4','18','0'),
('4','19','0'),
('4','20','0'),
('4','21','1'),
('4','22','1'),
('4','23','1'),
('4','24','0'),
('4','25','0'),
('5','1','0'),
('5','2','0'),
('5','3','0'),
('5','4','0'),
('5','5','0'),
('5','6','0'),
('5','7','0'),
('5','8','0'),
('5','9','0'),
('5','10','0'),
('5','11','0'),
('5','12','0'),
('5','13','1'),
('5','14','1'),
('5','15','0'),
('5','16','0'),
('5','17','0'),
('5','18','0'),
('5','19','0'),
('5','20','0'),
('5','21','0'),
('5','22','0'),
('5','23','0'),
('5','24','1'),
('5','25','1'),
('6','1','0'),
('6','2','0'),
('6','3','0'),
('6','4','0'),
('6','5','0'),
('6','6','0'),
('6','7','0'),
('6','8','0'),
('6','9','0'),
('6','10','0'),
('6','11','0'),
('6','12','0'),
('6','13','0'),
('6','14','0'),
('6','15','0'),
('6','16','0'),
('6','17','0'),
('6','18','0'),
('6','19','0'),
('6','20','0'),
('6','21','0'),
('6','22','0'),
('6','23','0'),
('6','24','0'),
('6','25','0');


Select * from Uzytkownik