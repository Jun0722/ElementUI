﻿using System;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace API.Data
{
    public static class DbConfig
    {
        //private static readonly string DefaultSqlConnectionString = @"server=localhost;User Id=root;password=wx0604;Database=EDU;SslMode=none;";
        private static readonly string DefaultSqlConnectionString = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                   .AddJsonFile("appsettings.json")
                                                   .Build()
                                                   .GetConnectionString("MysqlConnection");

        public static IDbConnection GetSqlConnection(string sqlConnectionString = null)
        {
            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                sqlConnectionString = DefaultSqlConnectionString;
            }
            IDbConnection conn = new MySqlConnection(sqlConnectionString);
            conn.Open();
            return conn;
        }
    }
}
