using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class GlobalUserService
    {
        private static GlobalUserDao globalUserDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getGlobalUserDao();

        public static bool insertGlobalUser(GlobalUser globalUser)
        {
            return globalUserDao.insertGlobalUser(globalUser);
        }

        public static bool updateGlobalUser(GlobalUser globalUser)
        {
            return globalUserDao.updateGlobalUser(globalUser);
        }

        public static GlobalUser getGlobalUser(string username)
        {
            GlobalUser globalUser = null;

            List<GlobalUser> tempGlobalUserList = globalUserDao.getGlobalUserList(username);
            if (tempGlobalUserList.Count == 1)
            {
                globalUser = tempGlobalUserList[0];
            }

            return globalUser;
        }

        public static List<GlobalUser> getGlobalUser()
        {
            return globalUserDao.getGlobalUserList();
        }
    }
}