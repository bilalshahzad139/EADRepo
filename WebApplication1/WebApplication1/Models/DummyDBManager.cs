using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DummyDBManager
    {
        public static List<StudentDTO> GetStudents()
        {
            List<StudentDTO> list = new List<StudentDTO>();
            list.Add(new StudentDTO()
            {
                ID = 1,
                Name = "Student 1",
                City = "Lahore"
            });
            list.Add(new StudentDTO()
            {
                ID = 2,
                Name = "Student 2",
                City = "Lahore"
            });
            list.Add(new StudentDTO()
            {
                ID = 3,
                Name = "Student 3",
                City = "Lahore"
            });


            return list;
        }

        public static Boolean ValidateUser(String login, String password)
        {
            if (login == "admin" && password == "admin")
                return true;
            else
                return false;
        }
    }
}