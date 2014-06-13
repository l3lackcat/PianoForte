using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class Enrollment
    {
        public static string tableName = "enrollment";
        public static string columnEnrollmentId = "enrollmentId";
        public static string columnPaymentId = "paymentId";
        public static string columnStudentId = "studentId";
        public static string columnCourseId = "courseId";        
        public static string columnEnrollmentDate = "enrollmentDate";
        public static string columnStatus = "status";
        //Old
        public static string columnCourseFee = "courseFee";
        public static string columnDiscount = "discount";
        public static string columnTotalPrice = "totalPrice";

        public enum EnrollmentStatus
        {
            ALL,            
            PAID,
            NOT_PAID,
            CANCELED
        };

        public int Id { get; set; }
        public int PaymentId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime EnrolledDate { get; set; }
        public string Status { get; set; }
        public List<Classroom> ClassroomList { get; set; }
        public Dictionary<int, List<ClassroomDetail>> ClassroomIdClassroomDetailListDictionary { get; set; }
        // Special
        public double CourseFee { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }

        public Enrollment()
        {
            this.Student = new Student();
            this.Course = new Course();
            this.ClassroomList = new List<Classroom>();
            this.ClassroomIdClassroomDetailListDictionary = new Dictionary<int, List<ClassroomDetail>>();
        }

        public Enrollment(Student student)
        {
            this.Student = new Student(student);
            this.Course = new Course();
            this.ClassroomList = new List<Classroom>();
            this.ClassroomIdClassroomDetailListDictionary = new Dictionary<int, List<ClassroomDetail>>();
        }

        public Enrollment(Course course)
        {
            this.Student = new Student();
            this.Course = new Course(course);
            this.ClassroomList = new List<Classroom>();
            this.ClassroomIdClassroomDetailListDictionary = new Dictionary<int, List<ClassroomDetail>>();
        }

        public Enrollment(Student student, Course course)
        {
            this.Student = new Student(student);
            this.Course = new Course(course);
            this.ClassroomList = new List<Classroom>();
            this.ClassroomIdClassroomDetailListDictionary = new Dictionary<int, List<ClassroomDetail>>();
        }

        public void addClassroom(Classroom classroom)
        {
            if (classroom != null)
            {
                this.ClassroomList.Add(classroom);
            }
        }
    }
}
