using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface UserDao
    {
        bool insertUser(User user);
        bool updateUser(User user);
        bool deleteUser(int userId);

        User findUser(int userId);
        User findUser(string username);

        List<User> findAllUser();
    }
}
