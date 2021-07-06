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

        public DataTable ReadPersonData(string jobTitle)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            
            var queryString = "SELECT ItemId, FirstName, LastName "
                + "FROM People "
                + $"WHERE JobTitle = '{jobTitle}'"
                + "ORDER BY Age DESC;";

            var command = new SqlCommand(queryString, connection);            
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
