using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class CdService
    {
        private static CdDao cdDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getCdDao();

        public static int getNewCdId(string databaseName)
        {
            int newCdId = 0;

            Cd cd = cdDao.getLastCd(databaseName);
            if (cd != null)
            {
                newCdId = cd.Id + 1;
            }
            else
            {
                newCdId = ((int)Enum.ProductType.CD * 1000000) + 1;
            }

            return newCdId;
        }

        public static bool insertCd(string databaseName, Cd cd)
        {
            return cdDao.insertCd(databaseName, cd);
        }

        public static bool updateCd(string databaseName, Cd cd)
        {
            return cdDao.updateCd(databaseName, cd);
        }

        public static Cd getCd(string databaseName, int id)
        {
            return cdDao.getCd(databaseName, id);
        }

        public static Cd getCd(string databaseName, string barcode)
        {
            return cdDao.getCd(databaseName, barcode);
        }

        public static Cd getLastCd(string databaseName)
        {
            return cdDao.getLastCd(databaseName);
        }

        public static List<Cd> getCdList(string databaseName)
        {
            return cdDao.getCdList(databaseName);
        }

        public static List<Cd> getCdList(string databaseName, int startIndex, int offset)
        {
            return cdDao.getCdList(databaseName, startIndex, offset);
        }

        public static List<Cd> getCdList(string databaseName, int startIndex, int offset, string keyword)
        {
            return cdDao.getCdList(databaseName, startIndex, offset, keyword);
        }

        public static List<Cd> getCdListByName(string databaseName, string name)
        {
            return cdDao.getCdListByName(databaseName, name);
        }
    }
}