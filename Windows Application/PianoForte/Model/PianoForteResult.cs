using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class PianoForteResult
    {
        private bool result;
        private string message;

        public bool Result
        {
            get
            {
                return this.result;
            }

            set
            {
                this.result = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
            }
        }
    }
}
