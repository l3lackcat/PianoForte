using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface GlobalUserDao
    {
        bool insertGlobalUser(GlobalUser globalUser);

        bool updateGlobalUser(GlobalUser globalUser);

        List<GlobalUser> getGlobalUserList();

        List<GlobalUser> getGlobalUserList(string username);
    }
}
