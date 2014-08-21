using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.View;

namespace PianoForte.Constant
{
    public class Constant
    {
        public static string STARTUP_PATH;
                       
        public static string RECEIPT_PRINTER_LOCAL = "EPSON LQ-300+ /II ESC/P 2".ToLower();
        public static string RECEIPT_PRINTER_NETWORK1 = "\\\\Pianoforte01\\epson lq-300+ /ii esc/p 2".ToLower();
        public static string RECEIPT_PRINTER_NETWORK2 = "\\\\Pianoforte01\\EPSON LQ-300+ /II ESC/P 2".ToLower();

        public static string NORMAL_PRINTER = "EPSON Stylus Photo R230 Series";

        public static string PERCENT = "เปอร์เซ็นต์";
        public static string BAHT = "บาท";

        public static string INVALID_DISCOUNT_RATE = "กรุณากรอกส่วนลดให้ถูกต้อง";

        public static string OVER_12_ITEMS = "ไม่สามารถใส่รายการขายเกิน 12 รายการได้";

        public static string PRINTER_NOT_FOUND = "กรุณาเชื่อมต่อเครื่องปริ้น";

        public static string ALL_EN = "ALL";
        public static string ALL_TH = "ทั้งหมด";

        public const string GENDER_MALE = "ชาย";
        public const string GENDER_FEMALE = "หญิง";

        public const string USABLE_NAME = "สามารถใช้ชื่อนี้ได้";
        public const string DUPLICATE_COURSE_NAME = "ชื่อวิชาได้ถูกใช้ไปแล้ว";

        public const string DUPLICATE_COURSE_LEVEL = "ชื่อระดับชั้นได้ถูกใช้ไปแล้ว";        

        public const string INVALID_DATA = "กรุณากรอกข้อมูลให้ถูกต้อง";
        public const string NOT_FILL_DATA = "กรุณากรอกข้อมูล";                

        public const string MUSIC_FOR_CHILDREN_EN = "Music for Children";
        public const string MUSIC_FOR_CHILDREN_TH = "สำหรับเด็กเล็ก (4 - 6 ปี)";

        public const string SELECTED_MONDAY = "ไม่สามารถเรียนในวันจันทร์ได้";        

        public const string NOT_FILL_COURSE_CATEGORY_NAME = "กรุณากรอกชื่อหลักสูตรใหม่";
        public const string NOT_FILL_COURSE_NAME = "กรุณากรอกชื่อวิชา";
        public const string NOT_FILL_COURSE_LEVEL = "กรุณาเพิ่มข้อมูลระดับชั้นของวิชาเรียนนี้";
        public const string CONFIRM_DELETE_COURSE_LEVEL = "คุณต้องการลบเลเวลนี้?";

        public const string CONFIRM_CANCEL_THIS_COURSE = "คุณต้องการยกเลิกวิชานี้?";
        public const string CANCEL_COURSE_SUCCESS = "ยกเลิกวิชาเรียบร้อย";
        public const string CANCEL_COURSE_FAIL = "ยกเลิกวิชาล้มเหลว";

        public const string OUT_OF_ORDER = "ขออภัย สินค้าหมด";

        public const string CONFIRM_PAYMENT = "คุณต้องการชำระเงิน?";
        public const string INVALID_CREDITCARD_NUMBER = "กรุณากรอกหมายเลขบัตรเครดิตให้ถูกต้อง";
        public const string PAYMENT_SUCCESS = "ชำระเงินเรียบร้อยแล้ว";
        public const string PAYMENT_FAIL = "ชำระเงินล้มเหลว";
    }
}
