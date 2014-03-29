using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface StudentAddressDao
    {
        bool insertStudentAddress(string databaseName, StudentAddress studentAddress);

        bool updateStudentAddress(string databaseName, StudentAddress studentAddress);

        bool deleteStudentAddress(string databaseName, int studentId);

        List<StudentAddress> getStudentAddressList(string databaseName, int studentId);
    }
}
