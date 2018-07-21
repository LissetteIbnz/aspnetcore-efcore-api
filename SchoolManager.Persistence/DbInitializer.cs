using SchoolManager.Core.Domain;
using System;
using System.Linq;

namespace SchoolManager.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstName = "Carson",   LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstName = "Meredith", LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Arturo",   LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstName = "Gytis",    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Yan",      LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstName = "Peggy",    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstName = "Laura",    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstName = "Nino",     LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-09-01") }
            };

            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructor.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
            };

            foreach (Department d in departments)
            {
                context.Department.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {Title = "Chemistry",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").ID
                },
                new Course {Title = "Microeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").ID
                },
                new Course {Title = "Macroeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").ID
                },
                new Course {Title = "Calculus",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").ID
                },
                new Course {Title = "Trigonometry",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").ID
                },
                new Course {Title = "Composition",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "English").ID
                },
                new Course {Title = "Literature",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "English").ID
                },
            };

            foreach (Course c in courses)
            {
                context.Course.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Harui").ID,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID,
                    Location = "Thompson 304" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignment.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Kapoor").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Calculus" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Composition" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Literature" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignment.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).ID,
                    Grade = Grade.A
                },
                new Enrollment {
                StudentID = students.Single(s => s.LastName == "Alexander").ID,
                CourseID = courses.Single(c => c.Title == "Microeconomics" ).ID,
                Grade = Grade.C
                },
                new Enrollment {
                StudentID = students.Single(s => s.LastName == "Alexander").ID,
                CourseID = courses.Single(c => c.Title == "Macroeconomics" ).ID,
                Grade = Grade.B
                },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                CourseID = courses.Single(c => c.Title == "Calculus" ).ID,
                Grade = Grade.B
                },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                CourseID = courses.Single(c => c.Title == "Trigonometry" ).ID,
                Grade = Grade.B
                },
                new Enrollment {
                StudentID = students.Single(s => s.LastName == "Alonso").ID,
                CourseID = courses.Single(c => c.Title == "Composition" ).ID,
                Grade = Grade.B
                },
                new Enrollment {
                StudentID = students.Single(s => s.LastName == "Anand").ID,
                CourseID = courses.Single(c => c.Title == "Chemistry" ).ID
                },
                new Enrollment {
                StudentID = students.Single(s => s.LastName == "Anand").ID,
                CourseID = courses.Single(c => c.Title == "Microeconomics").ID,
                Grade = Grade.B
                },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").ID,
                    Grade = Grade.B
                    },
                new Enrollment {
                StudentID = students.Single(s => s.LastName == "Li").ID,
                CourseID = courses.Single(c => c.Title == "Composition").ID,
                Grade = Grade.B
                },
                new Enrollment {
                StudentID = students.Single(s => s.LastName == "Justice").ID,
                CourseID = courses.Single(c => c.Title == "Literature").ID,
                Grade = Grade.B
                }
            };
            
            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollment.Where(
                    s =>
                            s.StudentFk.ID == e.StudentID &&
                            s.CourseFk.ID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollment.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
