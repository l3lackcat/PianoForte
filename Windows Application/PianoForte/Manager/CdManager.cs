using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class CdManager
    {
        private static CdDao cdDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getCdDao();

        //--------------------------------------------------------------------------------

        public static int getNewCdId()
        {
            int newCdId = 0;

            Cd cd = cdDao.findLastCd();
            if (cd != null)
            {
                newCdId = cd.Id + 1;
            }
            else
            {
                newCdId = ((int)Product.ProductType.CD * 1000000) + 1;
            }

            return newCdId;
        }

        //--------------------------------------------------------------------------------

        public static bool insertCd(Cd cd)
        {
            return cdDao.insertCd(cd);
        }

        public static bool updateCd(Cd cd)
        {
            return cdDao.updateCd(cd);
        }

        public static bool deleteCd(int cdId)
        {
            return cdDao.deleteCd(cdId);
        }

        //--------------------------------------------------------------------------------

        public static Cd findCd(int cdId)
        {
            return cdDao.findCd(cdId);
        }

        public static Cd findLastCd()
        {
            return cdDao.findLastCd();
        }        

        //--------------------------------------------------------------------------------

        public static List<Cd> findAllCd()
        {
            return cdDao.findAllCd();
        }        

        public static List<Cd> findAllCd(int startIndex, int offset)
        {
            return cdDao.findAllCd(startIndex, offset);
        }

        public static List<Cd> findAllCd(Cd.CdStatus status)
        {
            return cdDao.findAllCd(status);
        }

        public static List<Cd> findAllCd(Cd.CdStatus status, int startIndex, int offset)
        {
            return cdDao.findAllCd(status, startIndex, offset);
        }

        //--------------------------------------------------------------------------------

        public static Cd findCdByBarcode(string barcode)
        {
            return cdDao.findCdByBarcode(barcode);
        }

        //public static List<Cd> findAllCdByBarcode(string barcode, int startIndex, int offset)
        //{
        //    return cdDao.findAllCdByBarcode(barcode, startIndex, offset);
        //}

        //public static List<Cd> findAllCdByBarcode(string barcode, Cd.CdStatus status)
        //{
        //    List<Cd> cdList;

        //    if (status == Cd.CdStatus.ALL)
        //    {
        //        cdList = cdDao.findAllCdByBarcode(barcode);
        //    }
        //    else
        //    {
        //        cdList = cdDao.findAllCdByBarcode(barcode, status);
        //    }

        //    return cdList;
        //}

        //public static List<Cd> findAllCdByBarcode(string barcode, Cd.CdStatus status, int startIndex, int offset)
        //{
        //    List<Cd> cdList;

        //    if (status == Cd.CdStatus.ALL)
        //    {
        //        cdList = cdDao.findAllCdByBarcode(barcode, startIndex, offset);
        //    }
        //    else
        //    {
        //        cdList = cdDao.findAllCdByBarcode(barcode, status, startIndex, offset);
        //    }

        //    return cdList;
        //}

        //--------------------------------------------------------------------------------

        public static List<Cd> findAllCdByName(string cdName)
        {
            return cdDao.findAllCdByName(cdName);
        }

        public static List<Cd> findAllCdByName(string cdName, int startIndex, int offset)
        {
            return cdDao.findAllCdByName(cdName, startIndex, offset);
        }

        public static List<Cd> findAllCdByName(string cdName, Cd.CdStatus status)
        {
            List<Cd> cdList;

            if (status == Cd.CdStatus.ALL)
            {
                cdList = cdDao.findAllCdByName(cdName);
            }
            else
            {
                cdList = cdDao.findAllCdByName(cdName, status);
            }

            return cdList;
        }

        public static List<Cd> findAllCdByName(string cdName, Cd.CdStatus status, int startIndex, int offset)
        {
            List<Cd> cdList;

            if (status == Cd.CdStatus.ALL)
            {
                cdList = cdDao.findAllCdByName(cdName, startIndex, offset);
            }
            else
            {
                cdList = cdDao.findAllCdByName(cdName, status, startIndex, offset);
            }

            return cdList;
        }

        //--------------------------------------------------------------------------------

        //public static List<Cd> findAllCdByBarcodeAndName(string barcode, string cdName)
        //{
        //    return cdDao.findAllCdByBarcodeAndName(barcode, cdName);
        //}

        //public static List<Cd> findAllCdByBarcodeAndName(string barcode, string cdName, int startIndex, int offset)
        //{
        //    return cdDao.findAllCdByBarcodeAndName(barcode, cdName, startIndex, offset);
        //}

        //public static List<Cd> findAllCdByBarcodeAndName(string barcode, string cdName, Cd.CdStatus status)
        //{
        //    List<Cd> cdList;

        //    if (status == Cd.CdStatus.ALL)
        //    {
        //        cdList = cdDao.findAllCdByBarcodeAndName(barcode, cdName);
        //    }
        //    else
        //    {
        //        cdList = cdDao.findAllCdByBarcodeAndName(barcode, cdName, status);
        //    }

        //    return cdList;
        //}

        //public static List<Cd> findAllCdByBarcodeAndName(string barcode, string cdName, Cd.CdStatus status, int startIndex, int offset)
        //{
        //    List<Cd> cdList;

        //    if (status == Cd.CdStatus.ALL)
        //    {
        //        cdList = cdDao.findAllCdByBarcodeAndName(barcode, cdName, startIndex, offset);
        //    }
        //    else
        //    {
        //        cdList = cdDao.findAllCdByBarcodeAndName(barcode, cdName, status, startIndex, offset);
        //    }

        //    return cdList;
        //}        

        //public static int getNewCdId(int oldCdId)
        //{
        //    return cdService.getNewCdId(oldCdId);
        //}

        //Temporary
        //public static List<Cd> getAllCd_Old()
        //{
        //    return cdService.getAllCd_Old();
        //}

        //public static bool matchCdId(int oldCdId, int newCdId)
        //{
        //    return cdService.matchCdId(oldCdId, newCdId);
        //}        
    }
}
