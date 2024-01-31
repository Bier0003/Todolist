using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;

namespace Todolist
{
    public class DB_Operation 
    {

        private static SqlConnection _connection = DBconnect.GetConnection();

        public void GetList()
        {
            string sql = "SELECT id, TodoText, Dato, isCheck FROM Todo";
            SqlCommand cmd = new SqlCommand(sql, _connection);

            _connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    var id = Convert.ToInt32(reader["id"]);
                    var todoText = reader["todoText"].ToString();

                    // Assuming "dato" is a string in the format "dd-MM-yyyy HH:mm:ss"
                    var datoString = reader["dato"].ToString();
                    var dato = DateTime.ParseExact(datoString, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                    var isCheck = Convert.ToBoolean(reader["isCheck"]);

                    Todo todoObject = new Todo
                    {
                        id = id,
                        TodoText = todoText,
                        Dato = dato,
                        isCheck = isCheck
                    };

                    Console.WriteLine(JsonConvert.SerializeObject(todoObject));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }



            finally { _connection.Close(); }
        }

        public void InsertList(Todo list)
        {


            try
            {
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                string sql = "INSERT INTO Todo(TodoText,Dato,isCheck) values (@TodoText,@Dato,@isCheck)";


                cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@TodoText", list.TodoText);
                cmd.Parameters.AddWithValue("@Dato", DateTime.Now);
                cmd.Parameters.AddWithValue("@isCheck", false);



                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                _connection.Close();
            }


        }

        internal void InsertList(string? add)
        {
            throw new NotImplementedException();
        }

        public void DeleteList(Todo list)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = _connection.CreateCommand();
                String SQL = "DELETE FROM todo WHERE  ID = @id";
                cmd = new SqlCommand(SQL, _connection);
                cmd.Parameters.AddWithValue("@Id", list.id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }

        }


        public int EditList(Todo list)
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                //string sql = "UPDATE todo SET todoText = @NewText WHERE ID = @TodoID;";
                //string sql = "UPDATE todo SET todoText = " + list.TodoText + " WHERE ID = " + list.id + ";";
                string sql = "UPDATE todo SET todoText = @noteText WHERE ID = @Id";

                cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.AddWithValue("@noteText", list.TodoText);
                cmd.Parameters.AddWithValue("@Id", list.id);

             
               


                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;  // Return the number of rows affected by the update
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;  // Return a value indicating an error, for example, -1
            }
            finally
            {
                _connection.Close();
            }
        }

        public int MarkList(Todo list)
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                //string sql = "UPDATE todo SET todoText = @NewText WHERE ID = @TodoID;";

                //string sql = "UPDATE todo SET todoText = " + list.TodoText + " WHERE ID = " + list.id + ";";
                string Sql = "UPDATE Todo SET isCheck = 1 WHERE ID = @Id";

                cmd = new SqlCommand(Sql, _connection);

                cmd.Parameters.AddWithValue("@Id", list.id);
               

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;  // Return the number of rows affected by the update
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;  // Return a value indicating an error, for example, -1
            }
            finally
            {
                _connection.Close();
            }
        }


       

    }

}
