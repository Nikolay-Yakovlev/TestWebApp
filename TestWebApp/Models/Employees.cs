using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TestWebApp.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ProfessionID { get; set; }


    }
}
