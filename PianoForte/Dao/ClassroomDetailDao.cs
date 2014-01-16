using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface ClassroomDetailDao
    {
        bool insertClassroomDetail(string databaseName, ClassroomDetail classroomDetail);

        bool updateClassroomDetail(string databaseName, ClassroomDetail classroomDetail);

        //This method is used to update status to checked in only.
        bool updateClassroomDetailStatus(string databaseName);

        List<ClassroomDetail> getClassroomDetailListByTeacherId(string databaseName, int teacherId);
    }
}
