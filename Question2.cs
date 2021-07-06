using Example.Interview.Question.Placeholders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_interview
{
    public class Question2
    {
        string connectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=true";

        // Provide the query string with a parameter placeholder.
        string queryString = "SELECT ItemId, FirstName, LastName "
                + "FROM People "
                + "WHERE Age > @age "
                + "ORDER BY UnitPrice DESC;";

        // Specify the parameter value.
        int paramValue = 25;

        public DataTable ReadPersonData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            var command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@age", paramValue);
            connection.Open();

            var result = new DataTable();

            var dataAdapter = new SqlDataAdapter(command);
            result.BeginLoadData();
            dataAdapter.Fill(result);
            result.EndLoadData();
            
            
            return result;
        }
    }
}
