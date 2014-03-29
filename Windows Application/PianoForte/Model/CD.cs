using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class Cd : Product
    {
        public static string tableName = "cd";
        public static string columnCdId = "cdId";
        public static string columnCdBarcode = "cdBarcode";
        public static string columnCdName = "cdName";
        public static string columnCdPrice = "cdPrice";
        public static string columnCdAmount = "cdAmount";
        public static string columnStatus = "status";

        //Temporary
        public static string matchingTableName = "cd_id_matching";
        public static string columnOldCdId = "oldCdId";
        public static string columnNewCdId = "newCdId";

        public enum CdStatus
        {
            ALL,
            AVAILABLE,
            EMPTY,
            CANCELED
        };

        private string barcode;
        private int amount;
        private string status;

        public Cd()
        {
            //Do Nothing
        }

        public Cd(Cd cd)
        {
            this.Id = cd.Id;
            this.Type = cd.Type;
            this.Barcode = cd.Barcode;
            this.Name = cd.Name;
            this.Price = cd.Price;
            this.Amount = cd.Amount;
            this.Status = cd.Status;
        }

        public string Barcode
        {
            get
            {
                return this.barcode;
            }

            set
            {
                this.barcode = value;
            }
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                this.amount = value;
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
