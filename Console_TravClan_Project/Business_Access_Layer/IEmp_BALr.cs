using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using class_Models;
using Data_Access_Layer;

namespace Business_Access_Layer
{
    public interface IEmp_BALr

    {
        int Add_Employee_BAL(int e_Id, String e_fname, string e_lname, DateTime e_dob, long e_contact, string e_address);

        void Edit_Employee_BAL(Employee emp_to_change);

        Employee GetEmployeeById_BAL(int id);

        int Delete_Employee_BAL(int e_Id);

        void ViewAllEmployees_BAL();
    }
}
