using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Data_Contexts
{
    public class SearchSqlContext : ISearchContext
    {
        private string connectionString =
            "Data Source=mssql.fhict.local;Integrated Security = False; User ID = dbi387964; Password=gratisserver;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<SearchResult> Search(string searchTerm)
        {
            List<SearchResult> searchRecords = new List<SearchResult>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SearchProcedure", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@searchTerm", searchTerm);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    searchRecords.Add(new SearchResult(Convert.ToInt32(sqlDataReader["Id"]),
                        sqlDataReader["Title"].ToString(), sqlDataReader["Tablename"].ToString()));
                }

                sqlConnection.Dispose();
                return searchRecords;
            }
        }
    }
}
