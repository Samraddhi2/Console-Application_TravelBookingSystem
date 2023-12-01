using class_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class EmpDataManager : IEmpDataManager
    {
        public int Add_Employee_DAL(int e_Id, String e_fname, string e_lname, DateTime e_dob, long e_contact, string e_address)
        {
            employee.Add(new Employee() { emp_id = e_Id, emp_fname = e_fname, emp_lname = e_lname, emp_dob = e_dob, emp_address = e_address, emp_contact = e_contact });
            return 1;
        }

        public void ViewAllEmployees_DAL()
        {
            foreach(Employee e in employee)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public List<Employee> employee = new List<Employee>() {
        

        new Employee() { emp_id= 1, emp_fname="Anushka",emp_lname= "Dhotre",emp_dob= DateTime.Parse("5/2/2001"), emp_address="Kolhapur",emp_contact= 83000033003},
        new Employee() { emp_id = 2,emp_fname = "Suhani",emp_lname = "Gaikwad",emp_dob = DateTime.Parse("09/2/2001"),emp_address = "Pune",emp_contact = 2178638648},
        new Employee() { emp_id = 3,emp_fname = "Sakshi",emp_lname = "Bankar",emp_dob = DateTime.Parse("23/7/2001"),emp_address = "Nasik",emp_contact = 9875445678},
        new Employee() { emp_id = 4,emp_fname = "Sakshi",emp_lname = "Sudame",emp_dob = DateTime.Parse("12/5/2001"),emp_address = "AhmadNagar",emp_contact = 5797564869}

    };

        
         public void Edit_Employee_DAL(Employee e)
        {
            Employee emp_main = employee.FirstOrDefault(X => X.emp_id == e.emp_id);
            int index = employee.IndexOf(emp_main);

            employee[index].emp_fname = emp_main.emp_fname;
            employee[index].emp_lname= emp_main.emp_lname;
            employee[index].emp_address= emp_main.emp_address;
            employee[index].emp_dob= emp_main.emp_dob;
            employee[index].emp_contact= emp_main.emp_contact;
        }

        public int Delete_Employee_DAL(int e_Id)
        {
            var employeeToDelete = employee.Find(emp => emp.emp_id == e_Id);
            if (employeeToDelete != null)
            {
                employee.Remove(employeeToDelete);
               
            }
            else
            {
                Console.WriteLine("This ID is not found\n");
                return 0;
            }
            return 1;
        }

        public Employee GetEmployeeById_DAL(int id)
        {
            Employee lstemployee = employee.FirstOrDefault(e=>e.emp_id == id);
            if (employee != null)
            {
                return lstemployee;
            }
            return null;
        }

    }
}
