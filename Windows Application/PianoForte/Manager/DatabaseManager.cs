using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;

using System.Data.OleDb;

using PianoForte.Constant;
using System.Xml;

namespace PianoForte.Manager
{
    public class DatabaseManager
    {
        public static string DATABASE_IP_ADDRESS;
        public static string DATABASE_NAME;
        public static string DATABASE_USERNAME;
        public static string DATABASE_PASSWORD;
        public static string DATABASE_DATE_FORMAT = "yyyy-MM-dd";

        public static void readDatabaseConfiguration()
        {
            XmlTextReader reader = new XmlTextReader("Data\\DataBaseConfig.xml");

            string elementName = "";

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        elementName = reader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (elementName == "IP")
                        {
                            DATABASE_IP_ADDRESS = reader.Value;
                        }

                        if (elementName == "DatabaseName")
                        {
                            DATABASE_NAME = reader.Value;
                        }

                        if (elementName == "Username")
                        {
                            DATABASE_USERNAME = reader.Value;
                        }

                        if (elementName == "Password")
                        {
                            DATABASE_PASSWORD = reader.Value;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        elementName = "";
                        break;
                }                
            }
        }

        public static string getMySqlConnectionString()
        {
            string connectionString = "server = " + DATABASE_IP_ADDRESS + ";" +
                                      "database = " + DATABASE_NAME + ";" +
                                      "uid = " + DATABASE_USERNAME + ";" +
                                      "password = " + DATABASE_PASSWORD + ";" +
                                      "charset = utf8";

            return connectionString;
        }
    }
}
