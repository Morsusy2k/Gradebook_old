using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.DataAccessLayer.Models;

namespace Gradebook.DataAccessLayer.DataSeeder
{
    public static class TableChecker
    {
        public static void CheckUserTable(DBAccess.DBAGradebook gradebook)
        {
            User user1 = new User()
            {
                Name = "Milenko Kostic",
                Surname = "Milenko",
                Username = "Mile023",
                Password = "secret",
                Email = "mile023@yahoo.com"
            };

            user1.Id = gradebook.Users.Insert(user1);

            User user2 = new User()
            {
                Name = "Marko Markovic",
                Surname = "Mare",
                Username = "marecar",
                Password = "secret",
                Email = "mare@gmail.com"
            };

            user2.Id = gradebook.Users.Insert(user2);

            user2.Password = "secret123";
            gradebook.Users.Update(user2);

            User user3 = new User()
            {
                Name = "temp",
                Surname = "temp",
                Username = "temp",
                Password = "temp",
                Email = "temp@gmail.com"
            };

            user3.Id = gradebook.Users.Insert(user3);

            gradebook.Users.Delete(user3);
        }

        public static void CheckRoleTable(DBAccess.DBAGradebook gradebook)
        {
            Role role1 = new Role()
            {
                Name = "Guest"
            };
            role1.Id = gradebook.Roles.InsertRole(role1);

            Role role2 = new Role()
            {
                Name = "SimpleUser"
            };
            role2.Id = gradebook.Roles.InsertRole(role2);

            role2.Name = "User";
            gradebook.Roles.Update(role2);

            Role role3 = new Role()
            {
                Name = "Moderator"
            };
            role3.Id = gradebook.Roles.InsertRole(role3);
            gradebook.Roles.Delete(role3);
        }

        public static void CheckSubjectTable(DBAccess.DBAGradebook gradebook)
        {
            User user1 = new User()
            {
                Name = "Milenko Kostic",
                Surname = "Milenko",
                Username = "Mile023",
                Password = "secret",
                Email = "mile023@yahoo.com"
            };
            user1.Id = gradebook.Users.Insert(user1);

            User user2 = new User()
            {
                Name = "Marko Markovic",
                Surname = "Mare",
                Username = "marecar",
                Password = "secret",
                Email = "mare@gmail.com"
            };
            user2.Id = gradebook.Users.Insert(user2);

            Subject sub1 = new Subject()
            {
                UserId = user1.Id,
                Name = "Math"
            };
            sub1.Id = gradebook.Subjects.Insert(sub1);
            sub1.Name = "Mathematics";
            gradebook.Subjects.Update(sub1);

            Subject sub2 = new Subject()
            {
                UserId = user2.Id,
                Name = "History"
            };
            sub2.Id = gradebook.Subjects.Insert(sub2);

            Subject sub3 = new Subject()
            {
                UserId = user1.Id,
                Name = "Biology"
            };
            sub3.Id = gradebook.Subjects.Insert(sub3);
            gradebook.Subjects.Delete(sub3);
        }

