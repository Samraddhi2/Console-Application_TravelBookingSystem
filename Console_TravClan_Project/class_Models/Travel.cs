using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_Models
{
    public enum ApprovedStatus{Pending, Approved, Not_Approved}
    public enum BookingStatus {NULL, Available, Not_Available}

    public enum CurrentStatus { open, closed}
    public class Travel
    {

        public int Req_id {  get; set; }    
        public DateTime Req_Date { get; set; }  
        public string from_loc {  get; set; }   
        public string To_loc { get; set;}
        public int Emp_id {  get; set; }    
        public ApprovedStatus Approved_status  { get; set;}
        public  BookingStatus  Booking_status {  get; set; } 
        public CurrentStatus Current_status {  get; set; }

        public override string ToString()
        {
            return string.Format("\t\t|{0,-10} | {1,-10} | {2,-16} | {3,-16} | {4,-8} | {5,-15} | {6,-14} | {7,-10}"
                , Req_id,Req_Date, from_loc,To_loc, Emp_id, Approved_status, Booking_status, Current_status);
        }

    }
}
