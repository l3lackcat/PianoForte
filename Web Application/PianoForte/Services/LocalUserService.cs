using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class LocalUserService
    {
        private static LocalUserDao localUserDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getLocalUserDao();

        public static bool insertLocalUser(string databaseName, LocalUser localUser)
        {
            return localUserDao.insertLocalUser(databaseName, localUser);
        }

        public static bool updateLocalUser(string databaseName, LocalUser localUser)
        {
            return localUserDao.updateLocalUser(databaseName, localUser);
        }

        public static LocalUser getLocalUser(string databaseName, int localUserId)
        {
            LocalUser localUser = null;

            List<LocalUser> tempLocalUserList = localUserDao.getLocalUserList(databaseName, localUserId);
            if (tempLocalUserList.Count == 1)
            {
                localUser = tempLocalUserList[0];
            }

            return localUser;
        }
    }
}