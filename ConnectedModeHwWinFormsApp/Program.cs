using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace ConnectedModeHwWinFormsApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string commandText;
            SqlConnection connection = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            commandText = "CREATE DATABASE SalesData";

            SqlCommand command = new SqlCommand(commandText, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("DataBase 'SalesData' is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            //Создайте базу данных «Продажи» (в качестве формата базы данных можно использовать
            //Microsoft Access). Создайте внутри базы данных три таблицы:
            //1) Таблица Покупатели. Столбцы: идентификатор, имя, фамилия;
            //2) Таблица Продавцы. Столбцы: идентификатор, имя, фамилия;
            //3) Таблица Продажи. Столбцы: идентификатор сделки, идентификатор покупателя,
            //идентификатор продавца, сумма сделки, дата сделки.

            //Наполните таблицы данными, задайте правила ссылочной целостности.

            //Реализуйте WinForms приложение, позволяющее пользователю выбрать название таблицы
            //из базы данных sample.mdb(например, с помощью выпадающего списка), в результате
            //выбора таблицы приложение должно отображать содержимое данной таблицы на форму.           

            connection = new SqlConnection("Data Source=localhost; Initial Catalog=SalesData; Integrated Security=SSPI;");

            commandText = "CREATE TABLE Customers (Id int Primary Key, CustomerName nvarchar(2550), CustomerSurname nvarchar(2550));\n";
            commandText += "CREATE TABLE Employees (Id int Primary Key, EmployeeName nvarchar(2550), EmployeeSurname nvarchar(2550));\n";
            commandText += "CREATE TABLE Sales (Id int Primary Key, CustomerId int foreign key references Customers(Id), EmployeeId int foreign key references Employees(Id), TransactionAmount int, TransactionDate date);\n";

            command = new SqlCommand(commandText, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Tables 'Customers, Employees and Sales' is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            var Customers = new[] {
                new { Id = 1, Name = "Virginia", Surname = "Holland" },
                new { Id = 2, Name = "Valentine", Surname = "Kaufman" },
                new { Id = 3, Name = "Dylan", Surname = "Abbott" },
                new { Id = 4, Name = "Kaseem", Surname = "Galloway" },
                new { Id = 5, Name = "Armand", Surname = "Stark" },
                new { Id = 6, Name = "Claire", Surname = "Shelton" },
                new { Id = 7, Name = "Finn", Surname = "Wiggins" },
                new { Id = 8, Name = "Brielle", Surname = "Colon" },
                new { Id = 9, Name = "Kyla", Surname = "Kaufman" },
                new { Id = 10, Name = "Kuame", Surname = "Ellis" },
                new { Id = 11, Name = "Sopoline", Surname = "Curry" },
                new { Id = 12, Name = "Meghan", Surname = "Bernard" },
                new { Id = 13, Name = "Ignacia", Surname = "Larson" },
                new { Id = 14, Name = "Ryan", Surname = "Solomon" },
                new { Id = 15, Name = "Mari", Surname = "Nielsen" },
                new { Id = 16, Name = "Rana", Surname = "Caldwell" },
                new { Id = 17, Name = "Norman", Surname = "Little" },
                new { Id = 18, Name = "Barbara", Surname = "Nunez" },
                new { Id = 19, Name = "Mohammad", Surname = "Ryan" },
                new { Id = 20, Name = "Ralph", Surname = "Bender" },
                new { Id = 21, Name = "Darrel", Surname = "Vega" },
                new { Id = 22, Name = "Beck", Surname = "Copeland" },
                new { Id = 23, Name = "Florence", Surname = "Francis" },
                new { Id = 24, Name = "Elvis", Surname = "Welch" },
                new { Id = 25, Name = "Avye", Surname = "Simpson" },
                new { Id = 26, Name = "Kirby", Surname = "Maxwell" },
                new { Id = 27, Name = "Jonas", Surname = "Miranda" },
                new { Id = 28, Name = "Hilel", Surname = "Vega" },
                new { Id = 29, Name = "Vincent", Surname = "Mccarthy" },
                new { Id = 30, Name = "Noah", Surname = "Wagner" },
                new { Id = 31, Name = "Avye", Surname = "Boone" },
                new { Id = 32, Name = "Amal", Surname = "Emerson" },
                new { Id = 33, Name = "Wesley", Surname = "Guy" },
                new { Id = 34, Name = "Alexandra", Surname = "Dale" },
                new { Id = 35, Name = "Mufutau", Surname = "Peterson" },
                new { Id = 36, Name = "Nayda", Surname = "Dixon" },
                new { Id = 37, Name = "Genevieve", Surname = "Singleton" },
                new { Id = 38, Name = "Ethan", Surname = "Morse" },
                new { Id = 39, Name = "Jasmine", Surname = "Reyes" },
                new { Id = 40, Name = "Wing", Surname = "Bishop" },
                new { Id = 41, Name = "Patricia", Surname = "Pate" },
                new { Id = 42, Name = "Halee", Surname = "Langley" },
                new { Id = 43, Name = "Melinda", Surname = "Curry" },
                new { Id = 44, Name = "Barclay", Surname = "Miranda" },
                new { Id = 45, Name = "Raja", Surname = "Holloway" },
                new { Id = 46, Name = "Nina", Surname = "England" },
                new { Id = 47, Name = "Harriet", Surname = "Madden" },
                new { Id = 48, Name = "Lee", Surname = "Schultz" },
                new { Id = 49, Name = "Kelly", Surname = "Cortez" },
                new { Id = 50, Name = "Caesar", Surname = "Combs" },
                new { Id = 51, Name = "Samuel", Surname = "Shelton" },
                new { Id = 52, Name = "Duncan", Surname = "Terry" },
                new { Id = 53, Name = "Dawn", Surname = "Gibson" },
                new { Id = 54, Name = "Janna", Surname = "Roach" },
                new { Id = 55, Name = "Aubrey", Surname = "Silva" },
                new { Id = 56, Name = "Emi", Surname = "Roberson" },
                new { Id = 57, Name = "Azalia", Surname = "Moran" },
                new { Id = 58, Name = "Philip", Surname = "Preston" },
                new { Id = 59, Name = "Michael", Surname = "Coffey" },
                new { Id = 60, Name = "Eugenia", Surname = "Skinner" },
                new { Id = 61, Name = "Denton", Surname = "Erickson" },
                new { Id = 62, Name = "Xander", Surname = "Townsend" },
                new { Id = 63, Name = "Clinton", Surname = "Ratliff" },
                new { Id = 64, Name = "Vincent", Surname = "Leblanc" },
                new { Id = 65, Name = "William", Surname = "Winters" },
                new { Id = 66, Name = "Scarlett", Surname = "Nieves" },
                new { Id = 67, Name = "Desiree", Surname = "Workman" },
                new { Id = 68, Name = "Kyla", Surname = "Phillips" },
                new { Id = 69, Name = "Gisela", Surname = "Vincent" },
                new { Id = 70, Name = "Cadman", Surname = "Whitney" },
                new { Id = 71, Name = "Darius", Surname = "Massey" },
                new { Id = 72, Name = "Simon", Surname = "Jacobs" },
                new { Id = 73, Name = "Wilma", Surname = "Guthrie" },
                new { Id = 74, Name = "Christian", Surname = "Hopkins" },
                new { Id = 75, Name = "Bruno", Surname = "Ball" },
                new { Id = 76, Name = "Kuame", Surname = "Patel" },
                new { Id = 77, Name = "Jesse", Surname = "Daniels" },
                new { Id = 78, Name = "Kennedy", Surname = "Lane" },
                new { Id = 79, Name = "Trevor", Surname = "Dickson" },
                new { Id = 80, Name = "Jaquelyn", Surname = "Wilkinson" },
                new { Id = 81, Name = "Benjamin", Surname = "Medina" },
                new { Id = 82, Name = "Daphne", Surname = "Higgins" },
                new { Id = 83, Name = "Donovan", Surname = "Bartlett" },
                new { Id = 84, Name = "Hashim", Surname = "Larsen" },
                new { Id = 85, Name = "Alma", Surname = "Snow" },
                new { Id = 86, Name = "Herman", Surname = "Walker" },
                new { Id = 87, Name = "Tasha", Surname = "Ray" },
                new { Id = 88, Name = "Elton", Surname = "Mcmahon" },
                new { Id = 89, Name = "Alexander", Surname = "Horton" },
                new { Id = 90, Name = "Todd", Surname = "Franklin" },
                new { Id = 91, Name = "Jin", Surname = "Landry" },
                new { Id = 92, Name = "Clementine", Surname = "Craig" },
                new { Id = 93, Name = "Montana", Surname = "Robbins" },
                new { Id = 94, Name = "Flynn", Surname = "Perry" },
                new { Id = 95, Name = "Kameko", Surname = "Carroll" },
                new { Id = 96, Name = "Lillith", Surname = "Stafford" },
                new { Id = 97, Name = "Harriet", Surname = "Gordon" },
                new { Id = 98, Name = "Fulton", Surname = "Watkins" },
                new { Id = 99, Name = "Emmanuel", Surname = "Keith" },
                new { Id = 100, Name = "Alec", Surname = "Cain"     }
            };

            var Employees = new[] {
                new { Id = 1, Name = "Lareina", Surname = "Romero" },
                new { Id = 2, Name = "Cruz", Surname = "Webster" },
                new { Id = 3, Name = "Jayme", Surname = "Guzman" },
                new { Id = 4, Name = "Colleen", Surname = "Kinney" },
                new { Id = 5, Name = "Yuli", Surname = "Rios" },
                new { Id = 6, Name = "Simon", Surname = "Bradley" },
                new { Id = 7, Name = "Karyn", Surname = "Boyd" },
                new { Id = 8, Name = "Magee", Surname = "Foley" },
                new { Id = 9, Name = "Cain", Surname = "Evans" },
                new { Id = 10, Name = "Elvis", Surname = "Copeland" },
                new { Id = 11, Name = "Orli", Surname = "Knapp" },
                new { Id = 12, Name = "Nissim", Surname = "Gentry" },
                new { Id = 13, Name = "Claudia", Surname = "Boyd" },
                new { Id = 14, Name = "Jessica", Surname = "Mccray" },
                new { Id = 15, Name = "Guinevere", Surname = "Sellers" },
                new { Id = 16, Name = "Keely", Surname = "Wallace" },
                new { Id = 17, Name = "Theodore", Surname = "Kent" },
                new { Id = 18, Name = "Neil", Surname = "Blevins" },
                new { Id = 19, Name = "Casey", Surname = "Mckinney" },
                new { Id = 20, Name = "Rhiannon", Surname = "Albert" },
                new { Id = 21, Name = "Priscilla", Surname = "Brooks" },
                new { Id = 22, Name = "Fleur", Surname = "Stone" },
                new { Id = 23, Name = "Jeanette", Surname = "Perez" },
                new { Id = 24, Name = "Brielle", Surname = "Booker" },
                new { Id = 25, Name = "Lana", Surname = "Acevedo" },
                new { Id = 26, Name = "Latifah", Surname = "Landry" },
                new { Id = 27, Name = "Pearl", Surname = "Randolph" },
                new { Id = 28, Name = "Howard", Surname = "Leonard" },
                new { Id = 29, Name = "Kay", Surname = "Contreras" },
                new { Id = 30, Name = "Lucian", Surname = "Oconnor" },
                new { Id = 31, Name = "Emery", Surname = "Haynes" },
                new { Id = 32, Name = "Holmes", Surname = "Morse" },
                new { Id = 33, Name = "Forrest", Surname = "Hawkins" },
                new { Id = 34, Name = "Noel", Surname = "Barr" },
                new { Id = 35, Name = "Rhea", Surname = "Suarez" },
                new { Id = 36, Name = "Drake", Surname = "Hebert" },
                new { Id = 37, Name = "Colorado", Surname = "Wilcox" },
                new { Id = 38, Name = "Brooke", Surname = "Mason" },
                new { Id = 39, Name = "Neil", Surname = "Dodson" },
                new { Id = 40, Name = "Aaron", Surname = "Lyons" },
                new { Id = 41, Name = "Wang", Surname = "Jefferson" },
                new { Id = 42, Name = "Perry", Surname = "Rich" },
                new { Id = 43, Name = "Todd", Surname = "Keller" },
                new { Id = 44, Name = "Constance", Surname = "Boone" },
                new { Id = 45, Name = "Shannon", Surname = "Berry" },
                new { Id = 46, Name = "Elliott", Surname = "Rosales" },
                new { Id = 47, Name = "Bryar", Surname = "Velez" },
                new { Id = 48, Name = "Martha", Surname = "Robles" },
                new { Id = 49, Name = "Yuli", Surname = "Dorsey" },
                new { Id = 50, Name = "Arsenio", Surname = "Ball" },
                new { Id = 51, Name = "Carl", Surname = "Young" },
                new { Id = 52, Name = "Harlan", Surname = "Sanders" },
                new { Id = 53, Name = "Austin", Surname = "Palmer" },
                new { Id = 54, Name = "Uriel", Surname = "Yang" },
                new { Id = 55, Name = "Fulton", Surname = "Sloan" },
                new { Id = 56, Name = "Dylan", Surname = "Smith" },
                new { Id = 57, Name = "Shelly", Surname = "Ballard" },
                new { Id = 58, Name = "Merrill", Surname = "Lloyd" },
                new { Id = 59, Name = "Jenette", Surname = "Wiggins" },
                new { Id = 60, Name = "Carissa", Surname = "Atkins" },
                new { Id = 61, Name = "Whitney", Surname = "Herrera" },
                new { Id = 62, Name = "Trevor", Surname = "Riley" },
                new { Id = 63, Name = "Jasper", Surname = "Horton" },
                new { Id = 64, Name = "Camille", Surname = "Mckee" },
                new { Id = 65, Name = "Ruth", Surname = "Carney" },
                new { Id = 66, Name = "Arden", Surname = "Gallegos" },
                new { Id = 67, Name = "Tanek", Surname = "Shepherd" },
                new { Id = 68, Name = "Blair", Surname = "Walter" },
                new { Id = 69, Name = "Fredericka", Surname = "Burks" },
                new { Id = 70, Name = "Sade", Surname = "Lancaster" },
                new { Id = 71, Name = "Adara", Surname = "Bush" },
                new { Id = 72, Name = "Yoshi", Surname = "Roberson" },
                new { Id = 73, Name = "Kevyn", Surname = "Davenport" },
                new { Id = 74, Name = "Sophia", Surname = "Curry" },
                new { Id = 75, Name = "Galena", Surname = "Weber" },
                new { Id = 76, Name = "Amethyst", Surname = "Daniels" },
                new { Id = 77, Name = "Fredericka", Surname = "Yates" },
                new { Id = 78, Name = "Briar", Surname = "Donovan" },
                new { Id = 79, Name = "Malcolm", Surname = "Navarro" },
                new { Id = 80, Name = "Madonna", Surname = "Bradshaw" },
                new { Id = 81, Name = "Henry", Surname = "Kent" },
                new { Id = 82, Name = "Iola", Surname = "Acevedo" },
                new { Id = 83, Name = "Karly", Surname = "Roberts" },
                new { Id = 84, Name = "Benjamin", Surname = "Valenzuela" },
                new { Id = 85, Name = "Tiger", Surname = "England" },
                new { Id = 86, Name = "Dakota", Surname = "Bradshaw" },
                new { Id = 87, Name = "Baker", Surname = "Ray" },
                new { Id = 88, Name = "Yasir", Surname = "Copeland" },
                new { Id = 89, Name = "Florence", Surname = "Finley" },
                new { Id = 90, Name = "Jamalia", Surname = "Hayden" },
                new { Id = 91, Name = "Latifah", Surname = "Blanchard" },
                new { Id = 92, Name = "Nathan", Surname = "Cortez" },
                new { Id = 93, Name = "Lucius", Surname = "Rosa" },
                new { Id = 94, Name = "Riley", Surname = "Flowers" },
                new { Id = 95, Name = "Pearl", Surname = "Woodard" },
                new { Id = 96, Name = "Clementine", Surname = "Stout" },
                new { Id = 97, Name = "Ronan", Surname = "Maddox" },
                new { Id = 98, Name = "Emerson", Surname = "Day" },
                new { Id = 99, Name = "Clio", Surname = "Gallegos" },
                new { Id = 100, Name = "Kaden", Surname = "Norton" }
            };

            var Sales = new[] {
                new { Id = 1, CustomerId = 83, EmployeeId = 80, TransactionAmount = 11552, TransactionDate = DateTime.ParseExact("22/01/2010", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 2, CustomerId = 21, EmployeeId = 35, TransactionAmount = 58633, TransactionDate = DateTime.ParseExact("20/01/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 3, CustomerId = 53, EmployeeId = 95, TransactionAmount = 79571, TransactionDate = DateTime.ParseExact("24/12/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 4, CustomerId = 18, EmployeeId = 49, TransactionAmount = 12151, TransactionDate = DateTime.ParseExact("18/03/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 5, CustomerId = 94, EmployeeId = 59, TransactionAmount = 89876, TransactionDate = DateTime.ParseExact("16/01/2014", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 6, CustomerId = 74, EmployeeId = 5, TransactionAmount = 79473, TransactionDate = DateTime.ParseExact("19/02/2003", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 7, CustomerId = 62, EmployeeId = 89, TransactionAmount = 84567, TransactionDate = DateTime.ParseExact("02/03/2003", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 8, CustomerId = 48, EmployeeId = 41, TransactionAmount = 15694, TransactionDate = DateTime.ParseExact("31/10/2007", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 9, CustomerId = 72, EmployeeId = 19, TransactionAmount = 90405, TransactionDate = DateTime.ParseExact("27/06/2006", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 10, CustomerId = 31, EmployeeId = 27, TransactionAmount = 83228, TransactionDate = DateTime.ParseExact("13/10/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 11, CustomerId = 5, EmployeeId = 63, TransactionAmount = 55777, TransactionDate = DateTime.ParseExact("06/06/2014", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 12, CustomerId = 59, EmployeeId = 40, TransactionAmount = 21962, TransactionDate = DateTime.ParseExact("24/09/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 13, CustomerId = 57, EmployeeId = 96, TransactionAmount = 8206, TransactionDate = DateTime.ParseExact("17/10/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 14, CustomerId = 23, EmployeeId = 59, TransactionAmount = 24832, TransactionDate = DateTime.ParseExact("17/09/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 15, CustomerId = 13, EmployeeId = 50, TransactionAmount = 235, TransactionDate = DateTime.ParseExact("23/12/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 16, CustomerId = 54, EmployeeId = 53, TransactionAmount = 69865, TransactionDate = DateTime.ParseExact("22/01/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 17, CustomerId = 56, EmployeeId = 50, TransactionAmount = 17854, TransactionDate = DateTime.ParseExact("10/12/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 18, CustomerId = 7, EmployeeId = 31, TransactionAmount = 75988, TransactionDate = DateTime.ParseExact("30/10/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 19, CustomerId = 14, EmployeeId = 92, TransactionAmount = 18370, TransactionDate = DateTime.ParseExact("13/06/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 20, CustomerId = 11, EmployeeId = 87, TransactionAmount = 85323, TransactionDate = DateTime.ParseExact("08/01/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 21, CustomerId = 94, EmployeeId = 59, TransactionAmount = 13689, TransactionDate = DateTime.ParseExact("28/04/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 22, CustomerId = 47, EmployeeId = 97, TransactionAmount = 6935, TransactionDate = DateTime.ParseExact("14/09/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 23, CustomerId = 25, EmployeeId = 67, TransactionAmount = 39378, TransactionDate = DateTime.ParseExact("18/01/2007", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 24, CustomerId = 5, EmployeeId = 21, TransactionAmount = 59491, TransactionDate = DateTime.ParseExact("17/06/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 25, CustomerId = 38, EmployeeId = 11, TransactionAmount = 48924, TransactionDate = DateTime.ParseExact("23/09/2007", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 26, CustomerId = 5, EmployeeId = 93, TransactionAmount = 52112, TransactionDate = DateTime.ParseExact("12/06/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 27, CustomerId = 66, EmployeeId = 67, TransactionAmount = 55121, TransactionDate = DateTime.ParseExact("16/10/2003", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 28, CustomerId = 38, EmployeeId = 93, TransactionAmount = 66211, TransactionDate = DateTime.ParseExact("02/11/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 29, CustomerId = 26, EmployeeId = 93, TransactionAmount = 2453, TransactionDate = DateTime.ParseExact("24/02/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 30, CustomerId = 48, EmployeeId = 97, TransactionAmount = 57148, TransactionDate = DateTime.ParseExact("18/03/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 31, CustomerId = 94, EmployeeId = 50, TransactionAmount = 39970, TransactionDate = DateTime.ParseExact("21/03/2010", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 32, CustomerId = 100, EmployeeId = 20, TransactionAmount = 32255, TransactionDate = DateTime.ParseExact("06/06/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 33, CustomerId = 54, EmployeeId = 4, TransactionAmount = 10094, TransactionDate = DateTime.ParseExact("08/06/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 34, CustomerId = 56, EmployeeId = 29, TransactionAmount = 83836, TransactionDate = DateTime.ParseExact("09/07/2003", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 35, CustomerId = 81, EmployeeId = 74, TransactionAmount = 1776, TransactionDate = DateTime.ParseExact("27/04/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 36, CustomerId = 42, EmployeeId = 44, TransactionAmount = 9210, TransactionDate = DateTime.ParseExact("17/06/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 37, CustomerId = 60, EmployeeId = 3, TransactionAmount = 23120, TransactionDate = DateTime.ParseExact("28/10/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 38, CustomerId = 36, EmployeeId = 67, TransactionAmount = 79732, TransactionDate = DateTime.ParseExact("07/05/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 39, CustomerId = 21, EmployeeId = 62, TransactionAmount = 19581, TransactionDate = DateTime.ParseExact("04/10/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 40, CustomerId = 57, EmployeeId = 14, TransactionAmount = 45164, TransactionDate = DateTime.ParseExact("29/09/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 41, CustomerId = 16, EmployeeId = 63, TransactionAmount = 56999, TransactionDate = DateTime.ParseExact("24/02/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 42, CustomerId = 13, EmployeeId = 78, TransactionAmount = 75527, TransactionDate = DateTime.ParseExact("28/02/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 43, CustomerId = 1, EmployeeId = 8, TransactionAmount = 4690, TransactionDate = DateTime.ParseExact("15/06/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 44, CustomerId = 62, EmployeeId = 90, TransactionAmount = 8006, TransactionDate = DateTime.ParseExact("11/03/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 45, CustomerId = 93, EmployeeId = 88, TransactionAmount = 75410, TransactionDate = DateTime.ParseExact("11/12/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 46, CustomerId = 55, EmployeeId = 60, TransactionAmount = 6812, TransactionDate = DateTime.ParseExact("09/03/2014", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 47, CustomerId = 41, EmployeeId = 20, TransactionAmount = 50268, TransactionDate = DateTime.ParseExact("15/05/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 48, CustomerId = 60, EmployeeId = 61, TransactionAmount = 68558, TransactionDate = DateTime.ParseExact("21/01/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 49, CustomerId = 36, EmployeeId = 37, TransactionAmount = 18582, TransactionDate = DateTime.ParseExact("29/03/2006", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 50, CustomerId = 92, EmployeeId = 25, TransactionAmount = 60601, TransactionDate = DateTime.ParseExact("06/06/2010", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 51, CustomerId = 22, EmployeeId = 58, TransactionAmount = 37406, TransactionDate = DateTime.ParseExact("26/10/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 52, CustomerId = 15, EmployeeId = 45, TransactionAmount = 92440, TransactionDate = DateTime.ParseExact("12/05/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 53, CustomerId = 90, EmployeeId = 49, TransactionAmount = 35813, TransactionDate = DateTime.ParseExact("09/05/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 54, CustomerId = 57, EmployeeId = 75, TransactionAmount = 14869, TransactionDate = DateTime.ParseExact("20/09/2003", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 55, CustomerId = 3, EmployeeId = 15, TransactionAmount = 19045, TransactionDate = DateTime.ParseExact("15/02/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 56, CustomerId = 55, EmployeeId = 56, TransactionAmount = 30433, TransactionDate = DateTime.ParseExact("29/03/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 57, CustomerId = 2, EmployeeId = 32, TransactionAmount = 63969, TransactionDate = DateTime.ParseExact("15/06/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 58, CustomerId = 38, EmployeeId = 80, TransactionAmount = 6446, TransactionDate = DateTime.ParseExact("28/01/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 59, CustomerId = 84, EmployeeId = 35, TransactionAmount = 67534, TransactionDate = DateTime.ParseExact("10/11/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 60, CustomerId = 80, EmployeeId = 84, TransactionAmount = 96970, TransactionDate = DateTime.ParseExact("20/04/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 61, CustomerId = 60, EmployeeId = 60, TransactionAmount = 13344, TransactionDate = DateTime.ParseExact("25/03/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 62, CustomerId = 90, EmployeeId = 11, TransactionAmount = 71607, TransactionDate = DateTime.ParseExact("05/09/2006", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 63, CustomerId = 96, EmployeeId = 11, TransactionAmount = 59770, TransactionDate = DateTime.ParseExact("06/10/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 64, CustomerId = 68, EmployeeId = 38, TransactionAmount = 16139, TransactionDate = DateTime.ParseExact("20/05/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 65, CustomerId = 55, EmployeeId = 54, TransactionAmount = 79195, TransactionDate = DateTime.ParseExact("20/09/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 66, CustomerId = 96, EmployeeId = 47, TransactionAmount = 4074, TransactionDate = DateTime.ParseExact("31/05/2007", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 67, CustomerId = 37, EmployeeId = 48, TransactionAmount = 20855, TransactionDate = DateTime.ParseExact("27/04/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 68, CustomerId = 24, EmployeeId = 91, TransactionAmount = 89239, TransactionDate = DateTime.ParseExact("10/05/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 69, CustomerId = 17, EmployeeId = 22, TransactionAmount = 45775, TransactionDate = DateTime.ParseExact("01/08/2014", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 70, CustomerId = 69, EmployeeId = 26, TransactionAmount = 4666, TransactionDate = DateTime.ParseExact("26/07/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 71, CustomerId = 23, EmployeeId = 96, TransactionAmount = 71352, TransactionDate = DateTime.ParseExact("11/09/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 72, CustomerId = 38, EmployeeId = 10, TransactionAmount = 87162, TransactionDate = DateTime.ParseExact("20/09/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 73, CustomerId = 62, EmployeeId = 64, TransactionAmount = 33383, TransactionDate = DateTime.ParseExact("02/09/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 74, CustomerId = 25, EmployeeId = 57, TransactionAmount = 4984, TransactionDate = DateTime.ParseExact("22/06/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 75, CustomerId = 23, EmployeeId = 91, TransactionAmount = 32543, TransactionDate = DateTime.ParseExact("28/08/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 76, CustomerId = 1, EmployeeId = 82, TransactionAmount = 93915, TransactionDate = DateTime.ParseExact("24/08/2007", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 77, CustomerId = 62, EmployeeId = 59, TransactionAmount = 56115, TransactionDate = DateTime.ParseExact("23/10/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 78, CustomerId = 37, EmployeeId = 59, TransactionAmount = 96335, TransactionDate = DateTime.ParseExact("26/09/2010", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 79, CustomerId = 77, EmployeeId = 8, TransactionAmount = 12088, TransactionDate = DateTime.ParseExact("03/09/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 80, CustomerId = 38, EmployeeId = 66, TransactionAmount = 36969, TransactionDate = DateTime.ParseExact("16/11/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 81, CustomerId = 44, EmployeeId = 63, TransactionAmount = 29513, TransactionDate = DateTime.ParseExact("29/12/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 82, CustomerId = 68, EmployeeId = 86, TransactionAmount = 84384, TransactionDate = DateTime.ParseExact("22/01/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 83, CustomerId = 90, EmployeeId = 3, TransactionAmount = 85210, TransactionDate = DateTime.ParseExact("14/10/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 84, CustomerId = 99, EmployeeId = 34, TransactionAmount = 16776, TransactionDate = DateTime.ParseExact("20/08/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 85, CustomerId = 7, EmployeeId = 63, TransactionAmount = 9906, TransactionDate = DateTime.ParseExact("21/02/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 86, CustomerId = 93, EmployeeId = 97, TransactionAmount = 53864, TransactionDate = DateTime.ParseExact("24/07/2014", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 87, CustomerId = 11, EmployeeId = 50, TransactionAmount = 60900, TransactionDate = DateTime.ParseExact("28/04/2014", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 88, CustomerId = 68, EmployeeId = 17, TransactionAmount = 91143, TransactionDate = DateTime.ParseExact("23/12/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 89, CustomerId = 41, EmployeeId = 70, TransactionAmount = 70863, TransactionDate = DateTime.ParseExact("24/06/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 90, CustomerId = 3, EmployeeId = 76, TransactionAmount = 27604, TransactionDate = DateTime.ParseExact("07/07/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 91, CustomerId = 73, EmployeeId = 52, TransactionAmount = 66375, TransactionDate = DateTime.ParseExact("12/06/2005", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 92, CustomerId = 81, EmployeeId = 16, TransactionAmount = 14191, TransactionDate = DateTime.ParseExact("31/01/2007", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 93, CustomerId = 2, EmployeeId = 48, TransactionAmount = 51261, TransactionDate = DateTime.ParseExact("04/01/2006", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 94, CustomerId = 39, EmployeeId = 67, TransactionAmount = 70239, TransactionDate = DateTime.ParseExact("17/09/2003", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 95, CustomerId = 51, EmployeeId = 29, TransactionAmount = 35671, TransactionDate = DateTime.ParseExact("09/12/2008", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 96, CustomerId = 54, EmployeeId = 77, TransactionAmount = 89844, TransactionDate = DateTime.ParseExact("31/08/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 97, CustomerId = 91, EmployeeId = 4, TransactionAmount = 50439, TransactionDate = DateTime.ParseExact("24/10/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 98, CustomerId = 72, EmployeeId = 95, TransactionAmount = 15904, TransactionDate = DateTime.ParseExact("02/01/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 99, CustomerId = 27, EmployeeId = 30, TransactionAmount = 30182, TransactionDate = DateTime.ParseExact("07/10/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
                new { Id = 100, CustomerId = 55, EmployeeId = 83, TransactionAmount = 3594, TransactionDate = DateTime.ParseExact("09/08/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture) }
            };

            commandText = "";
            connection = new SqlConnection("Data Source=localhost; Initial Catalog=SalesData; Integrated Security=SSPI;");

            foreach (var Customer in Customers)
            {
                commandText += $"INSERT into Customers values ({Customer.Id}, '{Customer.Name}', '{Customer.Surname}');";
            }

            foreach (var Employee in Employees)
            {
                commandText += $"INSERT into Employees values ({Employee.Id}, '{Employee.Name}', '{Employee.Surname}');";
            }

            foreach (var Sale in Sales)
            {
                commandText += $"INSERT into Sales values ({Sale.Id}, {Sale.CustomerId}, {Sale.EmployeeId}, {Sale.TransactionAmount}, '{Sale.TransactionDate}');";
            }

            command = new SqlCommand(commandText, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Data to the tables 'Customers, Employees and Sales' is Successfully Inserted", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
