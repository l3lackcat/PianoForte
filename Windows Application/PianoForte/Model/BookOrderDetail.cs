using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class BookOrderDetail : LearningMaterialOrderDetail
    {
        public static string tableName = "book_order_detail";
        public static string columnBookOrderDetailId = "bookOrderDetailId";
        public static string columnPaymentId = "paymentId";
        public static string columnStudentId = "studentId";
        public static string columnBookId = "bookId";
        public static string columnAmount = "amount";
        public static string columnTotalPrice = "totalPrice";
        public static string columnOrderDate = "orderDate";
        public static string columnStatus = "status";
    }
}
