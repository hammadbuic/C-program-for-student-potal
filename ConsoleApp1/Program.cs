using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
namespace ConsoleApplication3
{
    
    class Program
    {
        static void topThree(ref int firstIndex,ref int secondIndex,ref int thirdIndex, List<Student> list)
        {
            firstIndex = 0;
            secondIndex = 0;
            thirdIndex = 0;
            for(int i =1;i<list.Count;i++)
            {
                if(list[firstIndex].gpa<list[i].gpa)
                {
                    thirdIndex = secondIndex;
                    secondIndex = firstIndex;
                    firstIndex = i;
                }
                else if(list[secondIndex].gpa<list[i].gpa && list[secondIndex].gpa<list[firstIndex].gpa && list[firstIndex].gpa != list[i].gpa || list[secondIndex].gpa == list[firstIndex].gpa)
                {
                    secondIndex = i;
                }
                else if(list[thirdIndex].gpa<list[i].gpa && list[thirdIndex].gpa < list[secondIndex].gpa && list[secondIndex].gpa != list[i].gpa || list[thirdIndex].gpa == list[secondIndex].gpa)
                {
                    thirdIndex = i;
                }
            }
        }
        static void writeData( Student s, StreamWriter writer)
        {
            writer.WriteLine(s.id);
            writer.WriteLine(s.name);
            writer.WriteLine(s.gpa);
            writer.WriteLine(s.department);
            writer.WriteLine(s.university);
            writer.WriteLine(s.attendance);
            writer.Close();
            writer.Dispose();
        }
        static void readData(StreamReader reader,ref List<Student> list)
        {
            while (reader.EndOfStream != true)
            {
                Student s = new Student();
                s.id = reader.ReadLine();
                s.name = reader.ReadLine();
                s.gpa = Convert.ToDouble(reader.ReadLine());
                s.department = reader.ReadLine();
                s.university = reader.ReadLine();
                s.attendance = Convert.ToBoolean(reader.ReadLine());
                list.Add(s);
            }
            reader.Close();
        }
        static void Main(string[] args)
        {
            int choice;
            char menuChoice;
            Console.WriteLine("\n\t\t\tStudent Information System\t\t\t");
            do
            {
                Console.Write("\nPress 1) to create Student Profile\nPress 2) to search record of Student\nPress 3) to Delete Student Record\nPress 4) to see list of top 3 Students of a class\nPess 5) to Mark attandance of a Student\n Press 6) to view attendance\n\tPress any other key to exit the program\nYour Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

                if (choice == 1)
                {
                    Student sw = new Student();
                    Console.WriteLine("\n\t\t\t Please Provide Credentials of the Student\t\t\t\n");
                    Console.Write(" Enter Student ID: ");
                    sw.id = Console.ReadLine();
                    Console.Write(" Enter Student Name: ");
                    sw.name = Console.ReadLine();
                    Console.Write("Enter CGPA of the Student: ");
                    sw.gpa = Convert.ToDouble(Console.ReadLine());
                    Console.Write(" Enter Department of the Student: ");
                    sw.department = Console.ReadLine();
                    Console.Write(" Enter University of the Student: ");
                    sw.university = Console.ReadLine();
                    // Read Data and make filing structure
                    // use @ sign to use path

                    StreamWriter writer = new StreamWriter(@"C:\\Users\\hamma\\OneDrive\\Desktop\\File.txt", append: true);
                    writeData(sw, writer);
                    Console.Clear();
                    Console.WriteLine("\nRecord of the student is saved");
                }
                else if (choice == 2)
                {
                    int searchCoice;
                    Console.Write("\nPress1) to Search by ID\nPress 2) to search by Name\nPress 3) to list all the students\nYour Choice: ");
                    searchCoice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    if (searchCoice == 1)
                    {

                        StreamReader reader = new StreamReader(@"C:\\Users\\hamma\\OneDrive\\Desktop\\File.txt");
                        List<Student> list = new List<Student>();
                        readData(reader, ref list);
                        string studentId;
                        Console.Write("\nPlease Enter Student ID: ");
                        //Read Student ID
                        studentId = Console.ReadLine();
                        for (int a = 0; a <= list.Count; a++)
                        {
                            try
                            {
                                if (list[a].id == studentId)
                                {
                                    Console.WriteLine("\n\t\t\\tRecord Number: " + (a + 1));
                                    Console.WriteLine("Student Id: " + list[a].id + "  Student Name: " + list[a].name + "  Student CGPA" + list[a].gpa + "  Student Department: " + list[a].department + "  Student University" + list[a].university);
                                }
                            }
                            catch
                            {
                                continue;

                            }
                        }

                    }
                    else if (searchCoice == 2)
                    {
                        StreamReader reader = new StreamReader(@"C:\\Users\\hamma\\OneDrive\\Desktop\\File.txt");
                        List<Student> list = new List<Student>();
                        readData(reader, ref list);
                        String studentName;
                        Console.Write("\nPlease Enter Student Name: ");
                        // Read Student Name
                        studentName = Console.ReadLine();

                        for (int a = 0; a < list.Count; a++)
                        {
                            try
                            {
                                if (list[a].name == studentName)
                                {
                                    Console.WriteLine("\n\t\t\\tRecord Number: " + (a + 1));
                                    Console.WriteLine("Student Id: " + list[a].id + "  Student Name: " + list[a].name + "  Student CGPA" + list[a].gpa + "  Student Department: " + list[a].department + "  Student University" + list[a].university);
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }

                    }
                    else if (searchCoice == 3)
                    {
                        StreamReader reader = new StreamReader(@"C:\\Users\\hamma\\OneDrive\\Desktop\\File.txt");
                        List<Student> list = new List<Student>();
                        readData(reader, ref list);
                        // List all the students
                        for (int a = 0; a < list.Count; a++)
                        {
                            Console.WriteLine("\n\t\t\\tRecord Number: " + (a + 1));
                            Console.WriteLine("Student Id: " + list[a].id + "  Student Name: " + list[a].name + "  Student CGPA:" + list[a].gpa + "  Student Department: " + list[a].department + "  Student University" + list[a].university);
                        }
                    }
                }
                else if (choice == 3)
                {
                    // delete record of the student...

                    StreamReader reader = new StreamReader(@"C:\\Users\\hamma\\OneDrive\\Desktop\\File.txt");
                    //Student[] s = new Student[10];
                    List<Student> list = new List<Student>();
                    readData(reader, ref list);
                    String deleteId;
                    Console.Write("\nPlease Enter ID of the Student: ");
                    //Read ID of the Student to delete
                    deleteId = Console.ReadLine();
                    StreamWriter writer = new StreamWriter(@"C:\\Users\\hamma\\OneDrive\\Desktop\\File.txt");
                    writer.Write("");
                    writer.Close();
                    for (int a = 0; a < list.Count; a++)
                    {
                        if (list[a].id == deleteId)
                        {
                            list.RemoveAt(a);
                        }
                    }
                    writer = File.AppendText(@"C:\\Users\\hamma\\OneDrive\\Desktop\\File.txt");
                    for (int x = 0; x < list.Count; x++)
                    {
                        writer.WriteLine(list[x].id);
                        writer.WriteLine(list[x].name);
                        writer.WriteLine(list[x].gpa);
                        writer.WriteLine(list[x].department);
                        writer.WriteLine(list[x].university);
                        writer.WriteLine(list[x].attendance);
                    }
                    writer.Close();
                }
                else if (choice == 4)
                {
                    // Display Top 3 Students
                    StreamReader reader = new StreamReader(@"C:\\Users\\hamma\\OneDrive\\Desktop\\File.txt");
                    List<Student> list = new List<Student>();
                    readData(reader, ref list);
                    int firstLargest = -1;
                    int secondLargest = -1;
                    int thirdLargest = -1;
                    topThree(ref firstLargest, ref secondLargest, ref thirdLargest, list);
                    Console.WriteLine("\n\t\t\tFirst Student by CGPA \n\nStudent Name: " + list[firstLargest].name + "\tStudent ID: " + list[firstLargest].id + "  Student CGPA: " + list[firstLargest].gpa + "  Student Department: " + list[firstLargest].department + "  Student University: " + list[firstLargest].university);
                    Console.WriteLine("\n\t\t\tSecond Student by CGPA \n\nStudent Name: " + list[secondLargest].name + "\tStudent ID: " + list[secondLargest].id + "  Student CGPA: " + list[secondLargest].gpa + "  Student Department: " + list[secondLargest].department + "  Student University: " + list[secondLargest].university);
                    Console.WriteLine("\n\t\t\tThird Student by CGPA \n\nStudent Name: " + list[thirdLargest].name + "\tStudent ID: " + list[thirdLargest].id + "  Student CGPA: " + list[thirdLargest].gpa + "  Student Department: " + list[thirdLargest].department + "  Student University: " + list[thirdLargest].university);
                }
                else if (choice == 5)
                {
                    // Show List of Students and mark their attendance
                    String attendance;
                    StreamReader reader = new StreamReader(@"C:\\Users\\hamma\\OneDrive\\Desktop\\File.txt");
                    List<Student> list = new List<Student>();
                    readData(reader, ref list);
                    for (int a = 0; a < list.Count; a++)
                    {
                        Console.WriteLine("\n\t\t\\tRecord Number: " + (a + 1));
                        Console.WriteLine("Student Id: " + list[a].id + "  Student Name: " + list[a].name + "  Student CGPA" + list[a].gpa + "  Student Department: " + list[a].department + "  Student University" + list[a].university);
                        Console.Write("Please mark the attendance of Student(ABSENT by Default): ");
                        attendance = Console.ReadLine();
                        if (attendance.ToLower() == "absent")
                        {
                            list[a].attendance = false;
                        }
                        else if (attendance.ToLower() == "present")
                        {
                            list[a].attendance = true;
                        }
                    }
                    StreamWriter writer = new StreamWriter(@"C:\\Users\\hamma\\OneDrive\\Desktop\\File.txt");
                    writer.Write("");
                    writer.Close();
                    writer = File.AppendText(@"C:\\Users\\hamma\\OneDrive\\Desktop\\File.txt");
                    for (int x = 0; x < list.Count; x++)
                    {
                        writer.WriteLine(list[x].id);
                        writer.WriteLine(list[x].name);
                        writer.WriteLine(list[x].gpa);
                        writer.WriteLine(list[x].department);
                        writer.WriteLine(list[x].university);
                        writer.WriteLine(list[x].attendance);
                    }
                    writer.Close();
                }
                else if (choice == 6)
                {
                    // Show Attendance
                    StreamReader reader = new StreamReader(@"C:\\Users\\hamma\\OneDrive\\Desktop\\File.txt");
                    List<Student> list = new List<Student>();
                    readData(reader, ref list);
                    for (int a = 0; a < list.Count; a++)
                    {
                        Console.WriteLine("\nStudent ID: "+list[a].id);
                        Console.WriteLine("\nStudent Name: "+list[a].name);
                        if (list[a].attendance == true)
                        {
                            Console.WriteLine("Student Atttendance: PRESENT");
                        }
                        else if (list[a].attendance == false)
                        {
                            Console.WriteLine("Student Attendance: ABSENT");
                        }
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("Do you wanna return to main Menu(Y/N)? : ");
                menuChoice = Convert.ToChar(Console.ReadLine());
                Console.Clear();
            } while (menuChoice == 'Y' || menuChoice == 'y');
        }
    }
    class Student
    {
        private String _id;
        private String _name;
        private double _gpa;
        private string _department;
        private string _university;
        private bool _attendance;
        public String id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public String name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public double gpa
        {

            get
            {
                return _gpa;
            }
            set
            {
                _gpa = value;
            }
        }
        public string department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
            }
        }
        public string university
        {
            get
            {
                return _university;
            }
            set
            {
                _university = value;
            }
        }
        public bool attendance
        {
            get
            {
                return _attendance;
            }
            set
            {
                _attendance = value;
            }
        }
    }
}
