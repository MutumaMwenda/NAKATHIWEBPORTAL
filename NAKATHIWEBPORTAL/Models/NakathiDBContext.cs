using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NAKATHIWEBPORTAL.Models
{
   
    public class NakathiDBContext : DbContext
    {
        public NakathiDBContext()
            : base("name = DefaultConnection1")
        {
        }
        public virtual DbSet<Member> ix_Members { get; set; }
        public virtual DbSet<Member_Line> ix_Member_Lines { get; set; }
        
        public virtual DbSet<Member_Type> ix_Member_Types { get; set; }
        public virtual DbSet<Vehicle> ix_Vehicle { get; set; }
        public virtual DbSet<Vehicle_Line> ix_Vehicle_Lines { get; set; }
        public virtual DbSet<Vehicle_Log> ix_Vehicle_Logs { get; set; }
        public virtual DbSet<Vehicle_Line_Log> ix_Vehicle_Line_Logs { get; set; }
        public virtual DbSet<Staff_Member> ix_Staff_Members { get; set; }
        public virtual DbSet<Staff_Member_Line> ix_Staff_Member_Lines { get; set; }
        public virtual DbSet<Route_Type> ix_Route_Types { get; set; }
        public virtual DbSet<License_Type> ix_Licence_Types { get; set; }
        public virtual DbSet<License_Issuer> ix_Licence_Issuers { get; set;}
        public virtual DbSet<License> ix_Licences { get; set; }
        public virtual DbSet<Insurer> ix_Insurers { get; set; }

        public virtual DbSet<Insurance_Policy_Type> ix_Insurance_Policy_Types { get; set; }
        public virtual DbSet<Insurance> ix_Insurances { get; set; }
        public virtual DbSet<Drivers_Conductor> ix_Drivers_Conductors { get; set; }
        public virtual DbSet<Drivers_Conductor_Log> ix_Drivers_Conductor_Logs { get; set; }
        public virtual DbSet<Saving_Type> ix_Saving_Types { get; set; }
        public virtual DbSet<Daily_Savings_collection> ix_Daily_Savings_collections { get; set; }
        public virtual DbSet<Daily_Savings_collection_Log> ix_Daily_Savings_collection_Logs { get; set; }
        public virtual DbSet<Contribution> ix_Contributions { get; set; }
        public virtual DbSet<Contribution_Log> ix_Contribution_Logs { get; set; }
        public virtual DbSet<Contribution_Type> ix_Contribution_Types { get; set; }
        public virtual DbSet<Revenue> ix_Revenues { get; set; }
        public virtual DbSet<Revenue_Log> ix_Revenue_Logs { get; set; }
        public virtual DbSet<Revenue_Type> ix_Revenue_Types { get; set; }
        public virtual DbSet<Loans> ix_Loans { get; set; }
        public virtual DbSet<Loan_Type> ix_Loan_Types { get; set; }
        public virtual DbSet<Guarantor> ix_Guarantors { get; set; }
        public virtual DbSet<Committee_Approval> ix_Committee_Approvals { get; set; }
        public virtual DbSet<Committee> ix_Committees { get; set; }
        public virtual DbSet<Committee_Position> ix_Committee_Positions { get; set; }
        public virtual DbSet<Loan_Payment> ix_Loan_Payments { get; set; }
        public virtual DbSet<Loan_Payment_Log> ix_Loan_Payment_Logs { get; set; }
      
        public virtual DbSet<Shares_table> ix_Shares_tables { get; set; }
        public virtual DbSet<Banker> ix_Bankers { get; set; }
        public virtual DbSet<Vehicle_make> ix_Vehicle_makes { get; set; }
        public virtual DbSet<Vehicle_model> ix_Vehicle_models { get; set; }
    
        public virtual DbSet<Vehicle_Configuration> ix_Vehicle_Configurations { get; set; }
        public virtual DbSet<Sacco_Staff_Position> ix_Sacco_Staff_Positions { get; set; }

        public virtual DbSet<PayrollConfiguration> ix_PayrollConfigurations { get; set; }
        public virtual DbSet<SaccoAsset> ix_SaccoAssets { get; set; }
        public virtual DbSet<Incident> ix_Incidents { get; set; }
        public virtual DbSet<SaccoExpense> ix_SaccoExpenses { get; set; }
        public virtual DbSet<Con_Type> ix_Con_Types { get; set; }
        public virtual DbSet<Bank_Branch> ix_Bank_Branches { get; set; }
    }
}