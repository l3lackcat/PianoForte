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

        private int id;
        private int paymentId;
        private Student student;
        private Course course;
        private DateTime enrolledDate;                
        private string status;        
        private List<Classroom> classroomList;
        private Dictionary<int, List<ClassroomDetail>> classroomIdClassroomDetailListDictionary;
        //Old
        private double courseFee;
        private double discount;
        private double totalPrice;

        public Enrollment()
        {
            this.student = new Student();
            this.course = new Course();
            this.classroomList = new List<Classroom>();
            this.classroomIdClassroomDetailListDictionary = new Dictionary<int, List<ClassroomDetail>>();
        }

        public Enrollment(Student student)
        {
            this.student = new Student(student);
            this.course = new Course();
            this.classroomList = new List<Classroom>();
            this.classroomIdClassroomDetailListDictionary = new Dictionary<int, List<ClassroomDetail>>();
        }

        public Enrollment(Course course)
        {
            this.student = new Student();
            this.course = new Course(course);
            this.classroomList = new List<Classroom>();
            this.classroomIdClassroomDetailListDictionary = new Dictionary<int, List<ClassroomDetail>>();
        }

        public Enrollment(Student student, Course course)
        {
            this.student = new Student(student);
            this.course = new Course(course);
            this.classroomList = new List<Classroom>();
            this.classroomIdClassroomDetailListDictionary = new Dictionary<int, List<ClassroomDetail>>();
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public int PaymentId
        {
            get
            {
                return this.paymentId;
            }

            set
            {
                this.paymentId = value;
            }
        }

        public Student Student
        {
            get
            {
                return this.student;
            }

            set
            {
                this.student = value;
            }
        }

        public Course Course
        {
            get
            {
                return this.course;
            }

            set
            {
                this.course = value;
            }
        }

        public DateTime EnrolledDate
        {
            get
            {
                return this.enrolledDate;
            }

            set
            {
                this.enrolledDate = value;
            }
        }        

        public string Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }        

        public List<Classroom> ClassroomList
        {
            get
            {
                return this.classroomList;
            }

            set
            {
                this.classroomList = value;
            }
        }

        public Dictionary<int, List<ClassroomDetail>> ClassroomIdClassroomDetailListDictionary
        {
            get
            {
                return this.classroomIdClassroomDetailListDictionary;
            }

            set
            {
                this.classroomIdClassroomDetailListDictionary = value;
            }
        }

        public double CourseFee
        {
            get
            {
                return this.courseFee;
            }

            set
            {
                this.courseFee = value;
            }
        }

        public double Discount
        {
            get
            {
                return this.discount;
            }

            set
            {
                this.discount = value;
            }
        }

        public double TotalPrice
        {
            get
            {
                return this.totalPrice;
            }

            set
            {
                this.totalPrice = value;
            }
        }

        public void addClassroom(Classroom classroom)
        {
            if (classroom != null)
            {
                this.classroomList.Add(classroom);
            }
        }
    }
}
