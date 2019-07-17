using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NAKATHIWEBPORTAL.Models;

namespace NAKATHIWEBPORTAL.Models
{
    public class MembersViewModel
    {
        //Header table
        public int id { get; set; }
        public String sacco_member_code { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String surname { get; set; }
        public String pinNumber { get; set; }
        public int id_number { get; set; }
        public DateTime? DOB { get; set; }
        public String county_of_residence { get; set; }
        public String subCounty_of_residence { get; set; }
        public String estate_of_residence { get; set; }
        public decimal total_values_of_shares_bought { get; set; }
        public String phone_number { get; set; }
        public String member_postalAddress { get; set; }
        public String bank_code { get; set; }
        public Int64 bank_accountNumber { get; set; }
        public int bankbranch_id { get; set; }
        public String email { get; set; }
        public String Photo { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public int member_type_id { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime created_at { get; set; }

        //line table
        public int line_id { get; set; }
        public int member_id { get; set; }
        public String first_next_of_kin { get; set; }
        public String second_next_of_kin { get; set; }
        public String third_next_of_kin { get; set; }
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


    }
    public class VehicleViewModel
    {
        //vehicle header
        public int id { get; set; }
        public String Vehicle_Sacco_Code { get; set; }
        public int first_vehicle_owner { get; set; }
        public int vehicle_make_id { get; set; }
        public int vehicle_model_id { get; set; }
        public int vehicle_config_id { get; set; }
        public String reg_no { get; set; }
        public String chassisNumber { get; set; }
        public String colour { get; set; }
        public int year_of_manufacture { get; set; }
        public String logbook_no { get; set; }
        

        //vehicle lines
        public int vehicleid { get; set; }
        public int vehicleheader_id { get; set; }
        public int? second_vehicle_owner { get; set; }
        public int? third_vehicle_owner { get; set; }
        public int route_id { get; set; }
        public string notes { get; set; }
        public String Photo { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        //set up table
        public string make  { get; set; }
        public string vehicle_configuration { get; set; }
        public string vehicle_model { get; set; }
        public string route { get; set; }
        public string owner_name { get; set; }


    }
    public class StaffViewModel
    {
       //staff header
        public int id { get; set; }
        public String sacco_member_code { get; set; }
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
        //public String Photo { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }

        //Staff lines
        public int line_id { get; set; }
        public int staff_id { get; set; }
        public String first_next_of_kin { get; set; }
        public String second_next_of_kin { get; set; }
        public String third_next_of_kin { get; set; }
        public String first_beneficiary { get; set; }
        public String second_beneficiary { get; set; }
        public String third_beneficiary { get; set; }
        public String first_next_of_kin_phone_number { get; set; }
        public String second_next_of_kin_phone_number { get; set; }
        public String third_next_of_kin_phone_number { get; set; }
        public String first_next_of_kin_postalAddress { get; set; }
        public String second_next_of_kin_postalAddress { get; set; }
        public String third_next_of_kin_postalAddress { get; set; }
        public String driverLicense_No { get; set; }
        public String psvBadge { get; set; }
        public String certificate_of_goodconduct { get; set; }
        public DateTime date_assigned { get; set; }
        public DateTime assigned_up_to_date { get; set; }
        public String Photo { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public String sacco_staff_type_name { get; set; }
    }
    public class Driver_ConductorVM
    {
        public int id { get; set; }//from driver_conductor table
        public int id_number { get; set; }//from driver_conductor table
        public String reg_no { get; set; }//from driver_conductor table
        public DateTime date_assigned { get; set; }//from driver_conductor table
        public DateTime assigned_up_to_date { get; set; }//from driver_conductor table
        public String name { get; set; }//from member table
        public String Sacco_Staff_Position_name { get; set; }//from member_type table
        public String route_name { get; set; }//from route_type table
        public string created_by { get; set; }
        public string updated_by { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
    public class LicencesVm
    {
        public int id { get; set; }
        public String reg_no { get; set; }
        public string license_type_name { get; set; }
        public string license_issuer_name { get; set; }
        public int possessor { get; set; }
        public string possessor_name { get; set; }
        public String Photo { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }
        public DateTime activefrom { get; set; }
        public DateTime expiryDate { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }

    }
    public class InsuranceVm
    {
        public int id { get; set; }
        public String reg_no { get; set; }
        public string insurer_name { get; set; }
        public string insurance_policytype_name { get; set; }
        public string policyNumber { get; set; }
        public string vehicle_Inspection_date { get; set; }
        public string next_inspection_date { get; set; }
        public string RSLStickernumber { get; set; }
        public string RSLStickernumberexpiry_date { get; set; }
        public DateTime active_from { get; set; }
        public DateTime expiryDate { get; set; }
        public String Photo { get; set; }
        
       // public HttpPostedFileBase ImageFile { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }


    }
    public class ContributionVm
    {
        public int id { get; set; }
        public String name { get; set; }

        public String con_type_name { get; set; }
        public int? contribution_type { get; set; }
        public String frequency { get; set; }
        public int contribution_id { get; set; }
        public decimal amount { get; set; }
        public int? member_id { get; set; }
        public int? revenuetype_id { get; set; }
        public String reg_no { get; set; }
        public int? loan_id { get; set; }
        public List<ContributionTypeVm> list1 { get; set; }


    }
    public class ContributionTypeVm
    {
        public int id { get; set; }
        public String name { get; set; }

        public String con_type_name { get; set; }
        public int? contribution_type { get; set; }
        public String contribution_id { get; set; }
        public decimal amount { get; set; }
        public bool IsSelected { get; set; }


    }


}