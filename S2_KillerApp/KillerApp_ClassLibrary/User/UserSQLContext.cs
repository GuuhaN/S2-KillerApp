using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace KillerApp_ClassLibrary.User
{
    class UserSQLContext : IUserContext
    {
        private DataTable queryResults;
        public DataTable SelectUser()
        {
            using(SqlConnection)
        }

        public void AddUser()
        {
            throw new NotImplementedException();
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
