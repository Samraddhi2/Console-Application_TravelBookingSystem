using class_Models;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business_Access_Layer
{
    public class Req_BAL:IReq_BAL
    {
        private readonly ReqDataManager _DataManager = new ReqDataManager();
        public int Raise_req_BAL(int req_id, DateTime req_date, string from_loc, string to_loc, int e_Id)
        {
            int rq1 = _DataManager.Raise_req_DAL(req_id, req_date, from_loc, to_loc, e_Id);
            return rq1;
        }
        public void Edit_req_BAL(Travel travelRequest)
        {
            _DataManager.Edit_req_DAL(travelRequest);

            
        }
        public int Delete_req_BAL(int req_id)
        {
            _DataManager.Delete_req_DAL(req_id);
            return 1;
        }
        public int Approve_req_BAL(int travel_id, ApprovedStatus appstatus)
        {
            int app = _DataManager.Approve_req_DAL(travel_id, appstatus);

            return app ;
        }
        public int Confirm_rq_BAL(int travel_id, BookingStatus bookstatus)
        {
            int con = _DataManager.Confirm_rq_DAL(travel_id, bookstatus);
            return con ;
        }

       
        public void ViewAllRequests_BAL()
        {
            _DataManager.ViewAllRequests_DAL();
            
        }

        public void ViewJoinEmployeeReq_BAL()
        {
            _DataManager.ViewJoinEmployeeReq_DAL();

        }

       public void View_Pending_re_BAL()
        {
            _DataManager.View_Pending_re_DAL();
        }


        public void View_BookingNULL_re_BAL()
        {
            _DataManager.View_BookingNULL_re_DAL();
        }

        public void View_approved_re_BAL()
        {
            _DataManager.View_approved_re_DAL();
        }

        public void View_notapproved_re_BAL()
        {
            _DataManager.View_notapproved_re_DAL();
        }

        public Travel GetRequestByID_BAL(int id)
        {
            Travel trav = _DataManager.GetRequestByID_DAL( id);
            return trav;
        }
    }
}
