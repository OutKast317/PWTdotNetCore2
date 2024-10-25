using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTdotNetCore.ConsoleApp
{
    public class AdoDotNetExample2
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=PWTDB;User ID=sa;Password=georgeedwards1735";
        public void Read()
        {
            Console.WriteLine("Connection string: " + _connectionString);
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("Connection opening....");
            connection.Open();
            Console.WriteLine("Connection opened.");

            //open nk close kyrr twinn query build ya ml 

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog]";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["BlogId"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
                //    Console.WriteLine(dr["DeleteFlag"]);
            }

            Console.WriteLine("Connection closing....");

            connection.Close();

            Console.WriteLine("Connection closed.");

        }

        public void Create()
        {
            Console.WriteLine("Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            string content = Console.ReadLine();



            SqlConnection connection = new SqlConnection(_connectionString);


            //Console.WriteLine("Connection opening....");
            connection.Open();
            //Console.WriteLine("Connection opened.");




            //string queryInsert = $@"INSERT INTO [dbo].[Tbl_Blog]
            //           ([BlogTitle]
            //           ,[BlogAuthor]
            //           ,[BlogContent]
            //           ,[DeleteFlag])
            //     VALUES
            //           ('{title}'
            //		   ,'{author}'
            //           ,'{content}'
            //           ,0)";


            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
		   ,@BlogAuthor
           ,@BlogContent
           ,0)";



            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);


            //SqlDataAdapter adapter = new SqlDataAdapter(cmd2);

            //DataTable dt = new DataTable();

            //adapter.Fill(dt);

            int result = cmd.ExecuteNonQuery();

            //Console.WriteLine("Connection closing....");

            connection.Close();

            Console.WriteLine(result == 1 ? "Successfully saved." : "Save failed.");

            //Console.WriteLine("Connection closed.");
        }

        public void Edit()
        {
            Console.WriteLine("Blog ID: ");
            string id = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@BlogId", id);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            DataRow dr = dt.Rows[0];

            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);


        }

        public void Update()
        {
            Console.WriteLine("Blog Id: ");
            string id = Console.ReadLine();

            Console.WriteLine("Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            string content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId = @BlogId";



            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Blogid", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result == 1 ? "Successfully updated." : "Update failed.");


        }

        public void Delete()
        {
            Console.WriteLine("Enter BlogId to delete: ");
            string id = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Blogid", id);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result == 1 ? "Successfully deleted." : "Delete failed.");

        }
    }
}
