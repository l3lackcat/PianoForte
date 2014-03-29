using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class CourseManager
    {
        private static CourseDao courseDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getCourseDao();

        //--------------------------------------------------------------------------------

        public static bool insertCourse(Course course)
        {
            return courseDao.insertCourse(course);
        }

        public static bool updateCourse(Course course)
        {
            return courseDao.updateCourse(course);
        }

        public static bool updateCourseId(int oldCourseId, int newCourseId)
        {
            return courseDao.updateCourseId(oldCourseId, newCourseId);
        }

        public static bool deleteCourse(int courseId)
        {
            return courseDao.deleteCourse(courseId);
        }        

        //--------------------------------------------------------------------------------

        public static Course findCourse(int courseId)
        {
            return courseDao.findCourse(courseId);
        }

        public static Course findCourse(int courseId, Course.CourseStatus status)
        {
            return courseDao.findCourse(courseId, status);
        }

        //--------------------------------------------------------------------------------

        public static Course findCourseByNameAndLevel(string courseName, string courseLevel)
        {
            return courseDao.findCourseByNameAndLevel(courseName, courseLevel);
        }

        public static Course findCourseByNameAndLevel(string courseName, string courseLevel, Course.CourseStatus status)
        {
            return courseDao.findCourseByNameAndLevel(courseName, courseLevel, status);
        }

        //--------------------------------------------------------------------------------

        public static List<Course> findAllCourse()
        {
            return courseDao.findAllCourse();
        }

        public static List<Course> findAllCourse(int startIndex, int offset)
        {
            return courseDao.findAllCourse(startIndex, offset);
        }

        public static List<Course> findAllCourse(Course.CourseStatus status)
        {
            List<Course> courseList;

            if (status == Course.CourseStatus.ALL)
            {
                courseList = courseDao.findAllCourse();
            }
            else
            {
                courseList = courseDao.findAllCourse(status);
            }

            return courseList;
        }

        public static List<Course> findAllCourse(Course.CourseStatus status, int startIndex, int offset)
        {
            List<Course> courseList;

            if (status == Course.CourseStatus.ALL)
            {
                courseList = courseDao.findAllCourse(startIndex, offset);
            }
            else
            {
                courseList = courseDao.findAllCourse(status, startIndex, offset);
            }

            return courseList;
        }

        //--------------------------------------------------------------------------------

        public static List<Course> findAllCourseByCourseCategoryId(int courseCategoryId)
        {
            return courseDao.findAllCourseByCourseCategoryId(courseCategoryId);
        }

        public static List<Course> findAllCourseByCourseCategoryId(int courseCategoryId, int startIndex, int offset)
        {
            return courseDao.findAllCourseByCourseCategoryId(courseCategoryId, startIndex, offset);
        }

        public static List<Course> findAllCourseByCourseCategoryId(int courseCategoryId, Course.CourseStatus status)
        {
            List<Course> courseList;

            if (status == Course.CourseStatus.ALL)
            {
                courseList = courseDao.findAllCourseByCourseCategoryId(courseCategoryId);
            }
            else
            {
                courseList = courseDao.findAllCourseByCourseCategoryId(courseCategoryId, status);
            }

            return courseList;
        }

        public static List<Course> findAllCourseByCourseCategoryId(int courseCategoryId, Course.CourseStatus status, int startIndex, int offset)
        {
            List<Course> courseList;

            if (status == Course.CourseStatus.ALL)
            {
                courseList = courseDao.findAllCourseByCourseCategoryId(courseCategoryId, startIndex, offset);
            }
            else
            {
                courseList = courseDao.findAllCourseByCourseCategoryId(courseCategoryId, status, startIndex, offset);
            }

            return courseList;
        }

        //--------------------------------------------------------------------------------

        public static List<Course> findAllCourseByCourseName(string courseName)
        {
            return courseDao.findAllCourseByCourseName(courseName);
        }

        public static List<Course> findAllCourseByCourseName(string courseName, int startIndex, int offset)
        {
            return courseDao.findAllCourseByCourseName(courseName, startIndex, offset);
        }

        public static List<Course> findAllCourseByCourseName(string courseName, Course.CourseStatus status)
        {
            List<Course> courseList;

            if (status == Course.CourseStatus.ALL)
            {
                courseList = courseDao.findAllCourseByCourseName(courseName);
            }
            else
            {
                courseList = courseDao.findAllCourseByCourseName(courseName, status);
            }

            return courseList;
        }

        public static List<Course> findAllCourseByCourseName(string courseName, Course.CourseStatus status, int startIndex, int offset)
        {
            List<Course> courseList;

            if (status == Course.CourseStatus.ALL)
            {
                courseList = courseDao.findAllCourseByCourseName(courseName, startIndex, offset);
            }
            else
            {
                courseList = courseDao.findAllCourseByCourseName(courseName, status, startIndex, offset);
            }

            return courseList;
        }

        //--------------------------------------------------------------------------------

        public static List<Course> findAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName)
        {
            return courseDao.findAllCourseByCourseCategoryIdAndCourseName(courseCategoryId, courseName);
        }

        public static List<Course> findAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName, int startIndex, int offset)
        {
            return courseDao.findAllCourseByCourseCategoryIdAndCourseName(courseCategoryId, courseName, startIndex, offset);
        }

        public static List<Course> findAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName, Course.CourseStatus status)
        {
            List<Course> courseList;

            if (status == Course.CourseStatus.ALL)
            {
                courseList = courseDao.findAllCourseByCourseCategoryIdAndCourseName(courseCategoryId, courseName);
            }
            else
            {
                courseList = courseDao.findAllCourseByCourseCategoryIdAndCourseName(courseCategoryId, courseName, status);
            }

            return courseList;
        }

        public static List<Course> findAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName, Course.CourseStatus status, int startIndex, int offset)
        {
            List<Course> courseList;

            if (status == Course.CourseStatus.ALL)
            {
                courseList = courseDao.findAllCourseByCourseCategoryIdAndCourseName(courseCategoryId, courseName, startIndex, offset);
            }
            else
            {
                courseList = courseDao.findAllCourseByCourseCategoryIdAndCourseName(courseCategoryId, courseName, status, startIndex, offset);
            }

            return courseList;
        }

        //--------------------------------------------------------------------------------

        public static List<Course> findAllCourseByCourseNameWithoutWildcard(string courseName)
        {
            return courseDao.findAllCourseByCourseNameWithoutWildcard(courseName);

        }

        //--------------------------------------------------------------------------------

        public static List<string> getAllActiveCourseName()
        {
            List<string> courseNameList = new List<string>();

            List<Course> courseList = courseDao.findAllCourse(Course.CourseStatus.ACTIVE);
            for (int i = 0; i < courseList.Count; i++)
            {
                bool isDuplicate = false;

                for (int j = 0; j < courseNameList.Count; j++)
                {
                    if (courseList[i].Name == courseNameList[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    courseNameList.Add(courseList[i].Name);
                }
            }

            return courseNameList;
        }

        //--------------------------------------------------------------------------------

        public static int getNewCourseId(string courseName, int courseLevelNumber)
        {
            int courseId = 0;

            //List<Course> tempCourseList = CourseManager.findAllCourseByCourseCategoryId(courseCategoryId);
            List<Course> tempCourseList = CourseManager.findAllCourse();
            if (tempCourseList.Count == 0)
            {
                //string stringCourseCategoryId = convertToString(courseCategoryId);
                //string stringCourseNumber = convertToString(1);
                string stringCourseLevelNumber = convertToString(courseLevelNumber);

                courseId = ((int)Product.ProductType.COURSE * 1000000) + Convert.ToInt32("01" + stringCourseLevelNumber);
            }
            else
            {
                bool isCourseNameExist = false;

                for (int i = 0; i < tempCourseList.Count; i++)
                {
                    if (courseName == tempCourseList[i].Name)
                    {
                        isCourseNameExist = true;
                        break;
                    }
                }

                if (isCourseNameExist)
                {
                    courseId = getNewCourseId(courseName);
                }
                else
                {
                    //string stringCourseCategoryId = convertToString(courseCategoryId);
                    string stringCourseNumber = getNextCourseNumber(tempCourseList[tempCourseList.Count - 1].Id);
                    string stringCourseLevelNumber = convertToString(courseLevelNumber);

                    courseId = ((int)Product.ProductType.COURSE * 1000000) + Convert.ToInt32(stringCourseNumber + stringCourseLevelNumber);
                }
            }

            return courseId;
        }

        public static int getNewCourseId(string courseName)
        {
            int courseId = 0;

            //List<Course> tempCourseList = CourseManager.findAllCourseByCourseCategoryIdAndCourseName(courseCategoryId, courseName);
            List<Course> tempCourseList = CourseManager.findAllCourseByCourseName(courseName);
            if (tempCourseList.Count > 0)
            {
                int lastCourseId = tempCourseList[tempCourseList.Count - 1].Id;
                string stringCourseId = lastCourseId.ToString().Substring(0, 5);
                stringCourseId += getNextCourseLevelNumber(lastCourseId);
                courseId = Convert.ToInt32(stringCourseId);
            }

            return courseId;
        }

        public static string getNextCourseNumber(int courseId)
        {
            return convertToString(Convert.ToInt32(getCourseNumber(courseId)) + 1);
        }

        public static string getCourseNumber(int courseId)
        {
            return courseId.ToString().Substring(3, 2);
        }

        public static string getNextCourseLevelNumber(int courseId)
        {
            return convertToString(Convert.ToInt32(getCourseLevelNumber(courseId)) + 1);
        }

        public static string getCourseLevelNumber(int courseId)
        {
            return courseId.ToString().Substring(5, 2);
        }

        public static string getCourseLevelNumber_Old(int courseId)
        {
            return courseId.ToString().Substring(4, 2);
        }

        public static string convertToString(int number)
        {
            string stringNumber = number.ToString();
            if (stringNumber.Length == 1)
            {
                stringNumber = "0" + stringNumber;
            }

            return stringNumber;
        }

        public static int getCommissionRate(Course course)
        {
            int commissionRate = 0;

            if (course.StudentPerClassroom == 1)
            {
                commissionRate = 40;
            }
            else if (course.StudentPerClassroom == 2)
            {
                commissionRate = 35;
            }

            return commissionRate;
        }

        public static string getDisplayCourseText(Course course)
        {
            string courseText = "";

            if (course != null)
            {
                courseText = course.Name;

                if (course.Level != "")
                {
                    courseText += " - " + course.Level;
                }
            }

            return courseText;
        }        

        //Temporary
        //public static List<Course> getAllCourseOld()
        //{
        //    return courseService.getAllCourseOld();
        //}

        //public static List<Course> getAllCourseOld(int courseCategoryId)
        //{
        //    return courseService.getAllCourseByCourseCategoryId(courseCategoryId);
        //}

        //public static bool matchCourseId(int oldCourseId, int newCourseId)
        //{
        //    return courseService.matchCourseId(oldCourseId, newCourseId);
        //}

        //public static int getNewCourseId(int oldCourseId)
        //{
        //    return courseService.getNewCourseId(oldCourseId);
        //}        
    }
}
