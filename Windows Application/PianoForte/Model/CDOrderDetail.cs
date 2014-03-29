using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class CdOrderDetail : LearningMaterialOrderDetail
    {
        public static string tableName = "cd_order_detail";
        public static string columnCdOrderDetailId = "cdOrderDetailId";
        public static string columnPaymentId = "paymentId";
        public static string columnStudentId = "studentId";
        public static string columnCdId = "cdId";
        public static string columnAmount = "amount";
        public static string columnTotalPrice = "totalPrice";
        public static string columnOrderDate = "orderDate";
        public static string columnStatus = "status";
    }
}