        public static void CheckSubjectLessonTable(DBAccess.DBAGradebook gradebook)
        {
            User user1 = new User()
            {
                Name = "Milenko Kostic",
                Surname = "Milenko",
                Username = "Mile023",
                Password = "secret",
                Email = "mile023@yahoo.com"
            };
            user1.Id = gradebook.Users.Insert(user1);

            FieldOfStudy field1 = new FieldOfStudy()
            {
                Name = "Biology"
            };
            field1.Id = gradebook.FieldOfStudies.Insert(field1);

            PClass pclass1 = new PClass()
            {
                UserId = user1.Id,
                FieldOfStudyId = field1.Id,
                Generation = new DateTime(2013, 5, 5),
                Year = "2013",
                PClassIndex = 5
            };
            pclass1.Id = gradebook.PClasses.Insert(pclass1);

            MGradebook gradebook1 = new MGradebook()
            {
                PClassId = pclass1.Id,
                SchoolYearStart = new DateTime(2013, 3, 3),
                SchoolYearEnd = new DateTime(2017, 3, 3),
                Editable = false
            };
            gradebook1.Id = gradebook.Gradebooks.Insert(gradebook1);

            Subject sub1 = new Subject()
            {
                Name = "Biology",
                UserId = user1.Id
            };
            sub1.Id = gradebook.Subjects.Insert(sub1);

            SubjectLesson subjectLession1 = new SubjectLesson()
            {
                GradebookId = gradebook1.Id,
                SubjectId = sub1.Id,
                LessonTheme = "Lorem Ipsum",
                Date = new DateTime(1993, 5, 5),
                TimeOfLesson = "15h"
            };
            subjectLession1.Id = gradebook.SubjectLessons.Insert(subjectLession1);

            SubjectLesson subjectLession2 = new SubjectLesson()
            {
                GradebookId = gradebook1.Id,
                SubjectId = sub1.Id,
                LessonTheme = "Temp",
                Date = new DateTime(1993, 5, 5),
                TimeOfLesson = "00h"
            };
            subjectLession2.Id = gradebook.SubjectLessons.Insert(subjectLession2);
            gradebook.SubjectLessons.Delete(subjectLession2);

            SubjectLesson subjectLession3 = new SubjectLesson()
            {
                GradebookId = gradebook1.Id,
                SubjectId = sub1.Id,
                LessonTheme = "Lorem Ipsum",
                Date = new DateTime(1993, 5, 5),
                TimeOfLesson = "555"
            };
            subjectLession3.Id = gradebook.SubjectLessons.Insert(subjectLession3);
            subjectLession3.TimeOfLesson = "19h";
            gradebook.SubjectLessons.Update(subjectLession3);

        }

        public static void CheckPupilTable(DBAccess.DBAGradebook gradebook)
        {
            User user1 = new User()
            {
                Name = "Angrej",
                Surname = "Angrija",
                Username = "derem ne pitam",
                Password = "domacazivotinja",
                Email = "gica@gmail.com"
            };
            user1.Id = gradebook.Users.Insert(user1);

            FieldOfStudy fos1 = new FieldOfStudy()
            {
                Name = "History"
            };
            fos1.Id = gradebook.FieldOfStudies.Insert(fos1);

            PClass pclass1 = new PClass()
            {
                UserId = user1.Id,
                FieldOfStudyId = fos1.Id,
                Generation = new DateTime(2013, 5, 5),
                Year = "2013",
                PClassIndex = 5
            };
            pclass1.Id = gradebook.PClasses.Insert(pclass1);

            Pupil pupil1 = new Pupil()
            {
                PClassId = pclass1.Id,
                Name = "Test"
            };
            pupil1.Id = gradebook.Pupils.Insert(pupil1);

            Pupil pupil2 = new Pupil()
            {
                PClassId = pclass1.Id,
                Name = "Temp"
            };
            pupil2.Id = gradebook.Pupils.Insert(pupil2);
            gradebook.Pupils.Delete(pupil2);

            Pupil pupil3 = new Pupil()
            {
                PClassId = pclass1.Id,
                Name = "Update"
            };
            pupil3.Id = gradebook.Pupils.Insert(pupil3);
            pupil3.Name = "Changed!";
            gradebook.Pupils.Update(pupil3);
        }

        public static void CheckMarksTable(DBAccess.DBAGradebook gradebook)
        {
            User user1 = new User()
            {
                Name = "Angrej",
                Surname = "Angrija",
                Username = "derem ne pitam",
                Password = "domacazivotinja",
                Email = "gica@gmail.com"
            };
            user1.Id = gradebook.Users.Insert(user1);

            FieldOfStudy fos1 = new FieldOfStudy()
            {
                Name = "History"
            };
            fos1.Id = gradebook.FieldOfStudies.Insert(fos1);

            PClass pclass1 = new PClass()
            {
                UserId = user1.Id,
                FieldOfStudyId = fos1.Id,
                Generation = new DateTime(2013, 5, 5),
                Year = "2013",
                PClassIndex = 5
            };
            pclass1.Id = gradebook.PClasses.Insert(pclass1);

            Pupil pupil1 = new Pupil()
            {
                Name = "Zdravkoni",
                PClassId = pclass1.Id
            };
            pupil1.Id = gradebook.Pupils.Insert(pupil1);

            Subject sub1 = new Subject()
            {
                Name = "Meterology",
                UserId = user1.Id
            };
            sub1.Id = gradebook.Subjects.Insert(sub1);

            Marks m1 = new Marks()
            {
                PupilId = pupil1.Id,
                SubjectId = sub1.Id,
                FinalMark = 10
            };
            m1.Id = gradebook.Markss.Insert(m1);

            Marks m2 = new Marks()
            {
                PupilId = pupil1.Id,
                SubjectId = sub1.Id,
                FinalMark = 55
            };
            m2.Id = gradebook.Markss.Insert(m2);
            gradebook.Markss.Delete(m2);

            Marks m3 = new Marks()
            {
                PupilId = pupil1.Id,
                SubjectId = sub1.Id,
                FinalMark = 0
            };
            m3.Id = gradebook.Markss.Insert(m3);
            m3.FinalMark = 9;
            gradebook.Markss.Update(m3);
        }

