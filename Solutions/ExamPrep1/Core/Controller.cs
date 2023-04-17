using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private readonly SubjectRepository subjects;
        private readonly StudentRepository students;
        private readonly UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            string result = string.Empty;

            if(students.FindByName($"{firstName} {lastName}") != null)
            {
                result = string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            else
            {
                IStudent student = new Student(students.Models.Count + 1, firstName, lastName);

                students.AddModel(student);

                result = string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, nameof(StudentRepository));
            }

            return result.TrimEnd();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            string result = string.Empty;
            if(subjectType != nameof(TechnicalSubject)
                && subjectType != nameof(HumanitySubject)
                && subjectType != nameof(EconomicalSubject))
            {
                result = string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            else if(subjects.FindByName(subjectName) != null)
            {
                result = string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            else
            {
                ISubject subject;
                int subjectId = subjects.Models.Count + 1;
                if(subjectName == nameof(TechnicalSubject))
                {
                    subject = new TechnicalSubject(subjectId, subjectName);
                }
                else if(subjectName == nameof(HumanitySubject))
                {
                    subject = new HumanitySubject(subjectId, subjectName);
                }
                else
                {
                    subject = new EconomicalSubject(subjectId, subjectName);
                }

                subjects.AddModel(subject);

                result = string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, nameof(SubjectRepository));
            }

            return result.TrimEnd();
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            string result = string.Empty;

            if(universities.FindByName(universityName) != null)
            {
                result = string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            else
            {
                List<int> requiredSubjectIds = new List<int>();
                foreach(var subjectName in requiredSubjects)
                {
                    requiredSubjectIds.Add(subjects.FindByName(subjectName).Id);
                }

                IUniversity university = new University(universities.Models.Count + 1, universityName, category, capacity, requiredSubjectIds);

                universities.AddModel(university);

                result = string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, nameof(UniversityRepository));
            }

            return result.TrimEnd();
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string result = string.Empty;

            IStudent student = students.FindByName(studentName);
            IUniversity university = universities.FindByName(universityName);

            if(students.FindByName(studentName) == null)
            {
                result = string.Format(OutputMessages.StudentNotRegitered, studentName.Split(" ")[0], studentName.Split(" ")[1]);
            }
            else if(universities.FindByName(universityName) == null)
            {
                result = string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            else if(!university.RequiredSubjects.All(x => student.CoveredExams.Any(e => e == x)))
            {
                result = string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            else if(student.University != null && student.University.Name ==  universityName)
            {
                result = string.Format(OutputMessages.StudentAlreadyJoined, studentName.Split(" ")[0], studentName.Split(" ")[1], universityName);
            }
            else
            {
                student.JoinUniversity(university);

                result = string.Format(OutputMessages.StudentSuccessfullyJoined, studentName.Split(" ")[0], studentName.Split(" ")[1], universityName);
            }

            return result.TrimEnd();
        }

        public string TakeExam(int studentId, int subjectId)
        {
            string result = string.Empty;

            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);

            if(student == null)
            {
                result = string.Format(OutputMessages.InvalidStudentId);
            }
            else if(subject == null)
            {
                result = string.Format(OutputMessages.InvalidSubjectId);
            }
            else if(student.CoveredExams.Any(x => x == subjectId))
            {
                result = string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }
            else
            {
                student.CoverExam(subject);

                result = string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
            }

            return result.TrimEnd();
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);

            StringBuilder result = new StringBuilder();
            result.AppendLine($"*** {university.Name} ***");
            result.AppendLine($"Profile: {university.Category}");
            result.AppendLine($"Students admitted: {students.Models.Where(x => x.University == university).Count()}");
            result.AppendLine($"University vacancy: {university.Capacity - students.Models.Where(x => x.University == university).Count()}");

            return result.ToString().TrimEnd();
        }
    }
}
