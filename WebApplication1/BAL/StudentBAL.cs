using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
namespace BAL
{
    public class StudentBAL
    {
        public Boolean ValidateUser(String login, String password)
        {
            return StudentDAL.ValidateUser(login, password);
        }
        public List<StudentDTO> GetAllStudents()
        {
            return StudentDAL.GetAllStudents();
        }
    }
}
