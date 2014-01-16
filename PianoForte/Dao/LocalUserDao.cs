using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface LocalUserDao
    {
        bool insertLocalUser(string databaseName, LocalUser localUser);

        bool updateLocalUser(string databaseName, LocalUser localUser);

        List<LocalUser> getLocalUserList(string databaseName, int localUserId);
    }
}
