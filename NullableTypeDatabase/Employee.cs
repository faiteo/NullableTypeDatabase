using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypeDatabase
{
    public class Employee
    {
        int empID;
        string firstName;
        string lastName;
        int? married;
        int? age;
        //bool? married;




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
