using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }
        public Employees Employees { get; set; }
        public List<Professions> Professions { get; set; }

        public EmployeeView() { }

        public EmployeeView( Employees e, List<Professions> p)
        {
            this.Employees = e;
            this.Professions = p;
        }       
        public EmployeeView(int i, Employees e, List<Professions> p)
        {
            this.Id = i;
            this.Employees = e;
            this.Professions = p;
        }
    }
}