        public static void CheckMarks1Table(DBAccess.DBAGradebook gradebook)
        {
            User user1 = new User()
            {
                Name = "Angrej",
                Surname = "Angrija",
                Username = "derem ne pitam",
                Password = "domacazivotinja",
                Email = "gica@gmail.com"
            };
            user1.Id = gradebook.Users.Insert(user1);

            FieldOfStudy fos1 = new FieldOfStudy()
            {
                Name = "History"
            };
            fos1.Id = gradebook.FieldOfStudies.Insert(fos1);

            PClass pclass1 = new PClass()
            {
                UserId = user1.Id,
                FieldOfStudyId = fos1.Id,
                Generation = new DateTime(2013, 5, 5),
                Year = "2013",
                PClassIndex = 5
            };
            pclass1.Id = gradebook.PClasses.Insert(pclass1);

            Pupil pupil1 = new Pupil()
            {
                Name = "Zdravkoni",
                PClassId = pclass1.Id
            };
            pupil1.Id = gradebook.Pupils.Insert(pupil1);

            Subject sub1 = new Subject()
            {
                Name = "Meterology",
                UserId = user1.Id
            };
            sub1.Id = gradebook.Subjects.Insert(sub1);

            Marks m1 = new Marks()
            {
                PupilId = pupil1.Id,
                SubjectId = sub1.Id,
                FinalMark = 10
            };
            m1.Id = gradebook.Markss.Insert(m1);

            Mark mark = new Mark()
            {
                MarksId = m1.Id,
                _Mark = 8
            };
            mark.Id = gradebook.Mark1.Insert(mark);

            Mark mark1 = new Mark()
            {
                MarksId = m1.Id,
                _Mark = 0
            };
            mark1.Id = gradebook.Mark1.Insert(mark1);
            gradebook.Mark1.Delete(mark1);

            Mark mark2 = new Mark()
            {
                MarksId = m1.Id,
                _Mark = 8
            };
            mark2.Id = gradebook.Mark1.Insert(mark2);
            mark2._Mark = 9;
            gradebook.Mark1.Update(mark2);
        }

        public static void CheckFieldOfStudyHasSubjectsTable(DBAccess.DBAGradebook gradebook)
        {
            User user1 = new User()
            {
                Name = "Angrej",
                Surname = "Angrija",
                Username = "derem ne pitam",
                Password = "domacazivotinja",
                Email = "gica@gmail.com"
            };
            user1.Id = gradebook.Users.Insert(user1);

            FieldOfStudy fos1 = new FieldOfStudy()
            {
                Name = "History"
            };
            fos1.Id = gradebook.FieldOfStudies.Insert(fos1);

            Subject sub1 = new Subject()
            {
                UserId = user1.Id,
                Name = "Geology"
            };
            sub1.Id = gradebook.Subjects.Insert(sub1);

            int id = gradebook.FieldOfStudies.InsertSubject(fos1, sub1);
            gradebook.FieldOfStudies.InsertSubject(fos1, sub1);
            gradebook.FieldOfStudies.DeleteSubject(id);
        }

