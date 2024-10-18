using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace API_Books
{
	public class DatabaseManager
	{
        private static string ConnectionString = "Server=127.0.0.1;Port=3306;Database=booksdb;Uid=root;password=;";

        private static MySqlConnection Connection = new MySqlConnection(ConnectionString);


        public static MySqlConnection GetConnection()
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
            return Connection;
        }

        public static void CloseConnection()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        public static List<Book> GetBooks()
        {
            MySqlConnection Connection = new MySqlConnection(ConnectionString);

            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            string query = "get_all_books";

            List<Book> books = new List<Book>();

            try
            {

                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = Connection;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;
                   
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book();
                            book.book_id = Convert.ToInt32(reader["IdLibro"]);
                            book.name = reader["Titulo"].ToString();
                            book.author = reader["Autor"].ToString();
                            book.cover = reader["Portada"].ToString();

                            books.Add(book);
                            Console.WriteLine(book.name);

                        }
                    }
                    

                    return books;

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return books;
            }

        }

        public static Book GetBook(int id)
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            string query = $"get_book_by_id";

            Book book = new Book();

            try
            {

                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = Connection;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@bookId", id);
                    command.Parameters["@bookId"].Direction = ParameterDirection.Input;

                    

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            book.book_id = Convert.ToInt32(reader["IdLibro"]);
                            book.name = reader["Titulo"].ToString();
                            book.author = reader["Autor"].ToString();
                            book.cover = reader["Portada"].ToString();


                        }
                    }

                    return book;

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return book;
            }

        }

        public static void UpdateBook(int id, Book book)
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            string query = $"edit_book";


            try
            {

                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = Connection;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters["@id"].Direction = ParameterDirection.Input;

                    command.Parameters.AddWithValue("@nameIn", book.name);
                    command.Parameters["@nameIn"].Direction = ParameterDirection.Input;

                    command.Parameters.AddWithValue("@authorIn", book.author);
                    command.Parameters["@authorIn"].Direction = ParameterDirection.Input;

                    command.Parameters.AddWithValue("@coverIn", book.cover);
                    command.Parameters["@coverIn"].Direction = ParameterDirection.Input;

                    command.ExecuteNonQuery();

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        public static List<Page> GetPages(int id)
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            string query = "get_pages";

            List<Page> pages = new List<Page>();

            try
            {

                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = Connection;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters["@id"].Direction = ParameterDirection.Input;

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Page page = new Page();
                            page.page_id = Convert.ToInt32(reader["IDPagina"]);
                            page.book_id = Convert.ToInt32(reader["IDLibro"]);
                            page.page_no = Convert.ToInt32(reader["NumPagina"]);
                            page.page = reader["Pagina"].ToString();

                            pages.Add(page);


                        }
                    }

                    return pages;

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return pages;
            }

        }

        public static void InsertPage(Page page)
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            string query = $"insert_page";


            try
            {

                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = Connection;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id", page.page_id);
                    command.Parameters["@id"].Direction = ParameterDirection.Input;

                    command.Parameters.AddWithValue("@bookId", page.book_id);
                    command.Parameters["@bookId"].Direction = ParameterDirection.Input;

                    command.Parameters.AddWithValue("@pageNo", page.page_no);
                    command.Parameters["@pageNo"].Direction = ParameterDirection.Input;

                    command.Parameters.AddWithValue("@page", page.page);
                    command.Parameters["@page"].Direction = ParameterDirection.Input;

                    command.ExecuteNonQuery();


                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        public static void DeletePage(int id)
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }

            string query = $"delete_page";

            Book book = new Book();

            try
            {

                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = Connection;
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters["@id"].Direction = ParameterDirection.Input;



                    command.ExecuteNonQuery();

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

    }
}

