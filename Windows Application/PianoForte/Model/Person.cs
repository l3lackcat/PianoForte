using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class Person
    {
        protected int id;
        protected string firstname;
        protected string lastname;
        protected string nickname;        
        protected string email;
        protected string phone1;
        protected string phone2;
        protected string phone3;
        private DateTime birthday;
        private DateTime registeredDate;
        protected string status;
        

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

        public string Firstname
        {
            get
            {
                return this.firstname;
            }

            set
            {
                this.firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return this.lastname;
            }

            set
            {
                this.lastname = value;
            }
        }

        public string Nickname
        {
            get
            {
                return this.nickname;
            }

            set
            {
                this.nickname = value;
            }
        }        

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public string Phone1
        {
            get
            {
                return this.phone1;
            }

            set
            {
                this.phone1 = value;
            }
        }

        public string Phone2
        {
            get
            {
                return this.phone2;
            }

            set
            {
                this.phone2 = value;
            }
        }

        public string Phone3
        {
            get
            {
                return this.phone3;
            }

            set
            {
                this.phone3 = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return this.birthday;
            }

            set
            {
                this.birthday = value;
            }
        }

        public DateTime RegisteredDate
        {
            get
            {
                return this.registeredDate;
            }

            set
            {
                this.registeredDate = value;
            }
        }

        public string Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }        
    }
}
