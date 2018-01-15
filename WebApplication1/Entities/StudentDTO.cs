using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class StudentDTO
    {

        public int ID
        {
            get;
            set;
        }

        public String Name { get; set; }
        public String City { get; set; }

        public int Age { get; set; }
    }
}
