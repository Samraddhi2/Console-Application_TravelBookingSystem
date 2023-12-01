using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_Models
{

    public class Employee
    {
        public int emp_id  { get; set; }
        public string emp_fname { get; set; }  

        public string emp_lname {  get; set; }  
        public DateTime emp_dob  { get; set;}

        public string emp_address {  get; set; }    
        public long emp_contact {  get; set; }  

       

        public override string ToString()
        {

            return string.Format("\t\t\t\t   |{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} ",emp_id,emp_fname,emp_lname,emp_dob,emp_address,emp_contact);
        }

    }
    
}