        public static void CheckLessonAbsentees(DBAccess.DBAGradebook gradebook)
        {
            User user1 = new User()
            {
                Name = "Milenko Kostic",
                Surname = "Milenko",
                Username = "Mile023",
                Password = "secret",
                Email = "mile023@yahoo.com"
            };
            user1.Id = gradebook.Users.Insert(user1);

            FieldOfStudy field1 = new FieldOfStudy()
            {
                Name = "Biology"
            };
            field1.Id = gradebook.FieldOfStudies.Insert(field1);

            PClass pclass1 = new PClass()
            {
                UserId = user1.Id,
                FieldOfStudyId = field1.Id,
                Generation = new DateTime(2013, 5, 5),
                Year = "2013",
                PClassIndex = 5
            };
            pclass1.Id = gradebook.PClasses.Insert(pclass1);

            MGradebook gradebook1 = new MGradebook()
            {
                PClassId = pclass1.Id,
                SchoolYearStart = new DateTime(2013, 3, 3),
                SchoolYearEnd = new DateTime(2017, 3, 3),
                Editable = false
            };
            gradebook1.Id = gradebook.Gradebooks.Insert(gradebook1);

            Subject sub1 = new Subject()
            {
                Name = "Biology",
                UserId = user1.Id
            };
            sub1.Id = gradebook.Subjects.Insert(sub1);

            SubjectLesson subjectLession1 = new SubjectLesson()
            {
                GradebookId = gradebook1.Id,
                SubjectId = sub1.Id,
                LessonTheme = "Lorem Ipsum",
                Date = new DateTime(1993, 5, 5),
                TimeOfLesson = "15h"
            };
            subjectLession1.Id = gradebook.SubjectLessons.Insert(subjectLession1);

            FieldOfStudy fos1 = new FieldOfStudy()
            {
                Name = "History"
            };
            fos1.Id = gradebook.FieldOfStudies.Insert(fos1);

            Pupil pupil1 = new Pupil()
            {
                PClassId = pclass1.Id,
                Name = "Test"
            };
            pupil1.Id = gradebook.Pupils.Insert(pupil1);

            int id = gradebook.SubjectLessons.InsertPupilAbsentee(subjectLession1, pupil1);
            gradebook.SubjectLessons.InsertPupilAbsentee(subjectLession1, pupil1);
            gradebook.SubjectLessons.DeleteAbsentee(id);
        }

