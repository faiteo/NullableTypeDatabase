using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypeDatabase
{
    public class Employee
    {
        private int empID;
        private string firstName;
        private string lastName;
        private int? married;
        private int? age;
        

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
      

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
 

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }


        public int? Married
        {
            get { return married; }
            set { married = value; }
        }

        public int? Age
        {
            get { return age; }
            set { age = value; }
        }

        //public bool? Married
        //{
        //    get { return married1; }
        //    set { married1 = value; }
        //}
    }
}
