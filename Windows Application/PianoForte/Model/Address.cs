using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class Address
    {
        private string address1;
        private string address2;
        private int postCode;

        public string Address1
        {
            get
            {
                return this.address1;
            }

            set
            {
                this.address1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return this.address2;
            }

            set
            {
                this.address2 = value;
            }
        }

        public int PostCode
        {
            get
            {
                return this.postCode;
            }

            set
            {
                this.postCode = value;
            }
        }
    }
}
