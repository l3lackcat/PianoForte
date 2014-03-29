using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface EnrollmentDao
    {
        bool insertEnrollment(string databaseName, Enrollment enrollment);

        bool updateEnrollment(string databaseName, Enrollment enrollment);
    }
}
