using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie_B6
{
    class Interface
    {
        private StudentGroup group1 = new StudentGroup();
        private void ShowOptions()
        {
            string[] options = {
                "Dodaj ucznia",
                "Wyświetl wszystkie oceny danego ucznia",
                "Pokaż średnią dla ucznia",
                "pokaż średnią dla przedmiotu wszystkich uczniów",
                "wyświetl liste osób, które nie zaliczyły semestru",
                "koniec"
            };
            for(int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i] + "-->" + (i + 1));
            }
            Menu();
        }
        private void Menu()
        {
            string userSelection = Console.ReadLine();
            switch (Convert.ToInt32(userSelection))
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    Nostudents();
                    GetNotes();
                    break;
                case 3:
                    Nostudents();
                    ShowAverageByName();
                    break;
                case 4:
                    Nostudents();
                    ShowAverageBySubject();
                    break;
                case 5:
                    Nostudents();
                    ShowFailed();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Nieznana opcja" + userSelection + "Spróbuj jeszcze raz");
                    Menu();
                    break;
            }
        }
        private void AddStudent()
        {
            Console.WriteLine("Podaj imię i nazwisko ucznia");
            string name = Console.ReadLine();
            string grade = "0";
            Dictionary<string, double> grades = new Dictionary<string, double>();
            while (1 == 1)
            {
                Console.WriteLine("Podaj przedmiot i ocenę");
                string subject = Console.ReadLine();
                if(subject == " ")
                {
                    break;
                }
                grade = Console.ReadLine();
                grades.Add(subject, Convert.ToDouble(grade));
            }
            group1.AddStudent(name, grades);
            ShowOptions();
        }
        private void GetNotes()
        {
            Console.WriteLine("Podaj imię i nazwisko ucznia, któego oceny chcesz wyświetlić");
            foreach(KeyValuePair<string, double> kvp in group1.GetGradesByStudentName(Console.ReadLine()))
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }
            ShowOptions();
        }
        private void ShowAverageByName()
        {
            Console.WriteLine("Podaj immię i nazwisko ucznia, którego średnią chcesz wyswietlić");
            Console.WriteLine(group1.AverageByName(Console.ReadLine()));
            ShowOptions();
        }
        private void ShowAverageBySubject()
        {
            Console.WriteLine("Podaj nazwe przedmiotu, którego średnią chcesz wyświetlić");
            Console.WriteLine(group1.AverageBySubject(Console.ReadLine()));
            ShowOptions();
        }
        private void ShowFailed()
        {
            foreach(string el in group1.FailedExam())
            {
                Console.WriteLine(el);
            }
            ShowOptions();
        }
        private void Nostudents()
        {
            if(group1.studentList.Count == 0)
            {
                Console.WriteLine("W liście nie ma żadnych studentów");
                AddStudent();
            }
        }
        public Interface()
        {
            Console.WriteLine("Witaj! w czym mogę pomóc?");
            ShowOptions();
        }
    }
}
