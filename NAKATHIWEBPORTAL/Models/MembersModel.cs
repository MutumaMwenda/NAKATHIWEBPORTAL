using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NAKATHIWEBPORTAL.Models
{
    public class Member     
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public String sacco_member_code { get; set; }
        [Required]
        public String first_name { get; set; }
        [Required]
        public String last_name { get; set; }
        [Required]
        public String surname { get; set; }
        [Required]
        public String pinNumber { get; set; }
        [Required]
        public int id_number { get; set; }
        public DateTime? DOB { get; set; }
        [Required]
        public String county_of_residence { get; set; }
        [Required]
        public String subCounty_of_residence { get; set; }
        [Required]
        public String estate_of_residence { get; set; }
        public decimal total_values_of_shares_bought { get; set; }
        [Required]
        public String phone_number { get; set; }
        [Required]
        public String member_postalAddress { get; set; }
        [Required]
        public String bank_code { get; set; }
        [Required]
        public Int64 bank_accountNumber { get; set; }
        public int bankbranch_id { get; set; }
        [Required]
        public String email { get; set; }
        public String Photo { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        [Required]
        public int member_type_id { get; set; }
        [Required]
        public int member_status { get; set; } = 1;
        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public int otpcode { get; set; }

    }
   public class Member_Line
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int member_id { get; set; }
        [Required]
        public String first_next_of_kin { get; set; }
      
        public String second_next_of_kin { get; set; }
       
        public String third_next_of_kin { get; set; }
        [Required]
        public String first_next_of_kin_phone_number { get; set; }
        public String second_next_of_kin_phone_number { get; set; }
        public String third_next_of_kin_phone_number { get; set; }
        public String first_next_of_kin_postalAddress { get; set; }
        public String second_next_of_kin_postalAddress { get; set; }
        public String third_next_of_kin_postalAddress { get; set; }
        public String first_beneficiary { get; set; }
        public String second_beneficiary { get; set; }
        public String third_beneficiary { get; set; }
        public decimal total_shares_bought { get; set; }
        public decimal cost_per_share { get; set; }
       // public decimal total_shares_bought_value { get; set; }
    }
   public class Member_Type
    {
        public int id { get; set; }
        public String name { get; set; }
    }
    public class Loan_Type
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public int interestRate { get; set; }
        public String repaymentPeriod { get; set; }

    }
    public class Vehicle
    {
        [Key]
        public int id { get; set; }
        public String Vehicle_Sacco_Code { get; set; }
        [Required]
        public int first_vehicle_owner { get; set; }
        public int makeId { get; set; }
        public int modelId { get; set; }
        public int configId { get; set; }

        [Required]
        public String reg_no { get; set; }
        public String chassisNumber { get; set; }
        public String colour { get; set; }
        public int year_of_manufacture { get; set; }
        
        [Required]
        public String logbook_no { get; set; }
        
        public DateTime? subscription_date { get; set; }
        public int subscription_status { get; set; } = 1;
        public decimal? subscription_amount { get; set; }
        public String created_by { get; set; }
        public  String  updated_by { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public int status { get; set; } = 1;

    }
    public class Vehicle_Line
    {
        [Key]
        public int id { get; set; }
        public int vehicle_id { get; set; }
        public int?  second_vehicle_owner { get; set; }
        public int? third_vehicle_owner { get; set; }
        [Required]
        public int route_id { get; set; }
        public string notes { get; set; }
        public string Photo { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
    public class Vehicle_Log
    {
        [Key]
        public int id { get; set; }
        public String Vehicle_Sacco_Code { get; set; }
        [Required]
        public int first_vehicle_owner { get; set; }
        public int makeId { get; set; }
        public int modelId { get; set; }
        public int configId { get; set; }

        [Required]
        public String reg_no { get; set; }
        public String chassisNumber { get; set; }
        public String colour { get; set; }
        public int year_of_manufacture { get; set; }

        [Required]
        public String logbook_no { get; set; }

        public DateTime? subscription_date { get; set; }
        public int subscription_status { get; set; } = 1;
        public decimal? subscription_amount { get; set; }
        public String created_by { get; set; }
        public String updated_by { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public int status { get; set; } = 1;


    }
    public class Vehicle_Line_Log
    {
        [Key]
        public int id { get; set; }
        public int vehicle_id { get; set; }
        public int? second_vehicle_owner { get; set; }
        public int? third_vehicle_owner { get; set; }
        [Required]
        public int route_id { get; set; }
        public string notes { get; set; }
        public string Photo { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


    }
    public class Shares_table
    {
        [Key]
        public int id { get; set; }
        [Required]
        public decimal initial_sacco_share_capital { get; set; }
        public decimal sacco_share_capital_balance { get; set; }
        public decimal total_Shares { get; set; }
        public decimal total_Shares_balance { get; set; }
        public decimal cost_per_share { get; set; }
        [Required]
        public int min_share { get; set; }
        [Required]
        public int max_share { get; set; }

    }
    public class Route_Type
    {   [Key]
        public int id { get; set; }
        public String name { get; set; }
        public String ntsa_code { get; set; }
    }
    public class License_Type
    {   [Key]
        public int id { get; set; }
        public String name { get; set; }
        public String license_issuer_code { get; set; }


    }
    public class License_Issuer
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }
        public String license_issuer_code { get; set; }


    }
    public class License
    {
        [Key]
        public int id { get; set; }
        public String reg_no { get; set; }
        [Required]
        public int license_type_id { get; set; }
        public String license_issuer_code { get; set; }
        public int possessor { get; set; }
        public String Photo { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public DateTime activefrom { get; set; }
        public DateTime expiryDate { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }
        public int status { get; set; } = 1;

      }
    public class Insurer
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }
        public String InsurerCode { get; set; }
    }
    public class Insurance_Policy_Type
    {
        [Key]
        public int id { get; set; }
        public String policytypename { get; set; }
        public String InsurerCode { get; set; }
    }
    public class Insurance
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String reg_no { get; set; }
        [Required]
        public String InsurerCode { get; set; }
        public int insurerance_policytype_id { get; set; }
        public string policyNumber { get; set; }
        public string vehicle_Inspection_date { get; set; }
        public string next_inspection_date { get; set; }
        public string RSLStickernumber { get; set; }
        public string RSLStickernumberexpiry_date { get; set; }
        public DateTime active_from { get; set; }
        public DateTime expiryDate { get; set; }
        public String Photo { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public int status { get; set; } = 1;

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }

    }
    public class Banker
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string bank_Code { get; set; }
    }
    public class Bank_Branch
    {
        [Key]
        public int id { get; set; }
        public string branchname { get; set; }
        public string bank_Code { get; set; }
    }
    public class Vehicle_make
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string make { get; set; }
        public string code { get; set; }
    }
    public class Vehicle_model
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string vmodel { get; set; }
        public int makeId { get; set; }
    }

    public class Vehicle_Configuration
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string configuration { get; set; }
        public string mode { get; set; }
        public int modelId { get; set; }
    }


    
    public class Sacco_Staff_Position
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        
    }
    public class Staff_Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public String sacco_staff_code { get; set; }
        public String pinNumber { get; set; }
        public int id_number { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String surname { get; set; }
        public DateTime? DOB { get; set; }
        public String county_of_residence { get; set; }
        public String subCounty_of_residence { get; set; }
        public String estate_of_residence { get; set; }
        public int Sacco_Staff_Position_id { get; set; }
        public String phone_number { get; set; }
        
        public String member_postalAddress { get; set; }
        
        public String bank_code { get; set; }
       
        public Int64 bank_accountNumber { get; set; }
        public int? bankbranch_id { get; set; }
        public String email { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
    public class Staff_Member_Line
    {
        [Key]
        public int id { get; set; }
        public int staff_id { get; set; }
        [Required]
        public String first_next_of_kin { get; set; }
        [Required]
        public String second_next_of_kin { get; set; }
        [Required]
        public String third_next_of_kin { get; set; }
        public String first_beneficiary { get; set; }
        public String second_beneficiary { get; set; }
        public String third_beneficiary { get; set; }
        [Required]
        public String first_next_of_kin_phone_number { get; set; }
        public String second_next_of_kin_phone_number { get; set; }
        public String third_next_of_kin_phone_number { get; set; }
        public String first_next_of_kin_postalAddress { get; set; }
        public String second_next_of_kin_postalAddress { get; set; }
        public String third_next_of_kin_postalAddress { get; set; }
        public String driverLicense_No { get; set; }
        public String psvBadge { get; set; }
        public String certificate_of_goodconduct { get; set; }
        public String Photo { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


    }
    public class Drivers_Conductor
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int id_number { get; set; }
        [Required]
        public string reg_no { get; set; }
        [Required]
        public int Sacco_Staff_Position_id { get; set; }
        public DateTime date_assigned { get; set; }
        public DateTime assigned_up_to_date { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
    public class Drivers_Conductor_Log
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int id_number { get; set; }
        [Required]
        public string reg_no { get; set; }
        [Required]
        public int Sacco_Staff_Position_id { get; set; }
        public DateTime date_assigned { get; set; }
        public DateTime assigned_up_to_date { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
    public class Saving_Type
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }
    }
    public class Incident
    {
        [Key]
        public int id { get; set; }
        public int idNo { get; set; }
        public String vehicle_RegNo { get; set; }
    }
    public class Daily_Savings_collection
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int id_number { get; set; }
        
        public int sacco_id { get; set; }
        [Required]
        public String reg_no { get; set; }
        [Required]
        public decimal amount { get; set; }
        [Required]
        public String depositor { get; set; }
        [Required]
        public int saving_type_id { get; set; }
        public DateTime deposited_date { get; set; } = DateTime.Now;
        public String received_by { get; set; }
       


    }
    public class Daily_Savings_collection_Log
    {
        [Key]
        public int id { get; set; }
        public int id_number { get; set; }
       // public int sacco_id { get; set; }
        public String reg_no { get; set; }
        public decimal amount { get; set; }
        public String depositor { get; set; }
        public int saving_type_id { get; set; }
        public DateTime deposited_date { get; set; }
        public String received_by { get; set; }


    }
    public class Contribution
    {
         [Key]
        public int id { get; set; }
       
        public int? id_number { get; set; }
        public String reg_no { get; set; }
        public int? member_id { get; set; }
        public int contribution_id { get; set; }
        public string transactionId { get; set; }
        public decimal total_saving_amount { get; set; }
        public decimal? available_amount { get; set; }
        public String contributor { get; set; }
        public DateTime contribution_date { get; set; }
        public String received_by { get; set; }


    }
    public class Contribution_Log
    {
        [Key]
        public int id { get; set; }
        public int? id_number { get; set; }
        public int? member_id { get; set; }
        public int contribution_id { get; set; }
        public String reg_no { get; set; }
        public string transactionId { get; set; }
        public decimal amount { get; set; }
        public String contributor { get; set; }
        public DateTime contribution_date { get; set; } 
        public String received_by { get; set; }


    }
    public class Contribution_Type
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }
        public int con_type_id { get; set; }
        public int contribution_type { get; set; } 
        public string frequency { get; set; }
        public decimal? amount { get; set; } = 0;
        
    }

    public class Con_Type
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }

    }
    
    public class Revenue
    {
        [Key]
        public int id { get; set; }
        
        public int? member_id { get; set; }
        [Required]
        public int revenuetype_id { get; set; }
        public String reg_no { get; set; }
        [Required]
        public decimal amount { get; set; }
        [Required]
        public DateTime date_collected { get; set; } = DateTime.Now;
        public int non_member_status { get; set; } = 1;
        public int status { get; set; } = 0;
        public String received_by { get; set; }

    }
    public class Revenue_Log
    {
        [Key]
        public int id { get; set; }
        public int? member_id { get; set; }
        public int revenuetype_id { get; set; }
        public String reg_no { get; set; }
        public decimal amount { get; set; }
        public DateTime date_collected { get; set; }
        public int non_member_status { get; set; } = 1;
        public int status { get; set; }
        public String received_by { get; set; }

    }
    public class Revenue_Type
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; } 

    }

    public class RevenueType
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public int interestRate { get; set; }
        public String repaymentPeriod { get; set; }

    }
    public class PayrollConfiguration
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String earningCode { get; set; }
        [Required]
        public String earningname { get; set; }
        [Required]
        public String deductionCode { get; set; }
        [Required]
        public String deductionNames { get; set; }
        [Required]
        public String taxation_deductions { get; set; }

    }

    public class SaccoAsset
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String name { get; set; }
       

    }
    public class SaccoExpense
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public int id_number { get; set; }
        [Required]
        public int staff_id { get; set; }
        [Required]
        public String description { get; set; }
        [Required]
        public decimal amount { get; set; }
        public String Photo { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        
        public DateTime expense_date { get; set; }



    }

    public class Loans
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int loan_type_id { get; set; }
        [Required]
        public int member_id { get; set; }
        [Required]
        public decimal amount { get; set; }
        public decimal p_amount { get; set; }
        [Required]
        public DateTime date_requested { get; set; } = DateTime.Now;
        public DateTime? action_date { get; set; }
        public DateTime? due_date { get; set; }
        public int status { get; set; } = 0;
        public int recalled { get; set; } = 0;

    }
    public class Guarantor
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int loan_id { get; set; }
        [Required]
        public int member_id { get; set; }
        [Required]
        public decimal amount { get; set; }
        public DateTime date_requested { get; set; }
        public int status { get; set; }

    }
    public class Committee_Approval
    {
        [Key]
        public int id { get; set; }
        public int committee_member_id { get; set; }
        public int applicant_id { get; set; }
        public int loan_id { get; set; }
        public DateTime action_date { get; set; }
        public int status { get; set; }

    }
    public class Committee
    {
        [Required]
        public int id { get; set; }
        [Required]
        public int position_id { get; set; }
        [Required]
        public String name { get; set; }
        public DateTime date_created { get; set; } = DateTime.Now;

    }
    public class Committee_Position
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }

    }
    public class Loan_Payment
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int loan_id { get; set; }
        [Required]
        public int member_id { get; set; }
        [Required]
        public decimal amount { get; set; }
        [Required]
        public String received_by { get; set; }
        public String paid_by { get; set; }
        public DateTime date_paid { get; set; } = DateTime.Now;


    }
    public class Loan_Payment_Log
    {
        public int id { get; set; }
        public int loan_id { get; set; }
        public int member_id { get; set; }
        public decimal amount { get; set; }
        public String received_by { get; set; }
        public DateTime date_paid { get; set; }
        public String paid_by { get; set; }


    }

    
    
}