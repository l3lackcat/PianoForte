using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class OtherCost : Product
    {
        public static string tableName = "other_cost";
        public static string columnOtherCostId = "otherCostId";
        public static string columnOtherCostName = "otherCostName";
        public static string columnOtherCostPrice = "otherCostPrice";

        //Temporary
        public static string matchingTableName = "other_cost_id_matching";
        public static string columnOldOtherCostId = "oldOtherCostId";
        public static string columnNewOtherCostId = "newOtherCostId";
    }
}
