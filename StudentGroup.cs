using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie_B6
{
    class StudentGroup
    {
        public Dictionary<string, StudentGradeSheet> studentList = new Dictionary<string, StudentGradeSheet>();
        public void AddStudent(string name, Dictionary<string, double> grades)
        {
            StudentGradeSheet studentGrades = new StudentGradeSheet(grades);
            studentList.Add(name, studentGrades);
        }
        public Dictionary<string, double> GetGradesByStudentName(string name)
        {
            foreach(KeyValuePair<string, StudentGradeSheet> kvp in studentList)
            {
                if(kvp.Key == name)
                {
                    return kvp.Value.notes;
                }
            }
            return null;
        }
        public double AverageByName(string name)
        {
            if (studentList.ContainsKey(name))
            {
                return studentList[name].Average();
            }
            return -1;
        }
        public double AverageBySubject(string subject)
        {
            double average = 0;
            foreach(KeyValuePair<string, StudentGradeSheet> kvp in studentList)
            {
                average += kvp.Value.GetNote(subject);
            }
            return average;
        }
        public List<string> FailedExam()
        {
            List<string> names = new List<string>();
            foreach(KeyValuePair<string, StudentGradeSheet> kvp in studentList)
            {
                if(kvp.Value.Pass() == false)
                {
                    names.Add(kvp.Key);
                }
            }
            return names;
        }
    }
}
