using System;
using System.Collections.Generic;


enum Menu
{
    ResisterForStudent = 1,
    ResisterForTeacher,
    GetListPersons
}
enum Activity
{
    Sport = 1,
    WaiKruceremony,
    club,
    academic
}
namespace HW2_1satcode
{
    class Program
    {
        static PersonList personList;

        static void Main(string[] args)
        {
            
            PrintMenuScreen();
        }
        static void PreparePersonListWhenProgramIsLoad()
        {
            Program.personList = new PersonList();
        }
        static void PrintMenuScreen()
        {
            Console.Clear();
            PrintHeader();
            PrintMenuScreen();
            InputMenuFromKeyboard();
        }
        static void PrintHeader()
        {
            Console.WriteLine("Welcome to registration  student activities.");
            Console.WriteLine("-------------------------------------------");
        }
        static void PrintListMenu()
        {
            Console.WriteLine("1.Registration for student.");
            Console.WriteLine("2.Registration for teacher.");
        }
        static void PrinListMenuActivity()
        {
            Console.WriteLine("1.Sport");
            Console.WriteLine("2.Wai Kru ceremony");
            Console.WriteLine("3.Club");
            Console.WriteLine("4.Academic");

        }
        static void InputMenuFromKeyboard()
        {
            Console.WriteLine("Please select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));
            PresentMenu(menu);
            Console.WriteLine("Please select menu Activity: ");
            Activity activity = (Activity)(int.Parse(Console.ReadLine()));
            SelectActivities(activity);
        }
        static void SelectActivities(Activity activity) 
        {
            if (activity == Activity.Sport)
            {
                Console.WriteLine("Successful registration : Sport");
            }
            else if (activity == Activity.WaiKruceremony)
            {
                Console.WriteLine("Successful registration : Wai Kru ceremony ");
            }
            else if (activity == Activity.club)
            {
                Console.WriteLine("Successful registration : Club");
            }
            else if (activity == Activity.academic)
            {
                Console.WriteLine("Successful registration : Academic");
            }
            else
            {
                Console.WriteLine("Registration Failedc");
            }
        }
        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.ResisterForStudent)
            {
                ShowInputRegistrationForStudentScreen();
            }
            else if (menu == Menu.ResisterForTeacher)
            {
                ShowInputRegistrationForTeacherScreen();
            }
            else if (menu == Menu.GetListPersons)
            {
                ShowGetListPersonScreen();
            }
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }
        }
        static void ShowGetListPersonScreen()
        {
            Console.Clear();
            Program.personList.FetchPersonList();
            InputExitFromKeyboard();
        }
        static void InputExitFromKeyboard()
        {
            string text = "";
            while (text != "exit")
            {
                Console.Write("Input: ");
                text = Console.ReadLine();
            }
            Console.Clear();
            PrintMenuScreen();
        }
        static void ShowInputRegistrationForTeacherScreen()
        {
            Console.Clear();
            PrintHeaderRegisterTeacher();

            int totalTeacher = TotalForTeacher();
            InputForTeacherFromKeyboard(totalTeacher);
        }
        static void InputForTeacherFromKeyboard(int totalTeacher)
        {
            for (int i = 0; i < totalTeacher; i++)
            {
                Console.Clear();
                PrintHeaderRegisterTeacher();

                Teacher teacher = CreateForTeacher();
                Program.personList.AddNewPerson(teacher);
            }
        }
        static Teacher CreateForTeacher()
        {
            return new Teacher(InputName(), InputAddress(), InputCitizenID(), InputEmployeetID());
        }
        static string InputEmployeetID()
        {
            Console.Write("EmployeeID: ");
            return Console.ReadLine();
        }
        static int TotalForTeacher()
        {
            Console.Write("Input total new Teacher: ");
            return int.Parse(Console.ReadLine());
        }
        static void ShowInputRegistrationForStudentScreen()
        {
            Console.Clear();
            PrintHeaderRegisretStudent();

            int totalStudent = TotalForStudent();

            InputNewStudentFromKeyboard(totalStudent);
        }
        static void InputNewStudentFromKeyboard(int totalStudent)
        {
            for (int i = 0; i < totalStudent; i++)
            {
                Console.Clear();
                PrintHeaderRegisretStudent();
                Student student = CreateForStudent();
                Program.personList.AddNewPerson(student);
            }
        }

        static Student CreateForStudent()
        {
            return new Student(InputName(), InputAddress(), InputCitizenID(), InputStudentID());
        }
        static string InputName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }
        static string InputAddress()
        {
            Console.Write("Address: ");
            return Console.ReadLine();
        }
        static string InputCitizenID()
        {
            Console.Write("CitizenID: ");
            return Console.ReadLine();
        }
        static string InputStudentID()
        {
            Console.Write("StudentID: ");
            return Console.ReadLine();
        }

        static int TotalForStudent()
        {
            Console.Write("Input total new student: ");
            return int.Parse(Console.ReadLine());
        }
        static void PrintHeaderRegisretStudent()
        {
            Console.WriteLine("Register new Student");
            Console.WriteLine("--------------------");
        }
        static void PrintHeaderRegisterTeacher()
        {
            Console.WriteLine("Register new Teacher");
            Console.WriteLine("--------------------");
        }
        static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu incorrect Please try again.");
        }
        class Person
        {
            protected string name;
            protected string address;
            protected string citizenID;

            public Person(string name, string address, string citizenID)
            {
                this.name = name;
                this.address = address;
                this.citizenID = citizenID;
            }

            public string GetName()
            {
                return this.name;
            }
        }

        class Student : Person
        {
            private string studentID;

            public Student(string name, string address, string citizenID, string studentID) : base(name, address, citizenID)
            {
                this.studentID = studentID;
            }
        }

        class PersonList
        {
            private List<Person> personList;

            public PersonList()
            {
                this.personList = new List<Person>();
            }

            public void AddNewPerson(Person person)
            {
                this.personList.Add(person);
            }

            public void FetchPersonList()
            {
                Console.WriteLine("List Persons");
                Console.WriteLine("------------");

                foreach (Person person in this.personList)
                {
                    if (person is Student)
                    {
                        Console.WriteLine("Name: {0} \n Type: Student", person.GetName());
                    }
                    else if (person is Teacher)
                    {
                        Console.WriteLine("Name: {0} \n Type: Teacher", person.GetName());
                    }
                }
            }
        }

        class Teacher : Person
        {
            private string employeeID;

            public Teacher(string name, string address, string citizenID, string employeeID) : base(name, address, citizenID)
            {
                this.employeeID = employeeID;
            }
        }

    }
    
}
