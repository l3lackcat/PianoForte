using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;
using PianoForte.Service;

namespace PianoForte.Manager
{
    public class LearningMaterialManager
    {
        private static BookOrderDetailService bookOrderDetailService = new BookOrderDetailService();
        private static CdOrderDetailService cdOrderDetailService = new CdOrderDetailService();

        public static BookOrderDetail addBookOrderDetail(BookOrderDetail bookOrderDetail)
        {
            bool isAddSuccess = bookOrderDetailService.addBookOrderDetail(bookOrderDetail);
            if (isAddSuccess)
            {
                bookOrderDetail.Id = bookOrderDetailService.getLastBookOrderDetail().Id;
            }
            else
            {
                bookOrderDetail = null;
            }

            return bookOrderDetail;
        }

        public static bool updateBookOrderDetail(BookOrderDetail bookOrderDetail)
        {
            return bookOrderDetailService.updateBookOrderDetail(bookOrderDetail);
        }

        public static bool deleteBookOrderDetail(int bookOrderDetailId)
        {
            return bookOrderDetailService.deleteBookOrderDetail(bookOrderDetailId);
        }

        public static BookOrderDetail getBookOrderDetail(int bookOrderDetailId)
        {
            return bookOrderDetailService.getBookOrderDetail(bookOrderDetailId);
        }

        public static List<BookOrderDetail> getAllBookOrderDetail()
        {
            return bookOrderDetailService.getAllBookOrderDetailByDate();
        }

        public static List<BookOrderDetail> getAllBookOrderDetailByPaymentId(int paymentId)
        {
            return bookOrderDetailService.getAllBookOrderDetailByPaymentId(paymentId);
        }

        public static CdOrderDetail addCdOrderDetail(CdOrderDetail cdOrderDetail)
        {
            bool isAddSuccess = cdOrderDetailService.addCdOrderDetail(cdOrderDetail);
            if (isAddSuccess)
            {
                cdOrderDetail.Id = cdOrderDetailService.getLastCdOrderDetail().Id;
            }
            else
            {
                cdOrderDetail = null;
            }

            return cdOrderDetail;
        }

        public static bool updateCdOrderDetail(CdOrderDetail cdOrderDetail)
        {
            return cdOrderDetailService.updateCdOrderDetail(cdOrderDetail);
        }

        public static bool deleteCdOrderDetail(int cdOrderDetailId)
        {
            return cdOrderDetailService.deleteCdOrderDetail(cdOrderDetailId);
        }

        public static CdOrderDetail getCdOrderDetail(int cdOrderDetailId)
        {
            return cdOrderDetailService.getCdOrderDetail(cdOrderDetailId);
        }

        public static List<CdOrderDetail> getAllCdOrderDetail()
        {
            return cdOrderDetailService.getAllCdOrderDetail();
        }

        public static List<CdOrderDetail> getAllCdOrderDetailByPaymentId(int paymentId)
        {
            return cdOrderDetailService.getAllCdOrderDetailByPaymentId(paymentId);
        }
    }
}
