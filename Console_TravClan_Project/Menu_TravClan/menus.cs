using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Access_Layer;
using class_Models;

namespace Menu_TravClan
{
    public class menus
    {
        private readonly Emp_BAL emp1 = new Emp_BAL();
        private readonly Req_BAL rq_BAL = new Req_BAL();
        int choice1;
        public void showmain()
        {
            //int choice1;
           
                do
                {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\n\n{0,100}","------------------------------");
                    Console.WriteLine("{0,100}","     WELCOME ON TRAVCLAN      ");
                    Console.WriteLine("{0,100}","------------------------------");
                    Console.WriteLine("\n\n   {0,90}\n","*****MAIN MENU******");
                    Console.WriteLine("{0,92}\n {1,92}\n {2,86}\n {3,82}\n","1. EMPLOYEE PAGE","2. TRAVEL BOOKING","3. VIEW ALL"," 4. Exit");
                    Console.WriteLine("{0,87}","Enter your choice");
                    choice1 = int.Parse(Console.ReadLine());

                    switch (choice1)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("====WELCOME ON EMPLOYEE PAGE=====");
                            emp_menu();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("=====WELCOME ON TRAVEL BOOKING=====");
                            trav_menu();
                            break;

                        case 3:
                            Console.Clear();
                            view_join();
                            rq_BAL.ViewJoinEmployeeReq_BAL();
                            Console.ReadLine();
                            break;

                        case 4:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Enter Right Choice");
                            Console.ReadLine();
                            break;
                    }
                }catch (Exception ex)
            {

                Console.WriteLine("Enter right Choice " + ex.Message);
                    Console.ReadLine();
            }
        } while (choice1 != 4);

            
        }

        public void emp_menu()
        {
            
            
            do
            {
                try
                {
                    Console.Clear();
                Console.WriteLine("\n\n----------------------------------\n");
                Console.WriteLine("-----WELCOME ON EMPLOYEE PAGE-----\n");
                Console.WriteLine("----------------------------------\n");
                Console.WriteLine("{0,18}\n","MENU");
                Console.WriteLine("{0,20}\n{1,23}\n{2,23}\n{3,22}\n{4,12}\n{5,11}\n","1. ADD EMPLOYEE","2. UPDATE EMPLOYEE","3. DELETE EMPLOYEE","4. VIEW EMPLOYEES","5. BACK","6.EXIT");
                Console.WriteLine("Enter your choice");
                choice1 = int.Parse(Console.ReadLine());

                switch (choice1)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n===WELCOME ON ADD EMPLOYEE PAGE====\n");
                        ADD_EMP();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n{0,105}","===WELCOME ON ADD UPDATE PAGE====\n");
                        Edit_Emp();
                        break;

                    case 3:
                        Console.Clear();
                        //Delete Employee Page
                        view_Emp();
                        delete_emp();
                        break;

                    case 4:
                        Console.Clear();
                        //View Employees Page
                        view_Emp();
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.Clear();
                        showmain();
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Enter right Choice");
                        break;
                }
            
            }
            catch (Exception ex)
            {

                Console.WriteLine("Enter right Choice " + ex.Message);
            }
        } while (choice1 != 6);
        }

        public void trav_menu()
        {
            int ID;
           

                do
                {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\n\n----------------------------------------\n");
                    Console.WriteLine("-----WELCOME ON TRAVEL BOOKING PAGE-----\n");
                    Console.WriteLine("----------------------------------------\n");
                    Console.WriteLine("{0,18}\n","MENU");
                    Console.WriteLine("{0,23}\n{1,25}\n{2,24}\n{3,22}\n{4,22}\n{5,24}\n{6,14}\n{7,14}\n","1. RAISE REQUEST","2. APPROVE REQUEST","3. BOOKING STATUS","4. VIEW REQUEST","5. EDIT REQUEST","6. DELETE REQUEST","7. EXIT","8. BACK");
                    Console.WriteLine("Enter your choice");
                    choice1 = int.Parse(Console.ReadLine());

                    switch (choice1)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\n\n===========WELCOME ON RAISE REQUEST PAGE===========");
                            Raise_Req();
                            break;
                        case 2:
                            Console.Clear();

                            approve_req();
                            // rq_BAL.View_approved_re_BAL();
                            break;
                        case 3:
                            Console.Clear();
                            Booking_req();
                            break;
                        case 4:
                            Console.Clear();
                            view_Req();
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.Clear();

                            Edit_Req();
                            break;

                        case 6:
                            Console.Clear();
                            view_Req();
                            Console.WriteLine("Enter Request ID to delete ");
                            ID = int.Parse(Console.ReadLine());
                            rq_BAL.Delete_req_BAL(ID);
                            view_Req();
                            Console.ReadLine() ;
                            break;

                        case 7:
                            Environment.Exit(0);
                            break;

                        case 8:
                            Console.Clear();
                            showmain();
                            break;

                        default:
                            Console.WriteLine("Enter right Choice");
                            break;
                    }
                
            }
            catch (Exception ex)
            {

                Console.WriteLine("Enter right Choice " + ex.Message);
            }
            } while (choice1 != 7);
        }

            public void ADD_EMP()
            {
            int id;
            long contact;
            string fname, lname, address;
            DateTime dob;

            Console.WriteLine("Enter your ID\n");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your first name\n");
            fname = Console.ReadLine();
            Console.WriteLine("Enter your last name\n");
            lname = Console.ReadLine();
            Console.WriteLine("Enter your Contact\n");
            contact = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Address:\n");
            address = Console.ReadLine();
            Console.WriteLine("Enter your D-O-B:\n");
            dob = DateTime.Parse(Console.ReadLine());

            emp1.Add_Employee_BAL(id, fname, lname, dob, contact, address);

        }

        public void Edit_Emp()
        {
            int id;
            string fname, lname, address;
            long contact;
            DateTime dob;


            
            view_Emp();
            Console.WriteLine("\n Enter the Employee ID to Edit ");
            id = int.Parse(Console.ReadLine());
            Employee emp_to_change = emp1.GetEmployeeById_BAL(id);
           

                do
                {
                try
                {
                    Console.WriteLine("What you want to edit? ");
                    Console.WriteLine("1. First Name\n 2. Last Name\n 3. Address\n 4. D-O-B\n 5. Contact\n 6. Back\n 7. Exit\n");
                    choice1 = int.Parse(Console.ReadLine());
                    switch (choice1)
                    {
                        case 1:
                            Console.WriteLine("Enter First Name ");
                            fname = Console.ReadLine();
                            emp_to_change.emp_fname = fname;
                            break;
                        case 2:
                            Console.WriteLine("Enter Last Name ");
                            lname = Console.ReadLine();
                            emp_to_change.emp_lname = lname;
                            break;
                        case 3:
                            Console.WriteLine("Enter Address ");
                            address = Console.ReadLine();
                            emp_to_change.emp_address = address;
                            break;
                        case 4:
                            Console.WriteLine("Enter D-O-B ");
                            dob = DateTime.Parse(Console.ReadLine());
                            emp_to_change.emp_dob = dob;
                            break;

                        case 5:
                            Console.WriteLine("Enter Phone Number ");
                            contact = long.Parse(Console.ReadLine());
                            emp_to_change.emp_contact = contact;
                            break;
                        case 6:
                            Console.Clear();
                            emp_menu();
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter right choice ");
                            break;
                    }

               

                emp1.Edit_Employee_BAL(emp_to_change);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Enter right Choice " + ex.Message);
            }
            } while (choice1 != 7);
        }


            public void view_Emp()
            {
            Console.WriteLine("{0,270}\n","EMPLOYEE DATABASE TABLE");
            Console.WriteLine("\n{0,120}","*************************************************************************************");
            Console.WriteLine("\t\t\t\t   |{0,-10} | {1,-10} | {2,-10} | {3,-19} | {4,-10} | {5,-5}", "ID", "First Name", "Last Name", "D-O-B", "Address", "Contact");
            Console.WriteLine("{0,120}","*************************************************************************************");
            emp1.ViewAllEmployees_BAL();
        }

        public void delete_emp()
        {
            int ID;
            Console.WriteLine("\n Enter ID : ");
            ID = int.Parse(Console.ReadLine());
            emp1.Delete_Employee_BAL(ID);
            Console.WriteLine("Employee Deleted Successfully");
            view_Emp();
            Console.ReadLine();
        }

        public void Raise_Req()
        {
            int r_i, e_id;
            DateTime travel_date;
            string frm_loc, to_loc;
            Console.WriteLine("Enter Your Request ID\n");
            r_i = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Employee ID\n");
            e_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter travel Date\n");
            travel_date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Journey starting Location\n");
            frm_loc = Console.ReadLine();
            Console.WriteLine("Enter your Destination\n");
            to_loc = Console.ReadLine();

            rq_BAL.Raise_req_BAL(r_i, travel_date, frm_loc, to_loc, e_id);
        }

        public void Edit_Req()
        {
            int id;
            string frm_loc, to_loc;
            DateTime t_date;


            Console.WriteLine("----------------EDIT REQUEST_____________");
            view_Req();
            rq_BAL.ViewAllRequests_BAL();
            Console.WriteLine("\n Enter the REquest  ID to Edit ");
            id = int.Parse(Console.ReadLine());
            Travel emp_to_change = rq_BAL.GetRequestByID_BAL(id);
           

                do
                {
                try
                {
                    Console.WriteLine("What you want to edit? ");
                    Console.WriteLine("1. From Location\n 2. Destination\n 3. Journey Date\n 4. Back\n 5. Exit\n");
                    choice1 = int.Parse(Console.ReadLine());
                    switch (choice1)
                    {
                        case 1:
                            Console.WriteLine("Enter your journey start Location  ");
                            frm_loc = Console.ReadLine();
                            emp_to_change.from_loc = frm_loc;
                            break;
                        case 2:
                            Console.WriteLine("Enter your Destination ");
                            to_loc = Console.ReadLine();
                            emp_to_change.To_loc = to_loc;
                            break;
                        case 3:
                            Console.WriteLine("Enter Journey Date ");
                            t_date = DateTime.Parse(Console.ReadLine());
                            emp_to_change.Req_Date = t_date;
                            break;
                        case 4:
                            Console.Clear();
                            trav_menu();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter right choice ");
                            break;
                    }
                    rq_BAL.Edit_req_BAL(emp_to_change);

               

            }
            catch (Exception ex)
            {

                Console.WriteLine("Enter right Choice " + ex.Message);
            }
            } while (choice1 != 5);
        }

            public void view_Req()
        {
            Console.WriteLine("\n\n{0,280}","TRAVEL REQUEST DATABASE TABLE");
            Console.WriteLine("\n {0,150}","***************************************************************************************************************************************");
            Console.WriteLine("\t\t|{0,-10} | {1,-19} | {2,-16} | {3,-16} | {4,-8} | {5,-10} | {6,-10} | {7,-10}", "RequestID", "Rq_Date", "From_Location", "To_Location", "Emp_ID", "Approved_Status", "Booking_Status", "Confirm_Status");
            Console.WriteLine("  {0,150}","****************************************************************************************************************************************");
            rq_BAL.ViewAllRequests_BAL();
            
        }

        public void approve_req()
        {
            int  rid;
            ApprovedStatus a = ApprovedStatus.Pending;


            Console.WriteLine("\n\n{0,280}", "TRAVEL REQUEST DATABASE TABLE");
            Console.WriteLine("\n {0,150}", "***************************************************************************************************************************************");
            Console.WriteLine("\t\t|{0,-10} | {1,-19} | {2,-16} | {3,-16} | {4,-8} | {5,-10} | {6,-10} | {7,-10}", "RequestID", "Rq_Date", "From_Location", "To_Location", "Emp_ID", "Approved_Status", "Booking_Status", "Confirm_Status");
            Console.WriteLine("  {0,150}", "****************************************************************************************************************************************");

            rq_BAL.View_Pending_re_BAL();
            Console.WriteLine("Enter Request Id which you want to take in action ");
            rid = int.Parse(Console.ReadLine());
            Travel emp_to_change = rq_BAL.GetRequestByID_BAL(rid);
           
                do
                {
                try
                {

                    Console.WriteLine("\n1. Approve\n 2. Not Approve\n 3. Pending\n 4. Back\n 5. Exit\n");
                    Console.WriteLine("Enter your choice");
                    choice1 = int.Parse(Console.ReadLine());
                    switch (choice1)
                    {
                        case 1:
                            a = ApprovedStatus.Approved;
                            emp_to_change.Approved_status = a;
                            break;
                        case 2:
                            a = ApprovedStatus.Not_Approved;
                            emp_to_change.Approved_status = a;
                            break;
                        case 3:
                            a = ApprovedStatus.Pending;
                            emp_to_change.Approved_status = a;
                            break;
                        case 4:
                            trav_menu();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter right choice");
                            break;
                    }
                    rq_BAL.Approve_req_BAL(rid, a);
                
            }
            catch (Exception ex)
            {

                Console.WriteLine("Enter right Choice " + ex.Message);
            }

            } while (choice1 != 5);
        }


        public void Booking_req()
        {
            int rid;
            BookingStatus b = BookingStatus.NULL;

            Console.WriteLine("\n\n{0,280}", "TRAVEL REQUEST DATABASE TABLE");
            Console.WriteLine("\n {0,150}", "***************************************************************************************************************************************");
            Console.WriteLine("\t\t|{0,-10} | {1,-19} | {2,-16} | {3,-16} | {4,-8} | {5,-10} | {6,-10} | {7,-10}", "RequestID", "Rq_Date", "From_Location", "To_Location", "Emp_ID", "Approved_Status", "Booking_Status", "Confirm_Status");
            Console.WriteLine("  {0,150}", "****************************************************************************************************************************************");
            
            rq_BAL.View_BookingNULL_re_BAL();

            Console.WriteLine("Enter Request Id which you want to take in action ");
            rid = int.Parse(Console.ReadLine());
            Travel emp_to_change = rq_BAL.GetRequestByID_BAL(rid);
            


                do
                {
                try
                {
                    Console.WriteLine("\n 1. Available\n 2. Not Available\n  3. Back\n  4. Exit\n");
                    Console.WriteLine("Enter your choice");
                    choice1 = int.Parse(Console.ReadLine());
                    switch (choice1)
                    {
                        case 1:
                            b = BookingStatus.Available;
                            emp_to_change.Booking_status = b;
                            break;
                        case 2:
                            b = BookingStatus.Not_Available;
                            emp_to_change.Booking_status = b;
                            break;

                        case 3:
                            trav_menu();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter right choice");
                            break;
                    }
                    rq_BAL.Confirm_rq_BAL(rid, b);
               
            }
            catch (Exception ex)
            {

                Console.WriteLine("Enter right Choice " + ex.Message);
            }
            } while (choice1 != 4);
        }

      

            public void view_join()
        {
            Console.WriteLine("\n\n {0,100}","WELCOME ON MY VIEW ALL PAGE");
            Console.WriteLine("****************************************************************************************************************************************************************");
            Console.WriteLine("|{0,-6}|{1,-8}|{2,-8}|{3,-11}|{4,-20}|{5,-12}|{6,-6}|{7,-10}|{8,-10}|{9,-20}|{10,-10}|{11,-10}|{12,-10}", "ID",
                "F_Name", "L_Name", "Address", "D-O-B", "Contact", "R_ID", "Departure", "Arrival", "Date", "R_Status", "Booking", "Current Status");
            Console.WriteLine("****************************************************************************************************************************************************************");
        }



        
    }

}


