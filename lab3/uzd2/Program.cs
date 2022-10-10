using System;
using System.Linq;
using System.Text;

namespace uzd2
{
    class Person
    {
        private string Name;
        private string Address;

        public Person(string Name, string Address)
        {
            this.Name = Name;
            this.Address = Address;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetAddress()
        {
            return Address;
        }

        public void SetAddress(string Address)
        {
            this.Address = Address;
        }

        public override string ToString()
        {
            return $"{Name}({Address})";
        }

        public virtual void Hello()
        {
            Console.WriteLine("Labas, žmogau!");
        }

        public virtual void Hello(string Task)
        {
            Console.WriteLine("Labas, žmogau! Turi padaryti " + Task);
        }
    }

    class Student : Person
    {
        private int NumCourses = 0;
        private string[] Courses = { };
        private int[] Grades = { };

        public Student(string Name, string Address) : base(Name, Address) { }

        public void AddCourseGrade(string Course, int Grade)
        {
            if (NumCourses < 30)
            {
                Courses = Courses.Append(Course).ToArray();
                Grades = Grades.Append(Grade).ToArray();
                NumCourses++;

                Console.WriteLine($"Studentui {GetName()} pridėtas kurso {Course} pažymys {Grade}.");
            }
            else
            {
                Console.WriteLine("Studentas negali turėti daugiau kaip 30 kursų.");
            }
        }

        public void PrintGrades()
        {
            Console.WriteLine("Studento pažymiai: " + string.Join(", ", Grades));
        }

        public double GetAverageGrade()
        {
            return Grades.Average();
        }

        public override string ToString()
        {
            return $"Student: {GetName()}({GetAddress()})";
        }

        public override void Hello()
        {
            Console.WriteLine("Labas, studente!");
        }

        public override void Hello(string Task)
        {
            Console.WriteLine("Labas, studente! Turi padaryti " + Task);
        }
    }

    class Teacher : Person
    {
        private int NumCourses = 0;
        private string[] Courses = { };

        public Teacher(string Name, string Address) : base(Name, Address) { }

        public bool AddCourse(string Course)
        {
            if (NumCourses < 5)
            {
                if (!Courses.Contains(Course))
                {
                    Courses = Courses.Append(Course).ToArray();
                    NumCourses++;

                    Console.WriteLine($"Mokytojui {GetName()} pridėtas kursas {Course}.");
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Mokytojas negali dėstyti daugiau kaip 5 kursus.");
            }

            return false;
        }

        public bool RemoveCourse(string Course)
        {
            if (Courses.Contains(Course))
            {
                Courses = Courses.Where(val => val != Course).ToArray();
                NumCourses--;

                Console.WriteLine($"Mokytojui {GetName()} ištrintas kursas {Course}.");
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Teacher: {GetName()}({GetAddress()})";
        }

        public override void Hello()
        {
            Console.WriteLine("Labas, mokytojau!");
        }

        public override void Hello(string Task)
        {
            Console.WriteLine("Labas, mokytojau! Turi padaryti " + Task);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            // Testavimas. Sukurti objektus.
            Teacher mokytojas1 = new Teacher("Juozas", "H. Manto g. 84, Klaipėda");
            Student studentas1 = new Student("Tomas", "Bijūnų g. 17, Klaipėda");
            Person zmogus1 = new Person("Antanas", "Bijūnų g. 29, Klaipėda");

            // Atlikti keletą veiksmų su kursais (Student ir Teacher klasės objektuose).

            // Pridėti kursus mokytojui.
            mokytojas1.AddCourse("Matematika");
            mokytojas1.AddCourse("Informatika");

            // Pridėti ir ištrinti kursą.
            mokytojas1.AddCourse("Geografija");
            mokytojas1.RemoveCourse("Geografija");

            // Bandyti pridėti jau egzistuojantį kursą.
            bool KursasPridetas = mokytojas1.AddCourse("Informatika");
            Console.WriteLine(KursasPridetas);

            // Bandyti ištrinti kursą, kurio nėra.
            bool KursasIstrintas = mokytojas1.RemoveCourse("Istorija");
            Console.WriteLine(KursasIstrintas);

            // Pridėti pažymius studentui.
            studentas1.AddCourseGrade("Matematika", 9);
            studentas1.AddCourseGrade("Informatika", 10);
            studentas1.AddCourseGrade("Geografija", 8);
            studentas1.AddCourseGrade("Fizika", 6);

            // Išvesti studento pažymius.
            studentas1.PrintGrades();

            // Skaičiuoti studento pažymių vidurkį.
            double vidurkis = studentas1.GetAverageGrade();
            Console.WriteLine("Studento pažymių vidurkis: " + vidurkis);

            // Išvesti per ToString() metodą.
            // Parodyti paveldėjimo atvejį.
            Console.WriteLine(mokytojas1.ToString());
            Console.WriteLine(studentas1.ToString());
            Console.WriteLine(zmogus1.ToString());

            // Realizuotam modeliui sukurkite polimorfizmo atvejį.
            // Čia metodas Hello() gali priimti parametrą, arba galima ir be jo.
            zmogus1.Hello();
            zmogus1.Hello("pietus");

            studentas1.Hello();
            studentas1.Hello("matematikos namų darbus");

            mokytojas1.Hello();
            mokytojas1.Hello("kursų ataskaitą");
        }
    }
}
