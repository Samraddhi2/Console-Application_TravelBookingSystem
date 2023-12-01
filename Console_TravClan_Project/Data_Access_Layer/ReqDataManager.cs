using class_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data_Access_Layer
{
    public class ReqDataManager : IReqDataManager
    {
        EmpDataManager empl = new EmpDataManager();
        

        public List<Travel> travelreq  = new List<Travel>() {


        new Travel() { Req_id=1,Req_Date=DateTime.Parse("01/02/2023"),from_loc="Pune",To_loc="Agra",Emp_id=1,Approved_status = ApprovedStatus.Pending,Booking_status=BookingStatus.NULL,Current_status=CurrentStatus.open},
        new Travel() { Req_id=2,Req_Date=DateTime.Parse("23/03/2023"),from_loc="Noida",To_loc="Pune",Emp_id=2,Approved_status = ApprovedStatus.Pending,Booking_status=BookingStatus.NULL,Current_status=CurrentStatus.open},
        new Travel() { Req_id=3,Req_Date=DateTime.Parse("12/05/2023"),from_loc="Delhi",To_loc="Ambala",Emp_id=3,Approved_status = ApprovedStatus.Pending,Booking_status=BookingStatus.NULL,Current_status=CurrentStatus.open},
        new Travel() { Req_id=4,Req_Date=DateTime.Parse("11/06/2023"),from_loc="Ghaziabad",To_loc="Ajmer",Emp_id=4,Approved_status = ApprovedStatus.Pending,Booking_status=BookingStatus.NULL,Current_status=CurrentStatus.open}

    };

   

        public int Raise_req_DAL(int req_id, DateTime req_date, string frm_loc, string to_loc, int emp_id)
        {
            travelreq.Add(new Travel() { Req_id = req_id, Req_Date = req_date, from_loc = frm_loc, 
                To_loc = to_loc, Emp_id = emp_id,
                Approved_status = ApprovedStatus.Pending,
                Booking_status = BookingStatus.NULL,
                Current_status = CurrentStatus.open
            });

            return 1;
        }



        public void ViewAllRequests_DAL()
        {
            foreach (Travel t in travelreq)
            {
                Console.WriteLine(t.ToString());
            }
        }

        public void Edit_req_DAL(Travel travelRequest)
        {
            Travel emp_main = travelreq.FirstOrDefault(X => X.Req_id == travelRequest.Req_id);
            int index = travelreq.IndexOf(emp_main);

            travelreq[index].Req_Date = emp_main.Req_Date;
            travelreq[index].from_loc = emp_main.from_loc;
            travelreq[index].To_loc = emp_main.To_loc;
            
        }
        public int Delete_req_DAL(int req_id)
        {
            var requestToDelete = travelreq.Find(req => req.Req_id == req_id);



            if (requestToDelete != null)
            {
                travelreq.Remove(requestToDelete);
            }
            else
            {
                Console.WriteLine("Requested ID not found\n");
            }
            return 0;

        }
        public int Approve_req_DAL(int travel_id, ApprovedStatus appstatus)
        {
            var qmethodApprove = travelreq.FirstOrDefault(X => X.Req_id == travel_id);
            
           
            int index = travelreq.IndexOf(qmethodApprove);

            travelreq[index].Approved_status = qmethodApprove.Approved_status;

            if (qmethodApprove != null)
            {
                if (qmethodApprove.Approved_status == ApprovedStatus.Approved)
                { 
                    qmethodApprove.Current_status = CurrentStatus.open;
                    Console.WriteLine("\n {0,150}", "***************************************************************************************************************************************");
                    Console.WriteLine("\t\t|{0,-10} | {1,-19} | {2,-16} | {3,-16} | {4,-8} | {5,-10} | {6,-10} | {7,-10}", "RequestID", "Rq_Date", "From_Location", "To_Location", "Emp_ID", "Approved_Status", "Booking_Status", "Confirm_Status");
                    Console.WriteLine("  {0,150}", "****************************************************************************************************************************************");
                    View_approved_re_DAL();
                }
                else if (qmethodApprove.Approved_status == ApprovedStatus.Not_Approved)
                {
                    qmethodApprove.Current_status = CurrentStatus.closed;
                    qmethodApprove.Booking_status = BookingStatus.NULL;
                    Console.WriteLine("\n {0,150}", "***************************************************************************************************************************************");
                    Console.WriteLine("\t\t|{0,-10} | {1,-19} | {2,-16} | {3,-16} | {4,-8} | {5,-10} | {6,-10} | {7,-10}", "RequestID", "Rq_Date", "From_Location", "To_Location", "Emp_ID", "Approved_Status", "Booking_Status", "Confirm_Status");
                    Console.WriteLine("  {0,150}", "****************************************************************************************************************************************");
                    View_notapproved_re_DAL();
                }
                else
                {
                    ViewAllRequests_DAL();
                }

            }
            return 1;

        }
        public int Confirm_rq_DAL(int travel_id, BookingStatus bookstatus)
        {
            var qmethodApprove = travelreq.FirstOrDefault(X => X.Req_id == travel_id);
            
            int index = travelreq.IndexOf(qmethodApprove);

            travelreq[index].Booking_status = qmethodApprove.Booking_status;

            if (qmethodApprove != null)
            {
                if (qmethodApprove.Booking_status == BookingStatus.Available)
                {
                    qmethodApprove.Current_status = CurrentStatus.closed;

                    ViewAllRequests_DAL();
                }
                else if (qmethodApprove.Booking_status == BookingStatus.Not_Available)
                {
                    qmethodApprove.Current_status = CurrentStatus.closed;

                   
                    View_notapproved_re_DAL();
                }
                else
                {
                    ViewAllRequests_DAL();
                }

            }

            return 1;

        }

       
        public void ViewJoinEmployeeReq_DAL()
        {
            var emp_Trav = from emp in empl.employee join trav in travelreq
                             on emp.emp_id equals trav.Emp_id
                             select new
                             {
                                 e = emp.emp_id,
                                 f = emp.emp_fname,
                                 l = emp.emp_lname,
                                 a = emp.emp_address,
                                 d = emp.emp_dob,
                                 c = emp.emp_contact,
                                 r = trav.Req_id,
                                 frm_loc = trav.from_loc,
                                 T_loc = trav.To_loc,
                                 T_date = trav.Req_Date,
                                 a_s = trav.Approved_status,
                                 b_s = trav.Booking_status,
                                 c_s = trav.Current_status



                             };

            foreach (var emps in emp_Trav)
            {
               Console.WriteLine("|{0,-6}|{1,-8}|{2,-8}|{3,-11}|{4,-15} |{5,-12}|{6,-6}|{7,-10}|{8,-10}|{9,-11} |{10,-10}|{11,-10}|{12,-10}",
                    emps.e,emps.f,emps.l,emps.a,emps.d,emps.c,emps.r,emps.frm_loc,emps.T_loc,
                    emps.T_date,emps.a_s,emps.b_s,emps.c_s);
            }

        }

        public void View_notapproved_re_DAL()
        {
            var pending = from req in travelreq
                          where req.Approved_status == ApprovedStatus.Not_Approved
                          select new
                          {
                              r = req.Req_id,
                              d = req.Req_Date,
                              f = req.from_loc,
                              t = req.To_loc,
                              e = req.Emp_id,
                              a = req.Approved_status,
                              b = req.Booking_status,
                              c = req.Current_status

                          };
            foreach (var emps in pending)
            {
                Console.WriteLine("\t\t|{0,-10} | {1,-8} | {2,-16} | {3,-16} | {4,-8} | {5,-15} | {6,-14} | {7,-10}\n ",
                    emps.r, emps.d, emps.f, emps.t, emps.e, emps.a, emps.b, emps.c);
            }
        }


        public void View_approved_re_DAL()
        {
            var pending = from req in travelreq
                          where req.Approved_status == ApprovedStatus.Approved
                          select new
                          {
                              r = req.Req_id,
                              d = req.Req_Date,
                              f = req.from_loc,
                              t = req.To_loc,
                              e = req.Emp_id,
                              a = req.Approved_status,
                              b = req.Booking_status,
                              c = req.Current_status

                          };
            foreach (var emps in pending)
            {
                Console.WriteLine("\t\t|{0,-10} | {1,-8} | {2,-16} | {3,-16} | {4,-8} | {5,-15} | {6,-14} | {7,-10}\n ",
                    emps.r, emps.d, emps.f, emps.t, emps.e, emps.a, emps.b, emps.c);
            }
        }

        public void View_Pending_re_DAL()
        {
            var pending = from req in travelreq
                          where req.Approved_status == ApprovedStatus.Pending
                          select new
                          {
                              r = req.Req_id,
                              d = req.Req_Date,
                              f = req.from_loc,
                              t = req.To_loc,
                              e = req.Emp_id,
                              a = req.Approved_status,
                              b = req.Booking_status,
                              c = req.Current_status

                          };
            foreach (var emps in pending)
            {
                Console.WriteLine("\t\t|{0,-10} | {1,-8} | {2,-16} | {3,-16} | {4,-8} | {5,-15} | {6,-14} | {7,-10}\n ", 
                    emps.r, emps.d, emps.f, emps.t,emps.e ,emps.a, emps.b, emps.c);
            }
        }


        public void View_BookingNULL_re_DAL()
        {
            var nullbooking = from req in travelreq
                          where req.Approved_status == ApprovedStatus.Approved && req.Booking_status == BookingStatus.NULL
                          select new
                          {
                              r = req.Req_id,
                              d = req.Req_Date,
                              f = req.from_loc,
                              t = req.To_loc,
                              e = req.Emp_id,
                              a = req.Approved_status,
                              b = req.Booking_status,
                              c = req.Current_status

                          };
            foreach (var emps in nullbooking)
            {
                Console.WriteLine("\t\t|{0,-10} | {1,-8} | {2,-16} | {3,-16} | {4,-8} | {5,-15} | {6,-14} | {7,-10}\n ",
                    emps.r, emps.d, emps.f, emps.t, emps.e, emps.a, emps.b, emps.c);
            }
        }
        public  Travel GetRequestByID_DAL(int id)
        {
            Travel lsttravel = travelreq.FirstOrDefault(e => e.Req_id == id);
            if (travelreq != null)
            {
                return lsttravel;
            }
            else
            {
                Console.WriteLine("This request ID is not found\n");
            }
            return null;
        }
    }
}
