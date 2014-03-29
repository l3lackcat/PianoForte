using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Dao
{
    public interface ClassroomEnrollmentDao
    {
        //bool processInsertCommand(string sql, int classroomId, int enrollmentId);
        //bool processUpdateCommand(string sql, int classroomId, int enrollmentId);
        //bool processDeleteCommand(string sql);
        //List<int> processSelectCommand(string sql);

        bool insertClassroomEnrollment(int classroomId, int enrollmentId);
        bool updateClassroomEnrollment(int classroomId, int enrollmentId);
        bool deleteClassroomEnrollmentByClassroomId(int classroomId);
        bool deleteClassroomEnrollmentByEnrollmentId(int enrollmentId);

        List<int> findClassroomIdByEnrollmentId(int enrollmentId);
    }
}
