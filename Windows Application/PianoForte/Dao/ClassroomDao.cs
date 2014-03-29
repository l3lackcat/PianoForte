using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface ClassroomDao
    {
        bool insertClassroom(Classroom classroom);
        bool updateClassroom(Classroom classroom);
        bool deleteClassroom(int classroomId);

        Classroom findClassroom(int classroomId);
        Classroom findLastClassroom();        

        List<Classroom> findAllClassroom();
        List<Classroom> findAllClassroom(int enrollmentId);
    }
}
