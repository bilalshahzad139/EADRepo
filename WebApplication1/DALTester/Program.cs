using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTester
{
    class Program
    {
        static void Main(string[] args)
        {

            var students = DAL.StudentDAL.GetAllStudents();

            Console.ReadKey();
        }
    }
}
