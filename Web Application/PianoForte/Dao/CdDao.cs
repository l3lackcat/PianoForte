using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface CdDao
    {
        bool insertCd(string databaseName, Cd cd);

        bool updateCd(string databaseName, Cd cd);

        Cd getCd(string databaseName, int cdId);

        Cd getLastCd(string databaseName);

        List<Cd> getCdList(string databaseName);

        List<Cd> getCdList(string databaseName, int startIndex, int offset);

        List<Cd> getCdList(string databaseName, int startIndex, int offset, string keyword);

        List<Cd> getCdListByName(string databaseName, string cdName);
    }
}
