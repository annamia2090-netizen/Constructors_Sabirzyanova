using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Contructors_Sabirzyanova;

namespace Contructors_Sabirzyanova.Classes
{
    public class Student
    {
        public string Firstname = "";
        public string Lastname = "";
        public string Surname = "";
        public bool Scholarship = false;
        public int Course = 4;
        public string ImagePath = "/Images/ic_user.png";
        public Student(string Firstname, string Lastname, string Surname)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Surname = Surname;
        }
        public Student(string Firstname, string Lastname, string Surname, bool Scholarship) 
            : this(Firstname, Lastname, Surname)
        { 
            this.Scholarship = Scholarship;
        }
        public Student(string Firstname, string Lastname, string Surname, bool Scolarship, int Course)
            : this(Firstname, Lastname, Surname, Scolarship)
        {
            this.Course = Course;
        }
        public Student(string Firstname, string Lastname, string Surname, bool Scholarship, int Course, string ImagePath)
            : this(Firstname, Lastname, Surname, Scholarship, Course)
        {
            this.ImagePath = ImagePath;
        }
        public string GetFIO()
        {
            return $"{Lastname}{Firstname}{Surname}";
        }
    }
}
