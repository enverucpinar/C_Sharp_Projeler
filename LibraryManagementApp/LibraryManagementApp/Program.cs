namespace LibraryManagementApp;
using Microsoft.Data.SqlClient;

class Program
{
    public static string connectionString = "Server = localhost; Database=DB_ADO_NET_SAMPLE;User Id = sa; Password=154040Eu; TrustServerCertificate= True;";


    static void Main(string[] args)
    {


        while (true)
        {
            Console.WriteLine("1-Add Book\n" +
                "2-List Books\n" +
                "3-Update Books\n" +
                "4-Delete Books\n" +
                "5-Exit");

            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    ListBooks();
                    break;
                case "3":
                    //UpdateBooks();
                    break;
                case "4":
                    //DeleteBooks();
                    break;
                case "5":
                    return;

                default:
                    Console.WriteLine("Lütfen gecerli ifade girin.");
                    break;
            }
        }


        Console.ReadLine();
    }

    public static void AddBook()
    {
        Console.WriteLine("Enter Title of Book: ");
        string title = Console.ReadLine();

        Console.WriteLine("Enter Author of Book: ");
        string author = Console.ReadLine();

        Console.WriteLine("Enter YearPublish of Book: ");
        int year = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter genre of Book: ");
        string genre = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"INSERT INTO Books(Title, Author, YearPublish, Genre) VALUES   (@Title,@Author,@Year,@Genre)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@Genre", genre);

            connection.Open();
            cmd.ExecuteNonQuery();

            connection.Close();
        }


    }

    public static void ListBooks()
    {


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Books";
            SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["BookID"]}, Title: {reader["Title"]} Author: {reader["Author"]}, YearPublish: {reader["YearPublish"]} Genre: {reader["Genre"]}");
            }

            reader.Close();
            connection.Close();
        }
    }

}

