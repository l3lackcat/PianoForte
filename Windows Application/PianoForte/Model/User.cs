using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class User
    {
        public static string tableName = "user";
        public static string columnUser_id = "user_id";
        public static string columnUser_username = "user_username";
        public static string columnUser_password = "user_password";
        public static string columnUser_role = "user_role";
        public static string columnUser_displayName = "user_displayName";

        private int id;
        private string username;
        private string password;
        private int role;
        private string displayName;

        public enum UserRole
        {
            NORMAL,
            ADMIN
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }

        public int Role
        {
            get
            {
                return this.role;
            }

            set
            {
                this.role = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return this.displayName;
            }

            set
            {
                this.displayName = value;
            }
        }
    }
}
