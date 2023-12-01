using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using class_Models;

namespace Data_Access_Layer
{
    public interface IReqDataManager
    {
        int Raise_req_DAL(int req_id,DateTime req_date, string from_loc, string to_loc,int e_Id);
        void Edit_req_DAL(Travel travelRequest);
        int Delete_req_DAL(int req_id);
        int Approve_req_DAL(int travel_id, ApprovedStatus appstatus);
        int Confirm_rq_DAL(int travel_id, BookingStatus bookstatus);
       
        void ViewAllRequests_DAL();

        void ViewJoinEmployeeReq_DAL();

        void View_Pending_re_DAL();

        void View_approved_re_DAL();
        void View_notapproved_re_DAL();
        void View_BookingNULL_re_DAL();
        Travel GetRequestByID_DAL(int id);

    }
}
