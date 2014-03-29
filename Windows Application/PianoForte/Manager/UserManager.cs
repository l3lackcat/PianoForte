using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class UserManager
    {
        private static UserDao userDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getUserDao(); 

        public static bool insertUser(User user)
        {
            return userDao.insertUser(user);
        }

        public static bool updateUser(User user)
        {
            return userDao.updateUser(user);
        }

        public static bool deleteUser(int userId)
        {
            return userDao.deleteUser(userId);
        }

        public static User findUser(int userId)
        {
            return userDao.findUser(userId);
        }

        public static User findUser(string username)
        {
            return userDao.findUser(username);
        }   
     
        public static List<User> findAllUser()
        {
            return userDao.findAllUser();
        }
    }
}
