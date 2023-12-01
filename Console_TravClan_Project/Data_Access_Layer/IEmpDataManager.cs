using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using class_Models;

namespace Data_Access_Layer
{
    public interface IEmpDataManager
    {
        int Add_Employee_DAL(int e_Id, String e_fname, string e_lname, DateTime e_dob, long e_contact, string e_address);
        void Edit_Employee_DAL(Employee employee);

        int Delete_Employee_DAL(int e_Id);

        void ViewAllEmployees_DAL();

        Employee GetEmployeeById_DAL(int id);
    }
}
