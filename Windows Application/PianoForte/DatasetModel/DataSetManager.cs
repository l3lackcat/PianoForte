using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using PianoForte.Model;

namespace PianoForte.DatasetModel
{
    public class DataSetManager
    {
        public static string DATA_TYPE_INT32 = "System.Int32";
        public static string DATA_TYPE_DOUBLE = "System.Double";
        public static string DATA_TYPE_STRING = "System.String";
        public static string DATA_TYPE_DATETIME = "System.DateTime";

        public static DataColumn createDataColumn(DataColumn dataColumn, string dataType, string columnName)
        {
            dataColumn.DataType = System.Type.GetType(dataType);
            dataColumn.ColumnName = columnName;

            return dataColumn;
        }
    }
}
