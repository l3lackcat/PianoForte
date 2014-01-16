using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface ClassroomDao
    {
        bool insertClassroom(string databaseName, Classroom classroom);

        bool updateClassroom(string databaseName, Classroom classroom);
    }
}
