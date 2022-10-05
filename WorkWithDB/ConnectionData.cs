using System;
using System.Collections.Generic;
using System.Text;

namespace WorkWithDB
{
    public static class ConnectionData
    {
        private static readonly string server = "localhost";
        private static readonly string catalog = "UFCdb";
        private static readonly string user = "User2";
        private static readonly string password = "A123321A";

        public static readonly string connectionString = $"Data Source={server};" +
                                                         $"Initial Catalog={catalog};" +
                                                         $"User={user};" +
                                                         $"Password={password};";
    }
}