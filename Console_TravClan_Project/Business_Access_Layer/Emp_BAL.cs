using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;
using class_Models;


namespace Business_Access_Layer
{
    public class Emp_BAL:IEmp_BALr
    {
        private readonly EmpDataManager _empData = new EmpDataManager();
        public  int Add_Employee_BAL(int e_Id, String e_fname, string e_lname, DateTime e_dob, long e_contact, string e_address)
        {
            int emp2 = _empData.Add_Employee_DAL(e_Id++, e_fname, e_lname, e_dob, e_contact, e_address);
            return emp2;
        }
        public  void Edit_Employee_BAL(Employee emp_to_change)
        {

            _empData.Edit_Employee_DAL(emp_to_change);
        }

        public int Delete_Employee_BAL(int e_Id)
        {
          
            _empData.Delete_Employee_DAL(e_Id);
            return 1;
        }

        public  void ViewAllEmployees_BAL()
        {
            
            _empData.ViewAllEmployees_DAL();


        }

        public Employee GetEmployeeById_BAL(int id)
        {
            Employee emp = _empData.GetEmployeeById_DAL(id);
            return emp;
        }
    }
}
