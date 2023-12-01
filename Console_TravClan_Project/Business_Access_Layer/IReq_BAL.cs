using class_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;

namespace Business_Access_Layer
{
    public interface IReq_BAL
    {
        int Raise_req_BAL(int req_id, DateTime req_date, string from_loc, string to_loc, int e_Id);
        void Edit_req_BAL(Travel travelRequest);
        int Delete_req_BAL(int req_id);
        int Approve_req_BAL(int travel_id, ApprovedStatus appstatus);
        int Confirm_rq_BAL(int travel_id, BookingStatus bookstatus);
       
        void ViewAllRequests_BAL();

        void ViewJoinEmployeeReq_BAL();

         void View_Pending_re_BAL();

        void View_BookingNULL_re_BAL();

        void View_notapproved_re_BAL();

        void View_approved_re_BAL();

        Travel GetRequestByID_BAL(int id);
    }
}
