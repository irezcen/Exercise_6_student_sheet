using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie_B6
{
    class StudentGradeSheet
    {
        public double average = 0;
        public Dictionary<string, double> notes = new Dictionary<string, double>();
        public void AddNote(string subject, int note)
        {
            this.notes.Add(subject, note);
        }
        public double GetNote(string subject)
        {
            foreach(KeyValuePair<string, double> kvp in notes)
            {
                if(kvp.Key == subject)
                {
                    return kvp.Value;
                }
            }
            return -1;
        }
        public double Average()
        {
            foreach(KeyValuePair<string, double> kvp in notes)
            {
                average += kvp.Value;
            }
            average = average / notes.Count;
            return average;
        }
        public bool Pass()
        {
            if(Average() >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public StudentGradeSheet(Dictionary<string, double> grades)
        {
            foreach(KeyValuePair<string, double> kvp in grades)
            {
                notes.Add(kvp.Key, kvp.Value);
            }
        }
        public List<string> list = new List<string>();
    }
}