        public static void CheckAllTables(DBAccess.DBAGradebook gradebook)
        {
            User user1 = new User()
            {
                Name = "Smiljko",
                Surname = "Kostic",
                Username = "skostic",
                Password = "kosta123",
                Email = "kosta29@hotmail.com"
            };
            user1.Id = gradebook.Users.Insert(user1);
            user1.Email = "kosta29@gmail.com";
            gradebook.Users.Update(user1);

            User user2 = new User()
            {
                Name = "Milan",
                Surname = "Markovic",
                Username = "milan",
                Password = "mile123",
                Email = "mile95@gmail.com"
            };
            user2.Id = gradebook.Users.Insert(user2);

            User user3 = new User()
            {
                Name = "Dragica",
                Surname = "Savic",
                Username = "Dragica90",
                Password = "dsavic",
                Email = "dsavic@gmail.com"
            };
            user3.Id = gradebook.Users.Insert(user3);

            User user4 = new User()
            {
                Name = "Temp",
                Surname = "Temp",
                Username = "Temp",
                Password = "Temp",
                Email = "temp@gmail.com"
            };
            user4.Id = gradebook.Users.Insert(user4);
            gradebook.Users.Delete(user4);

            Role role1 = new Role() {
                Name = "Guest"
            };
            role1.Id = gradebook.Roles.InsertRole(role1);

            Role role2 = new Role()
            {
                Name = "User"
            };
            role2.Id = gradebook.Roles.InsertRole(role2);

            Role role3 = new Role()
            {
                Name = "Moderator"
            };
            role3.Id = gradebook.Roles.InsertRole(role3);

            Role role4 = new Role()
            {
                Name = "Administrator"
            };
            role4.Id = gradebook.Roles.InsertRole(role4);

            gradebook.Users.InsertUserRole(user1, role1);
            gradebook.Users.InsertUserRole(user1, role2);
            gradebook.Users.InsertUserRole(user1, role4);
            gradebook.Users.InsertUserRole(user2, role2);
            int roleId = gradebook.Users.InsertUserRole(user3, role3);

            gradebook.Users.DeleteUserRole(roleId);
            gradebook.Users.InsertUserRole(user3, role2);

            Subject sub1 = new Subject()
            {
                Name = "Geometry",
                UserId = user1.Id
            };
            sub1.Id = gradebook.Subjects.Insert(sub1);

            Subject sub2 = new Subject()
            {
                Name = "Temp",
                UserId = user2.Id
            };
            sub2.Id = gradebook.Subjects.Insert(sub2);
            gradebook.Subjects.Delete(sub2);

            Subject sub3 = new Subject()
            {
                Name = "Math",
                UserId = user3.Id
            };
            sub3.Id = gradebook.Subjects.Insert(sub3);
            sub3.Name = "Mathematic";
            gradebook.Subjects.Update(sub3);

            FieldOfStudy fos1 = new FieldOfStudy()
            {
                Name = "Science"
            };
            fos1.Id = gradebook.FieldOfStudies.Insert(fos1);

            FieldOfStudy fos2 = new FieldOfStudy()
            {
                Name = "Technology"
            };
            fos2.Id = gradebook.FieldOfStudies.Insert(fos2);

            FieldOfStudy fos3 = new FieldOfStudy()
            {
                Name = "E"
            };
            fos3.Id = gradebook.FieldOfStudies.Insert(fos3);
            fos3.Name = "Engineering";
            gradebook.FieldOfStudies.Update(fos3);

            FieldOfStudy fos4 = new FieldOfStudy()
            {
                Name = "Temp"
            };
            fos4.Id = gradebook.FieldOfStudies.Insert(fos4);
            gradebook.FieldOfStudies.Delete(fos4);

            gradebook.FieldOfStudies.InsertSubject(fos1, sub1);
            int fosId = gradebook.FieldOfStudies.InsertSubject(fos2, sub1);
            gradebook.FieldOfStudies.InsertSubject(fos3, sub3);
            gradebook.FieldOfStudies.DeleteSubject(fosId);

            PClass pclass1 = new PClass()
            {
                UserId = user1.Id,
                FieldOfStudyId = fos1.Id,
                Generation = new DateTime(2013, 5, 5),
                Year = "First",
                PClassIndex = 2
            };
            pclass1.Id = gradebook.PClasses.Insert(pclass1);

            PClass pclass2 = new PClass()
            {
                UserId = user2.Id,
                FieldOfStudyId = fos2.Id,
                Generation = new DateTime(2013, 5, 5),
                Year = "Fourth",
                PClassIndex = 1
            };
            pclass2.Id = gradebook.PClasses.Insert(pclass2);
            pclass2.Year = "Third";
            gradebook.PClasses.Update(pclass2);

            PClass pclass3 = new PClass()
            {
                UserId = user3.Id,
                FieldOfStudyId = fos3.Id,
                Generation = new DateTime(2013, 5, 5),
                Year = "Temp",
                PClassIndex = 3
            };
            pclass3.Id = gradebook.PClasses.Insert(pclass3);
            gradebook.PClasses.Delete(pclass3);


            MGradebook gradebook1 = new MGradebook()
            {
                PClassId = pclass1.Id,
                SchoolYearStart = new DateTime(2013, 5, 5),
                SchoolYearEnd = new DateTime(2017, 5, 5),
                Editable = false
            };
            gradebook1.Id = gradebook.Gradebooks.Insert(gradebook1);

            MGradebook gradebook2 = new MGradebook()
            {
                PClassId = pclass2.Id,
                SchoolYearStart = new DateTime(2013, 5, 5),
                SchoolYearEnd = new DateTime(2017, 5, 5),
                Editable = false
            };
            gradebook2.Id = gradebook.Gradebooks.Insert(gradebook2);
            gradebook2.SchoolYearStart = new DateTime(2014,5,5);
            gradebook2.SchoolYearEnd = new DateTime(2018,5,5);
            gradebook.Gradebooks.Update(gradebook2);

            MGradebook gradebook3 = new MGradebook()
            {
                PClassId = pclass2.Id,
                SchoolYearStart = new DateTime(2013, 5, 5),
                SchoolYearEnd = new DateTime(2017, 5, 5),
                Editable = false
            };
            gradebook3.Id = gradebook.Gradebooks.Insert(gradebook3);
            gradebook.Gradebooks.Delete(gradebook3);

            SubjectLesson subjectLesson1 = new SubjectLesson()
            {
                GradebookId = gradebook1.Id,
                SubjectId = sub1.Id,
                LessonTheme = "Geometry 101",
                Date = new DateTime(2017,10,20),
                TimeOfLesson = "9 AM"
            };
            subjectLesson1.Id = gradebook.SubjectLessons.Insert(subjectLesson1);

            SubjectLesson subjectLesson2 = new SubjectLesson()
            {
                GradebookId = gradebook2.Id,
                SubjectId = sub1.Id,
                LessonTheme = "Mathematics 101",
                Date = new DateTime(2017, 10, 20),
                TimeOfLesson = "11 AM"
            };
            subjectLesson2.Id = gradebook.SubjectLessons.Insert(subjectLesson2);
            subjectLesson2.TimeOfLesson = "4 PM";
            gradebook.SubjectLessons.Update(subjectLesson2);

            SubjectLesson subjectLesson3 = new SubjectLesson()
            {
                GradebookId = gradebook2.Id,
                SubjectId = sub3.Id,
                LessonTheme = "Introduction to programming",
                Date = new DateTime(2017, 10, 20),
                TimeOfLesson = "2 PM"
            };
            subjectLesson3.Id = gradebook.SubjectLessons.Insert(subjectLesson3);

            SubjectLesson subjectLesson4 = new SubjectLesson()
            {
                GradebookId = gradebook1.Id,
                SubjectId = sub1.Id,
                LessonTheme = "Temp",
                Date = new DateTime(2017, 10, 20),
                TimeOfLesson = "----"
            };
            subjectLesson4.Id = gradebook.SubjectLessons.Insert(subjectLesson4);
            gradebook.SubjectLessons.Delete(subjectLesson4);

            Pupil pupil1 = new Pupil()
            {
                Name = "Pupil Name1",
                PClassId = pclass1.Id
            };
            pupil1.Id = gradebook.Pupils.Insert(pupil1);

            Pupil pupil2 = new Pupil()
            {
                Name = "Pupil",
                PClassId = pclass2.Id
            };
            pupil2.Id = gradebook.Pupils.Insert(pupil2);
            pupil2.Name = "Pupil Name2";
            gradebook.Pupils.Update(pupil2);

            Pupil pupil3 = new Pupil()
            {
                Name = "Temp",
                PClassId = pclass2.Id
            };
            pupil3.Id = gradebook.Pupils.Insert(pupil3);
            gradebook.Pupils.Delete(pupil3);

            Marks marks1 = new Marks()
            {
                PupilId = pupil1.Id,
                SubjectId = sub1.Id,
                FinalMark = 10
            };
            marks1.Id = gradebook.Markss.Insert(marks1);

            Marks marks2 = new Marks()
            {
                PupilId = pupil1.Id,
                SubjectId = sub1.Id,
                FinalMark = 9
            };
            marks2.Id = gradebook.Markss.Insert(marks2);
            marks2.FinalMark = 10;
            gradebook.Markss.Update(marks2);

            Marks marks3 = new Marks()
            {
                PupilId = pupil1.Id,
                SubjectId = sub1.Id,
                FinalMark = 3
            };
            marks3.Id = gradebook.Markss.Insert(marks3);
            gradebook.Markss.Delete(marks3);

            Mark mark1 = new Mark()
            {
                MarksId = marks1.Id,
                _Mark = 10
            };
            mark1.Id = gradebook.Mark1.Insert(mark1);

            Mark mark2 = new Mark()
            {
                MarksId = marks1.Id,
                _Mark = 9
            };
            mark2.Id = gradebook.Mark1.Insert(mark2);
            mark2._Mark = 10;
            gradebook.Mark1.Update(mark2);

            Mark mark3 = new Mark()
            {
                MarksId = marks1.Id,
                _Mark = 5
            };
            mark3.Id = gradebook.Mark1.Insert(mark3);
            gradebook.Mark1.Delete(mark3);

            gradebook.SubjectLessons.InsertPupilAbsentee(subjectLesson1, pupil1);
            gradebook.SubjectLessons.InsertPupilAbsentee(subjectLesson2, pupil2);
            int sl1Id = gradebook.SubjectLessons.InsertPupilAbsentee(subjectLesson3, pupil2);

            gradebook.SubjectLessons.DeleteAbsentee(sl1Id);
        }
    }
}