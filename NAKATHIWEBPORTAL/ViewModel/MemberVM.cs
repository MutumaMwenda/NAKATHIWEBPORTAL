using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAKATHIWEBPORTAL.ViewModel
{
    public class MemberVM
    {
        public int id { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String surname { get; set; }
        public int id_number { get; set; }
        public String phone_number { get; set; }
        public String place_of_residence { get; set; }
        public Int64 bank_accountNumber { get; set; }
        public String bankbranch { get; set; }
        public String email { get; set; }
        public string member_type_name { get; set; }
    }
    public class ContributionVM
    {
        public int id { get; set; }
        public string contribution_name { get; set; }
        public string membername { get; set; }
        public string transactionid { get; set; }
        public string Reg_No { get; set; }
        public DateTime contribution_date { get; set; }
        public decimal amount { get; set; }
    }
    public class RevenueVM
    {
        public int id { get; set; }// revenue table
        public String first_name { get; set; }//member table
        public String name { get; set; }//revenue type table
        public String reg_no { get; set; }// revenue table
        public decimal amount { get; set; }// revenue table
        public DateTime date_collected { get; set; }// revenue table          
    }
    public class VehicleConfigurationsVM
    {
        public int id { get; set; }
        public string modelname { get; set; }
        public string configuration { get; set; }
        public string mode { get; set; }
    }
    public class VehicleModelVM
    {
        public int id { get; set; }
        public string makename { get; set; }
        public string modelname { get; set; }
    }
    public class BankBranchVM
    {
        public int id { get; set; }
        public string bankname { get; set; }
        public string bankcode { get; set; }
        public string branchname { get; set; }
    }
    public class LoanPaymentVM
    {
        public int id { get; set; }// from loan payment table

        public String name { get; set; }//// from loan_type table

        public String first_name { get; set; }// from member table

        public decimal amount { get; set; }// from loan payment table
        public decimal amt { get; set; }// from loan table

        public String received_by { get; set; }// from loan payment table
        public DateTime date_paid { get; set; }// from loan payment table
        public String paid_by { get; set; }// from loan payment table
    }
    public class VehicleVM
    {
        public int id { get; set; }  //from vehicle table
        public String vehicle_owner { get; set; } //from member table
        //public String name { get; set; } //from member table
        public int id_number { get; set; } //from member table
        public String reg_no { get; set; }  //from vehicle table
        public String route_name { get; set; }//from route table
        public String logbook_no { get; set; } //from vehicle table
        public int conductor_idNO { get; set; }//from vehicle table
        public int driver_idNO { get; set; }//from vehicle table

    }

    public class SaccoExpenseVM
    {
        public int id { get; set; }
        public String name { get; set; }//from member  table
        public int id_number { get; set; }//from sacco expense  table
        public String description { get; set; }//from sacco expense  table
        public decimal amount { get; set; }//from sacco expense  table
        public DateTime expense_date { get; set; }//from sacco expense  table
        public String Photo { get; set; }//from sacco expense  table

    }

    public class CommitteeVM
    {
        public int id { get; set; }//from committee table
        public String name { get; set; }//from committee table
        public String position_name { get; set; }//from position table
        public DateTime date_created { get; set; }//from committee table
    }
    public class CommitteeApprovalVM
    {

        public int id { get; set; }//from committee table
        public String name { get; set; }//from committee table
        public String type { get; set; }//from committee table
        public String amount { get; set; }//from position table
        public DateTime date_created { get; set; }//from committee table
        public String status { get; set; }//from position table
        public List<GuarantorsVM> list1 { get; set; }
    }

public class GuarantorsVM
    {
        public int id { get; set; }
        public String name { get; set; }
        public decimal amount { get; set; }
        public int status { get; set; }
    }
    public class DailySavingsSummary
    {
        public int id { get; set; }// daily saving table
        public int id_number { get; set; }////member table
        public String reg_no { get; set; }// daily saving table
        public decimal amount { get; set; }// daily saving table
        public String depositor { get; set; }// daily saving table
        public String name { get; set; }//Saving_Type table
        public DateTime deposited_date { get; set; }// daily saving table

    }
    public class CertificationVM
    {
        public int id { get; set; }// from certification table
        public String reg_no { get; set; }// from certification table
        public string certfication_name { get; set; }// from certification table
        public int possessor { get; set; }// from certification table
        public string possessor_name { get; set; }
        public string isurer_name { get; set; }//from isurer table
        public string policyNumber { get; set; }// from certification table
        public DateTime active_from { get; set; }// from certification table
        public DateTime expiryDate { get; set; }// from certification table
        public string vehicle_Inspection_date { get; set; }// from certification table
        public string next_inspection_date { get; set; }// from certification table
        public string RSLStickernumber { get; set; }// from certification table
        public string RSLStickernumberexpiry_date { get; set; }// from certification table
        public DateTime renewed_date { get; set; } // from certification table
    }
}